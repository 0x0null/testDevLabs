﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by Reqnroll (https://www.reqnroll.net/).
//      Reqnroll Version:2.0.0.0
//      Reqnroll Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace testDevLabs.Features
{
    using Reqnroll;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "2.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Book a Meeting on TestDevLab")]
    public partial class BookAMeetingOnTestDevLabFeature
    {
        
        private global::Reqnroll.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private static global::Reqnroll.FeatureInfo featureInfo = new global::Reqnroll.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Book a Meeting on TestDevLab", "  As a user\r\n  I want to book a meeting through the TestDevLab website\r\n  So that" +
                " I can discuss test automation services", global::Reqnroll.ProgrammingLanguage.CSharp, featureTags);
        
#line 1 "BookMeeting.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public static async System.Threading.Tasks.Task FeatureSetupAsync()
        {
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public static async System.Threading.Tasks.Task FeatureTearDownAsync()
        {
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public async System.Threading.Tasks.Task TestInitializeAsync()
        {
            testRunner = global::Reqnroll.TestRunnerManager.GetTestRunnerForAssembly(featureHint: featureInfo);
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Equals(featureInfo) == false)))
            {
                await testRunner.OnFeatureEndAsync();
            }
            if ((testRunner.FeatureContext == null))
            {
                await testRunner.OnFeatureStartAsync(featureInfo);
            }
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public async System.Threading.Tasks.Task TestTearDownAsync()
        {
            await testRunner.OnScenarioEndAsync();
            global::Reqnroll.TestRunnerManager.ReleaseTestRunner(testRunner);
        }
        
        public void ScenarioInitialize(global::Reqnroll.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public async System.Threading.Tasks.Task ScenarioStartAsync()
        {
            await testRunner.OnScenarioStartAsync();
        }
        
        public async System.Threading.Tasks.Task ScenarioCleanupAsync()
        {
            await testRunner.CollectScenarioErrorsAsync();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Successfully book a meeting")]
        public async System.Threading.Tasks.Task SuccessfullyBookAMeeting()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Successfully book a meeting", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 6
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 7
    await testRunner.GivenAsync("I am on the TestDevLab test automation page", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 8
    await testRunner.WhenAsync("I click the Book a meeting button", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 9
    await testRunner.AndAsync("I switch to the Calendly tab", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
                global::Reqnroll.Table table1 = new global::Reqnroll.Table(new string[] {
                            "Date",
                            "Time"});
                table1.AddRow(new string[] {
                            "Tuesday, April 29",
                            "08:00"});
#line 10
    await testRunner.AndAsync("I select the following date and time:", ((string)(null)), table1, "And ");
#line hidden
#line 13
    await testRunner.AndAsync("I click Next", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
                global::Reqnroll.Table table2 = new global::Reqnroll.Table(new string[] {
                            "Field",
                            "Value"});
                table2.AddRow(new string[] {
                            "Name",
                            "Cal"});
                table2.AddRow(new string[] {
                            "Email",
                            "cal@cal.com"});
                table2.AddRow(new string[] {
                            "Company",
                            "cal ng ltd"});
                table2.AddRow(new string[] {
                            "Topic description",
                            "na"});
#line 14
    await testRunner.AndAsync("I fill in the booking form with the following details:", ((string)(null)), table2, "And ");
#line hidden
#line 20
    await testRunner.AndAsync("I schedule the event", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 21
    await testRunner.ThenAsync("the booking should be confirmed", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
    }
}
#pragma warning restore
#endregion
