using Microsoft.Playwright;

namespace TestAutomationFramework.Pages;

public class BookingPage : BasePage
{
    private readonly string submitButton = "Schedule Event";

    public BookingPage(IPage page) : base(page) { }

    public async Task SelectDateAndTimeAsync()
    {
        await Page.GetByRole(AriaRole.Button, new() { Name = "Tuesday, April 29 - Times" }).ClickAsync();
        await Page.WaitForTimeoutAsync(2000);
        await Page.GetByRole(AriaRole.Button, new() { Name = "12:00" }).ClickAsync();
    }

    public async Task ClickNextAsync()
    {
        await Page.GetByRole(AriaRole.Button, new() { Name = "Next 12:" }).ClickAsync();
    }

    public async Task FillFormAsync()
    {
        await Page.GetByRole(AriaRole.Textbox, new() { Name = "Name *" }).ClickAsync();
        await Page.GetByRole(AriaRole.Textbox, new() { Name = "Name *" }).FillAsync("Cal");
        await Page.GetByRole(AriaRole.Textbox, new() { Name = "Name *" }).PressAsync("Tab");
        await Page.GetByRole(AriaRole.Textbox, new() { Name = "Email *" }).FillAsync("cal@cal.com");
        await Page.GetByRole(AriaRole.Textbox, new() { Name = "Company *" }).ClickAsync();
        await Page.GetByRole(AriaRole.Textbox, new() { Name = "Company *" }).FillAsync("cal ng ltd");
        await Page.GetByRole(AriaRole.Textbox, new() { Name = "Topic description" }).ClickAsync();
        await Page.GetByRole(AriaRole.Textbox, new() { Name = "Topic description" }).FillAsync("na");
    }

    public async Task ScheduleEventAsync()
    {
        await Page.GetByRole(AriaRole.Button, new() { Name = submitButton }).ClickAsync();
    }

    public async Task ValidateBookingAsync()
    {
        await assert.Expect(Page.GetByText("You are scheduled", new() { Exact = true })).ToBeVisibleAsync();
    }
}
