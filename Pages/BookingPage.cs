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
        await Page.GetByRole(AriaRole.Button, new() { Name = "16:30" }).ClickAsync();
    }

    public async Task ClickNextAsync() => await Page.GetByRole(AriaRole.Button, new() { Name = "Next 16:" }).ClickAsync();

    public async Task ScheduleEventAsync() => await Page.GetByRole(AriaRole.Button, new() { Name = submitButton }).ClickAsync();

    public async Task ValidateBookingAsync() => await assert.Expect(Page.GetByText("You are scheduled", new() { Exact = true })).ToBeVisibleAsync();
}
