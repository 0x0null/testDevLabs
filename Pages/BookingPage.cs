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
        var date = row["Date"];
        var time = row["Time"];

        var dateLocator = page.Locator($"button[aria-label*='{date}'][aria-label*='Times available']");
        await dateLocator.ClickAsync();

        var timeLocator = page.Locator($"button[data-start-time*='{time}']");
        await timeLocator.ClickAsync();
    }

    public async Task ClickNextAsync() => await page.Locator("button[aria-label*='Ne']").ClickAsync();

    public async Task FillForm(Table table)
    {
        var formData = table.Rows.ToDictionary(row => row["Field"], row => row["Value"]);

        foreach (var (field, value) in formData)
        {
            // Optional: add "*" if needed for required fields
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

    public async Task ScheduleEventAsync() => await page.Locator(".t1850o97.tneybjo").ClickAsync();

    public async Task ValidateBookingAsync() => await assert.Expect(page.GetByText("You are scheduled", new() { Exact = true })).ToBeVisibleAsync();
}
