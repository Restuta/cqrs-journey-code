﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.8.1.0
//      SpecFlow Generator Version:1.8.0.0
//      Runtime Version:4.0.30319.269
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Conference.Specflow.Features.UserInterface.Views.Registration
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.8.1.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class SelfRegistrantEndToEndScenarioForMakingARegistrationForAConferenceSadPathFeature : Xunit.IUseFixture<SelfRegistrantEndToEndScenarioForMakingARegistrationForAConferenceSadPathFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "SelfRegistrationEndToEndSad.feature"
#line hidden
        
        public SelfRegistrantEndToEndScenarioForMakingARegistrationForAConferenceSadPathFeature()
        {
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Self Registrant end to end scenario for making a Registration for a Conference (s" +
                    "ad path)", "In order to register for a conference\r\nAs an Attendee\r\nI want to be able to regis" +
                    "ter for the conference, pay for the Registration Order and associate myself with" +
                    " the paid Order automatically", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 19
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "seat type",
                        "rate",
                        "quota"});
            table1.AddRow(new string[] {
                        "General admission",
                        "$199",
                        "10"});
            table1.AddRow(new string[] {
                        "CQRS Workshop",
                        "$500",
                        "10"});
            table1.AddRow(new string[] {
                        "Additional cocktail party",
                        "$50",
                        "10"});
#line 20
 testRunner.Given("the list of the available Order Items for the CQRS summit 2012 conference", ((string)(null)), table1);
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "seat type",
                        "quantity"});
            table2.AddRow(new string[] {
                        "General admission",
                        "1"});
            table2.AddRow(new string[] {
                        "CQRS Workshop",
                        "1"});
            table2.AddRow(new string[] {
                        "Additional cocktail party",
                        "1"});
#line 25
 testRunner.And("the selected Order Items", ((string)(null)), table2);
#line hidden
        }
        
        public virtual void SetFixture(SelfRegistrantEndToEndScenarioForMakingARegistrationForAConferenceSadPathFeature.FixtureData fixtureData)
        {
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Self Registrant end to end scenario for making a Registration for a Conference (s" +
            "ad path)")]
        [Xunit.TraitAttribute("Description", "No selected Seat Type")]
        public virtual void NoSelectedSeatType()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("No selected Seat Type", ((string[])(null)));
#line 32
this.ScenarioSetup(scenarioInfo);
#line 19
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "seat type",
                        "quantity"});
            table3.AddRow(new string[] {
                        "General admission",
                        "0"});
            table3.AddRow(new string[] {
                        "CQRS Workshop",
                        "0"});
            table3.AddRow(new string[] {
                        "Additional cocktail party",
                        "0"});
#line 33
 testRunner.Given("the selected Order Items", ((string)(null)), table3);
#line 38
 testRunner.When("the Registrant proceed to make the Reservation with no selected seats");
#line 39
 testRunner.Then("the message \'One or more items are required\' will show up");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Self Registrant end to end scenario for making a Registration for a Conference (s" +
            "ad path)")]
        [Xunit.TraitAttribute("Description", "All Seat Types are available, one get reserved and two get waitlisted")]
        public virtual void AllSeatTypesAreAvailableOneGetReservedAndTwoGetWaitlisted()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("All Seat Types are available, one get reserved and two get waitlisted", ((string[])(null)));
#line 44
this.ScenarioSetup(scenarioInfo);
#line 19
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "seat type"});
            table4.AddRow(new string[] {
                        "CQRS Workshop"});
            table4.AddRow(new string[] {
                        "Additional cocktail party"});
#line 45
 testRunner.Given("these Seat Types becomes unavailable before the Registrant make the reservation", ((string)(null)), table4);
#line 49
 testRunner.When("the Registrant proceed to make the Reservation with seats already reserved");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "seat type",
                        "selected",
                        "message"});
            table5.AddRow(new string[] {
                        "CQRS Workshop",
                        "",
                        "Sold out"});
            table5.AddRow(new string[] {
                        "Additional cocktail party",
                        "",
                        "Sold out"});
#line 50
 testRunner.Then("the Registrant is offered to select any of these available seats", ((string)(null)), table5);
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "seat type",
                        "quantity"});
            table6.AddRow(new string[] {
                        "General admission",
                        "1"});
#line 54
 testRunner.And("the selected Order Items", ((string)(null)), table6);
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "seat type",
                        "quantity"});
            table7.AddRow(new string[] {
                        "General admission",
                        "1"});
#line 57
 testRunner.And("these Order Items should be reserved", ((string)(null)), table7);
#line 60
 testRunner.And("the total should read $199");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Self Registrant end to end scenario for making a Registration for a Conference (s" +
            "ad path)")]
        [Xunit.TraitAttribute("Description", "Checkout:Registrant Invalid Details")]
        public virtual void CheckoutRegistrantInvalidDetails()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Checkout:Registrant Invalid Details", ((string[])(null)));
#line 63
this.ScenarioSetup(scenarioInfo);
#line 19
this.FeatureBackground();
#line 64
 testRunner.Given("the Registrant proceed to make the Reservation");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "first name",
                        "last name",
                        "email address"});
            table8.AddRow(new string[] {
                        "William",
                        "",
                        "william@invalid"});
#line 65
 testRunner.And("the Registrant enter these details", ((string)(null)), table8);
#line 68
 testRunner.When("the Registrant proceed to Checkout:NoPayment");
#line 69
 testRunner.Then("the error message for \'LastName\' with value \'The LastName field is required.\' wil" +
                    "l show up");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Self Registrant end to end scenario for making a Registration for a Conference (s" +
            "ad path)")]
        [Xunit.TraitAttribute("Description", "Checkout:Payment with cancellation")]
        public virtual void CheckoutPaymentWithCancellation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Checkout:Payment with cancellation", ((string[])(null)));
#line 72
this.ScenarioSetup(scenarioInfo);
#line 19
this.FeatureBackground();
#line 73
 testRunner.Given("the Registrant proceed to make the Reservation");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "first name",
                        "last name",
                        "email address"});
            table9.AddRow(new string[] {
                        "William",
                        "Flash",
                        "william@fabrikam.com"});
#line 74
 testRunner.And("the Registrant enter these details", ((string)(null)), table9);
#line 77
 testRunner.And("the Registrant proceed to Checkout:Payment");
#line 78
 testRunner.When("the Registrant proceed to cancel the payment");
#line 79
    testRunner.Then("the payment selection page will show up");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Self Registrant end to end scenario for making a Registration for a Conference (s" +
            "ad path)")]
        [Xunit.TraitAttribute("Description", "Partiall Seats allocation")]
        public virtual void PartiallSeatsAllocation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Partiall Seats allocation", ((string[])(null)));
#line 82
this.ScenarioSetup(scenarioInfo);
#line 19
this.FeatureBackground();
#line 83
 testRunner.Given("the Registrant proceed to make the Reservation");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "first name",
                        "last name",
                        "email address"});
            table10.AddRow(new string[] {
                        "William",
                        "Flash",
                        "william@fabrikam.com"});
#line 84
 testRunner.And("the Registrant enter these details", ((string)(null)), table10);
#line 87
 testRunner.And("the Registrant proceed to Checkout:Payment");
#line 88
 testRunner.And("the Registrant proceed to confirm the payment");
#line 89
    testRunner.And("the Registration process was successful");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "seat type",
                        "quantity"});
            table11.AddRow(new string[] {
                        "General admission",
                        "1"});
            table11.AddRow(new string[] {
                        "CQRS Workshop",
                        "1"});
            table11.AddRow(new string[] {
                        "Additional cocktail party",
                        "1"});
#line 90
 testRunner.And("the Order should be created with the following Order Items", ((string)(null)), table11);
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "seat type",
                        "first name",
                        "last name",
                        "email address"});
            table12.AddRow(new string[] {
                        "General admission",
                        "William",
                        "Flash",
                        "william@fabrikam.com"});
            table12.AddRow(new string[] {
                        "Additional cocktail party",
                        "Jon",
                        "Jaffe",
                        "jon@fabrikam.com"});
#line 95
 testRunner.When("the Registrant assign these seats", ((string)(null)), table12);
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "seat type",
                        "quantity"});
            table13.AddRow(new string[] {
                        "General admission",
                        "1"});
            table13.AddRow(new string[] {
                        "Additional cocktail party",
                        "1"});
#line 99
 testRunner.Then("these seats are assigned", ((string)(null)), table13);
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.8.1.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                SelfRegistrantEndToEndScenarioForMakingARegistrationForAConferenceSadPathFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                SelfRegistrantEndToEndScenarioForMakingARegistrationForAConferenceSadPathFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
