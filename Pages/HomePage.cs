namespace TestAutomationFramework.Pages;

public class HomePage : BasePage
{
    private readonly IPage page;

    public HomePage(IPage page) : base(page)
    {
        this.page = page; 
    }

    public async Task ClickBookMeetingAsync()
    {
        var popupPage = await page.RunAndWaitForPopupAsync(async () =>
        {
            await page.GetByRole(AriaRole.Button, new() { Name = "Book a meeting" }).ClickAsync();
        });
        await page.GotoAsync("https://calendly.com/tdl-get-a-consultation/30min?month=2025-04");
    }
}

public abstract class BasePage
{
    protected IPage Page { get; }

    protected BasePage(IPage page)
    {
        Page = page;
    }

    public async Task NavigateAsync(string url)
    {
        await Page.GotoAsync(url, new() { WaitUntil = WaitUntilState.DOMContentLoaded });
    }
}
