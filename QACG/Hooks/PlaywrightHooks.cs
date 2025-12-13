using System.Threading.Tasks;
using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace QACG.StepDefinitions
{
    [Binding]
    public sealed class PlaywrightHooks
    {
        private const string PageKey = "PlaywrightPage";
        private static IPlaywright _playwright;
        private static IBrowser _browser;
        private readonly ScenarioContext _scenarioContext;

        public PlaywrightHooks(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        [BeforeTestRun]
        public static async Task BeforeTestRunAsync()
        {
            if (_playwright is not null)
                return;

            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true
            });
        }

        [BeforeScenario]
        public async Task BeforeScenarioAsync()
        {
            // Cria apenas a página por cenário; o browser é compartilhado
            var page = await _browser.NewPageAsync();
            _scenarioContext.Set(page, PageKey);
        }

       
    }
}