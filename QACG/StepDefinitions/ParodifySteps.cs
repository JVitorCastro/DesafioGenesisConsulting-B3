using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using TechTalk.SpecFlow;

[Binding]
public class ParodifySteps
{
    private readonly IPage _page;

    public ParodifySteps(ScenarioContext scenarioContext)
    {
        _page = scenarioContext.Get<IPage>("PlaywrightPage");
    }

    [Given(@"que eu esteja na página inicial do Parodify")]
    public async Task PaginaIncialParodify()
    {
        await _page.GotoAsync("https://parodify.vercel.app/");
        await Expect(_page.Locator("//*[@class='logo']")).ToBeVisibleAsync();
        await Expect(_page.Locator("#search-input")).ToBeVisibleAsync();
    }

    [When(@"eu pesquisar a música ""(.*)""")]
    public async Task PesquisarMusica(string musica)
    {
        await _page.FillAsync("#search-input", musica);
        await _page.GetByRole(AriaRole.Button, new() { Name = "Buscar" }).ClickAsync();
    }

    [Then(@"nenhuma música deve ficar vísivel")]
    public async Task VerificarAusenciaMusicas()
    {
        await Expect(_page.Locator(".song")).ToBeHiddenAsync();
    }

    [Then(@"deve exibir a mensagem: ""(.*)""")]
    public async Task VerificarMensagem(string mensagem)
    {
        await Expect(_page.Locator("span").Last).ToHaveTextAsync(mensagem);
    }

    [When(@"eu voltar para a página inicial")]
    public async Task VoltarPaginaInicial()
    {
        await _page.ClickAsync(".logo");
        await Expect(_page.Locator("//*[@class='logo']")).ToBeVisibleAsync();
        await Expect(_page.Locator("#search-input")).ToBeVisibleAsync();
    }

    [Then(@"devo ver apenas a música ""(.*)"" sendo exibida")]
    public async Task VerificarMusicaExibida(string musica)
    {
        await Expect(_page.Locator(".song")).ToHaveCountAsync(1);
        await Expect(_page.Locator(".songlist h6 ")).ToHaveTextAsync(musica);

    }
}
