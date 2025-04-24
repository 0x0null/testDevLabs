namespace TestAutomationFramework.Tests;

[Binding]
public sealed class BaseHooks
{
    [BeforeScenario]
    public static async Task SetupAsync(IObjectContainer container)
    {
        var playwright = await Playwright.CreateAsync();
        container.RegisterInstanceAs(playwright);

        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Channel = "chrome",
            Headless = false,
            SlowMo = 50,
        });
        container.RegisterInstanceAs(browser);

        var browserContext = await browser.NewContextAsync(new BrowserNewContextOptions
        {
            ViewportSize = new ViewportSize
            {
                Width = 1920, 
                Height = 1080 
            }
        });
        container.RegisterInstanceAs(browserContext);

        var page = await browserContext.NewPageAsync();
        container.RegisterInstanceAs(page);
    }


    [AfterScenario]
    public async Task TearDownAsync(IObjectContainer container)
    {
        var browser = container.Resolve<IBrowser>();
        if (browser != null)
        {
          await browser.CloseAsync();
        }
    }

}