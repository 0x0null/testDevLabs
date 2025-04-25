namespace TestAutomationFramework.Pages;

public class HomePage
{
    private readonly IPage page;

    public HomePage(IPage page) => this.page = page;

    public async Task NavigateAsync(string url) => await page.GotoAsync(url, new() { WaitUntil = WaitUntilState.DOMContentLoaded });

    public async Task ClickBookMeetingAsync()
    {
        var popupPage = await page.RunAndWaitForPopupAsync(async () =>
        {
            await page.GetByRole(AriaRole.Button, new() { Name = "Book a meeting" }).ClickAsync();
        });
        await page.GotoAsync("https://calendly.com/tdl-get-a-consultation/30min?month=2025-04");

    }
}
