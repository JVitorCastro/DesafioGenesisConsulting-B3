using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using TechTalk.SpecFlow;

[Binding]
public class CorreiosSteps
{
    private readonly IPage _page;

    public CorreiosSteps(ScenarioContext scenarioContext)
    {
        _page = scenarioContext.Get<IPage>("PlaywrightPage");
    }


    [Given(@"que eu esteja na página de busca de CEP dos Correios")]
    public async Task PaginaInicial()
    {
        await _page.GotoAsync("https://buscacepinter.correios.com.br/app/endereco/index.php?t");
        await Expect( _page.Locator("#trilha b")).ToHaveTextAsync(new Regex("Busca por Endereço ou CEP"));
        await Expect( _page.Locator("#titulo_tela")).ToHaveTextAsync(new Regex("Busca CEP"));
    }

    [When(@"eu pesquisar o CEP ""(.*)""")]
    public async Task QuandoEuPesquisarOCep(string cep)
    {
        await _page.FillAsync("#endereco", cep);
        await _page.ClickAsync("#btn_pesquisar");
    }

    [Then(@"devo ver a mensagem de CEP inexistente")]
    public void ThenDevoVerAMensagemDeCEPInexistente()
    {
    }

    [Then(@"devo ver o endereço ""(.*)""")]
    public void ThenDevoVerOEndereco(string p0)
    {
    }

    [When(@"eu pesquisar o código de rastreamento ""(.*)""")]
    public void WhenEuPesquisarOCodigoDeRastreamento(string p0)
    {
    }

    [Then(@"devo ver a mensagem de código inválido")]
    public void ThenDevoVerAMensagemDeCodigoInvalido()
    {
    }
}
