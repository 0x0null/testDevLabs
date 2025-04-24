Task
1. Navigate to https://www.testdevlab.com/services/test-automation
2. Click Book a meeting
3. This will open a new tab
4. Switch to the second tab
5. Select a date from calendar and select time
6. Click next
7. Complete the details form by entering Name,Email,Company,Topic Description.
8. Click schedule event

TestAutomationFramework/
│
├── Config/
│   └── Config.cs                # Configuration settings for the framework
│
├── Drivers/
│   └── ImplicitUsings.cs        # Driver-related utilities or implicit usings
│
├── Features/
│   └── BookMeeting.feature      # Gherkin feature files for test scenarios
│
├── Pages/
│   ├── BookingPage.cs           # Page Object for the booking page
│   └── HomePage.cs              # Page Object for the home page
│
├── StepDefinitions/
│   └── BookMeetingSteps.cs      # Step definitions for the feature files
│
├── Tests/
│   └── Hooks.cs                 # Hooks for setup and teardown
│
└── README.md                    # Project documentation