namespace TestAutomationFramework.StepDefinitions;

[Binding]
public sealed class BookMeetingSteps
{
    private readonly IObjectContainer _container;
    private readonly IBrowserContext context;
    
    IPage page;
    HomePage homePage;
    BookingPage bookingPage;

    public BookMeetingSteps(IObjectContainer _container)
    {
        this._container = _container ?? throw new ArgumentNullException(nameof(_container), "IObjectContainer cannot be null");
        page = _container.Resolve<IPage>();
        context = _container.Resolve<IBrowserContext>();
        homePage = _container.Resolve<HomePage>();
        bookingPage = _container.Resolve<BookingPage>();
    }

    [Given(@"I am on the TestDevLab test automation page")]
    public async Task GivenIAmOnTheTestDevLabTestAutomationPage() => await homePage.NavigateAsync(Configs.BaseUrl);

    [When(@"I click the Book a meeting button")]
    public async Task WhenIClickTheBookAMeetingButton() =>  await homePage.ClickBookMeetingAsync();

    [When(@"I switch to the Calendly tab")]
    public async Task WhenISwitchToTheCalendlyTab() => await bookingPage.SwitchToCalendlyTab();
    
    [When(@"I select the following date and time:")]
    public async Task WhenISelectTheFollowingDateAndTime(Table table) => await bookingPage.SelectDateAndTimeAsync(table);
    
    [When(@"I click Next")]
    public async Task WhenIClickNext() => await bookingPage.ClickNextAsync();

    [When(@"I fill in the booking form with the following details:")]
    public async Task FillBookingFormWithDetails(Table table) => await bookingPage.FillForm(table);
    

    [When(@"I schedule the event")]
    public async Task WhenIScheduleTheEvent() => await bookingPage.ScheduleEventAsync();

    [Then(@"the booking should be confirmed")]
    public async Task ThenTheBookingShouldBeConfirmed() => await bookingPage.ValidateBookingAsync();
}