using System.IO;
using Microsoft.Playwright;
using TechTalk.SpecFlow;
using static Microsoft.Playwright.Assertions;

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
        await Expect(_page.Locator("#trilha b")).ToHaveTextAsync(new Regex("Busca por Endereço ou CEP"));
        await Expect(_page.Locator("#titulo_tela")).ToHaveTextAsync(new Regex("Busca CEP"));
    }

    [When(@"eu pesquisar o CEP ""(.*)""")]
    public async Task QuandoEuPesquisarOCep(string cep)
    {
        await _page.FillAsync("#endereco", cep);

        var captcha = _page.Locator("#captcha");
        // Fica em loop até o captcha começar a ser preenchido
        for (int i = 0; i != 1;)
        {
            if (await captcha.InputValueAsync() != "")
            {
                // Espera 15 segundos para o usuário preencher o captcha
                await Task.Delay(15000);
                i = 1;
            }
            else
            {
                TestContext.WriteLine("Preencha o captcha!");
            }
        }

        // Clica em buscar caso o usuário o faça
        var btnPesquisar = _page.Locator("#btn_pesquisar");
        if (await btnPesquisar.IsVisibleAsync())
        {
            await btnPesquisar.ClickAsync();
        }
    }

    [Then(@"devo ver a mensagem de ""(.*)""")]
    public async Task ThenDevoVerAMensagemDeCEPInexistente(string mensagem)
    {
        await Expect(_page.Locator("#mensagem-resultado")).ToHaveTextAsync(new Regex("Não há dados a serem exibidos"));
        await Expect(_page.Locator("#mensagem-resultado-alerta")).ToHaveTextAsync(new Regex(mensagem));
    }

    [When(@"eu voltar para a página de busca de CEP dos Correios")]
    public async Task WhenEuVoltarAPaginaDeBuscaDeCEP()
    {
        await _page.Locator("#btn_nbusca").ClickAsync();
    }

    [Then(@"devo ver o endereço Rua Quinze de Novembro, São Paulo/SP")]
    public async Task ThenDevoVerOEndereco()
    {
        await Expect(_page.Locator("//td[@data-th=\"Logradouro/Nome\"]")).ToHaveTextAsync(new Regex("Rua Quinze de Novembro - lado ímpar"));
        await Expect(_page.Locator("td[data-th=\"Bairro/Distrito\"]")).ToHaveTextAsync(new Regex("Centro"));
        await Expect(_page.Locator("td[data-th=\"Localidade/UF\"]")).ToHaveTextAsync(new Regex("São Paulo/SP"));
        await Expect(_page.Locator("//td[@data-th=\"CEP\"]")).ToHaveTextAsync(new Regex("01013-001"));
    }

}
