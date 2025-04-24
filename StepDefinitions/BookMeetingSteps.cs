namespace TestAutomationFramework.StepDefinitions;

[Binding]
public sealed class BookMeetingSteps
{
    private readonly IObjectContainer _container;
    private readonly IBrowserContext context;
    
    IPage page;

    public BookMeetingSteps(IObjectContainer _container)
    {
        this._container = _container ?? throw new ArgumentNullException(nameof(_container), "IObjectContainer cannot be null");
        page = _container.Resolve<IPage>();
        context = _container.Resolve<IBrowserContext>();
    }

    [Given(@"I am on the TestDevLab test automation page")]
    public async Task GivenIAmOnTheTestDevLabTestAutomationPage()
    {
        var homePage = new HomePage(page);
        await homePage.NavigateAsync(Configs.BaseUrl);
    }

    [When(@"I click the Book a meeting button")]
    public async Task WhenIClickTheBookAMeetingButton()
    {
        var homePage = new HomePage(page);
        await homePage.ClickBookMeetingAsync();
    }

    [When(@"I switch to the Calendly tab")]
    public async Task WhenISwitchToTheCalendlyTab()
    {
        var pages = context.Pages;
        Assert.That(pages.Count, Is.AtLeast(2), "Expected two tabs");
        page = pages[1];
        await page.BringToFrontAsync();
    }

    [When(@"I select a date and time")]
    public async Task WhenISelectADateAndTime()
    {
        var bookingPage = new BookingPage(page);
        await bookingPage.SelectDateAndTimeAsync();
    }

    [When(@"I click Next")]
    public async Task WhenIClickNext()
    {
        var bookingPage = new BookingPage(page);
        await bookingPage.ClickNextAsync();
    }

    [When(@"I fill in the booking form with the following details:")]
    public async Task FillBookingFormWithDetails(Table table)
    {
        var formData = table.Rows.ToDictionary(row => row["Field"], row => row["Value"]);

        await page.GetByRole(AriaRole.Textbox, new() { Name = "Name *" }).FillAsync(formData["Name"]);
        await page.GetByRole(AriaRole.Textbox, new() { Name = "Email *" }).FillAsync(formData["Email"]);
        await page.GetByRole(AriaRole.Textbox, new() { Name = "Company *" }).FillAsync(formData["Company"]);
        await page.GetByRole(AriaRole.Textbox, new() { Name = "Topic description" }).FillAsync(formData["Topic description"]);
    }



    [When(@"I schedule the event")]
    public async Task WhenIScheduleTheEvent()
    {
        var bookingPage = new BookingPage(page);
        await bookingPage.ScheduleEventAsync();
    }

    [Then(@"the booking should be confirmed")]
    public async Task ThenTheBookingShouldBeConfirmed()
    {
        var bookingPage = new BookingPage(page);
        await bookingPage.ValidateBookingAsync();
    }
}