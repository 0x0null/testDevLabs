Feature: Book a Meeting on TestDevLab
  As a user
  I want to book a meeting through the TestDevLab website
  So that I can discuss test automation services

  Scenario: Successfully book a meeting
    Given I am on the TestDevLab test automation page
    When I click the Book a meeting button
    And I switch to the Calendly tab
    And I select the following date and time:
      | Date                | Time    |
      | Tuesday, April 29   | 8:00    |
    And I click Next
    And I fill in the booking form with the following details:
      | Field             | Value            |-
      | Name              | Cal              |
      | Email             | cal@cal.com      |
      | Company           | cal ng ltd       |
      | Topic description | na               |
    And I schedule the event
    Then the booking should be confirmed


   