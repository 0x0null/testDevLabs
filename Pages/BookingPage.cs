namespace TestAutomationFramework.Pages;

public class BookingPage
{
    private IPage page;

    public BookingPage(IPage page) => this.page = page ?? throw new ArgumentNullException(nameof(page));


    public async Task SwitchToCalendlyTab()
    {
        var pages = page.Context.Pages;
        Assert.That(pages.Count, Is.AtLeast(2), "Expected two tabs");
        page = pages[1];
        await page.BringToFrontAsync();
    }

    public async Task SelectDateAndTimeAsync(Table table)
    {
        var row = table.Rows[0];
        await page.Locator($"button[aria-label*='{row["Date"]}'][aria-label*='Times available']").ClickAsync();
        var buttons = page.Locator("//div[@role='list']/div/button");
        var texts = await buttons.AllTextContentsAsync();
        var matching = texts.Zip(Enumerable.Range(0, texts.Count))
                            .FirstOrDefault(x => x.First.Contains(row["Time"]));
        var button = matching.Equals(default) ? buttons.First : buttons.Nth(matching.Second);
        await button.ClickAsync();
    }


    public async Task ClickNextAsync() => await page.Locator("button[aria-label*='Ne']").ClickAsync();

    public async Task FillForm(Table table)
    {
        var formData = table.Rows.ToDictionary(row => row["Field"], row => row["Value"]);

        foreach (var (field, value) in formData)
        {
            var label = field switch
            {
                "Name" => "Name *",
                "Email" => "Email *",
                "Company" => "Company *",
                _ => field
            };

            await page.GetByRole(AriaRole.Textbox, new() { Name = label }).FillAsync(value);
        }

    }

    public async Task ScheduleEventAsync() => await page.GetByRole(AriaRole.Button, new() { Name = "Schedule Event" }).ClickAsync();

    public async Task ValidateBookingAsync() => await assert.Expect(page.GetByText("You are scheduled", new() { Exact = true })).ToBeVisibleAsync();
}
