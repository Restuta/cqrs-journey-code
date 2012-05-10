﻿// ==============================================================================================================
// Microsoft patterns & practices
// CQRS Journey project
// ==============================================================================================================
// ©2012 Microsoft. All rights reserved. Certain content used with permission from contributors
// http://cqrsjourney.github.com/contributors/members
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance 
// with the License. You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software distributed under the License is 
// distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
// See the License for the specific language governing permissions and limitations under the License.
// ==============================================================================================================

using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;
using Conference.Specflow.Support;
using TechTalk.SpecFlow;
using WatiN.Core;
using Xunit;
using W = WatiN.Core;
using Conference.Common.Utils;
using Table = TechTalk.SpecFlow.Table;

namespace Conference.Specflow.Steps.Registration
{
    [Binding]
    public class CommonSteps
    {
        private readonly W.Browser browser;
        private ConferenceInfo conferenceInfo;

        public CommonSteps()
        {
            browser = ScenarioContext.Current.Browser();
        }

        #region Given

        [Given(@"the list of the available Order Items for the CQRS summit 2012 conference")]
        public void GivenTheListOfTheAvailableOrderItemsForTheCqrsSummit2012Conference(Table table)
        {
            // Populate Conference data
            conferenceInfo = ConferenceHelper.PopulateConfereceData(table, HandleGenerator.Generate(10));

            // Store for being used by external step classes
            ScenarioContext.Current.Set(conferenceInfo);
        }

        [Given(@"the selected Order Items")]
        public void GivenTheSelectedOrderItems(Table table)
        {
            SelectOrderItems(browser, conferenceInfo, table);
        }

        [Given(@"the Registrant enter these details")]
        public void GivenTheRegistrantEnterTheseDetails(Table table)
        {
            browser.SetInput("FirstName", table.Rows[0]["first name"]);
            browser.SetInput("LastName", table.Rows[0]["last name"]);
            browser.SetInput("Email", table.Rows[0]["email address"]);
            browser.SetInput("data-val-required", table.Rows[0]["email address"], "Please confirm the e-mail address.");

            // Store email in case is needed for later use (Find Order by Code + email access)
            ScenarioContext.Current.Set(table.Rows[0]["email address"], "email");
        }

        [Given(@"these Seat Types becomes unavailable before the Registrant make the reservation")]
        public void GivenTheseSeatTypesBecomesUnavailableBeforeTheRegistrantMakeTheReservation(Table table)
        {
            ConferenceHelper.ReserveSeats(conferenceInfo, table);
        }

        [Given(@"the Registrant proceed to make the Reservation")]
        public void GivenTheRegistrantProceedToMakeTheReservation()
        {
            MakeTheReservation(browser);
        }

        [Given(@"the Registrant proceed to make the Reservation with seats already reserved")]
        public void GivenTheRegistrantProceedToMakeTheReservationWithSeatsAlreadyReserved()
        {
            MakeTheReservationWithSeatsAlreadyReserved(browser);
         }

        [Given(@"the Registrant proceed to Checkout:Payment")]
        public void GivenTheRegistrantProceedToCheckoutPayment()
        {
            TheRegistrantProceedToCheckoutPayment();
        }

        [Given(@"the total should read \$(.*)")]
        public void GivenTheTotalShouldRead(int value)
        {
            TheTotalShouldRead(value);
        }

        [Given(@"the message '(.*)' will show up")]
        public void GivenTheMessageWillShowUp(string message)
        {
            TheMessageWillShowUp(message);
        }

        [Given(@"the Order should be created with the following Order Items")]
        public void GivenTheOrderShouldBeCreatedWithTheFollowingOrderItems(Table table)
        {
            TheOrderShouldBeCreatedWithTheFollowingOrderItems(table);
        }

        [Given(@"the Registrant proceed to confirm the payment")]
        public void GivenTheRegistrantProceedToConfirmThePayment()
        {
            TheRegistrantProceedToConfirmThePayment();
        }

        [Given(@"the Registration process was successful")]
        public void GivenTheRegistrationProcessWasSuccessful()
        {
            TheRegistrationProcessWasSuccessful();
        }

        #endregion

        #region When

        [When(@"the Registrant proceed to make the Reservation")]
        public void WhenTheRegistrantProceedToMakeTheReservation()
        {
            MakeTheReservation(browser);
        }

        [When(@"the Registrant proceed to make the Reservation with seats already reserved")]
        public void WhenTheRegistrantProceedToMakeTheReservationWithSeatsAlreadyReserved()
        {
            MakeTheReservationWithSeatsAlreadyReserved(browser);
        }

        [When(@"the Registrant proceed to Checkout:Payment")]
        public void WhenTheRegistrantProceedToCheckoutPayment()
        {
            TheRegistrantProceedToCheckoutPayment();
        }

        [When(@"the Registrant proceed to confirm the payment")]
        public void WhenTheRegistrantProceedToConfirmThePayment()
        {
            TheRegistrantProceedToConfirmThePayment();
        }

        #endregion

        #region Then

        [Then(@"the Reservation is confirmed for all the selected Order Items")]
        public void ThenTheReservationIsConfirmedForAllTheSelectedOrderItems()
        {
            ReservationConfirmed(browser);
        }

        [Then(@"the countdown started")]
        public void ThenTheCountdownStarted()
        {
            var countdown = ScenarioContext.Current.Get<W.Browser>().Div("countdown_time").Text;

            Assert.False(string.IsNullOrWhiteSpace(countdown));
            var countdownTime = TimeSpan.ParseExact(countdown, @"mm\:ss", CultureInfo.InvariantCulture);
            Assert.True(countdownTime.Minutes > 0 && countdownTime.Minutes < 15);
        }

        [Then(@"the payment options should be offered for a total of \$(.*)")]
        public void ThenThePaymentOptionsShouldBeOfferedForATotalOf(int value)
        {
            Assert.True(browser.SafeContainsText(value.ToString(CultureInfo.InvariantCulture)),
                string.Format("The following text was not found on the page: {0}", value));
        }

        [Then(@"these seats are assigned")]
        public void ThenTheseSeatsAreAssigned(Table table)
        {
            TheseOrderItemsShouldBeReserved(table);
        }

        [Then(@"these Order Items should be reserved")]
        public void ThenTheseOrderItemsShouldBeReserved(Table table)
        {
            TheseOrderItemsShouldBeReserved(table);
        }

        [Then(@"these Order Items should not be reserved")]
        public void ThenTheseOrderItemsShouldNotBeReserved(Table table)
        {
            foreach (var row in table.Rows)
            {
                Assert.False(browser.ContainsValueInTableRow(row["seat type"], ""),
                    string.Format("The following text was not found on the page: {0}", row["seat type"]));
            }
        }

        [Then(@"the total should read \$(.*)")]
        public void ThenTheTotalShouldRead(int value)
        {
            TheTotalShouldRead(value);
        }

        [Then(@"the message '(.*)' will show up")]
        public void ThenTheMessageWillShowUp(string message)
        {
            TheMessageWillShowUp(message);
        }

        [Then(@"the Order should be created with the following Order Items")]
        public void ThenTheOrderShouldBeCreatedWithTheFollowingOrderItems(Table table)
        {
            TheOrderShouldBeCreatedWithTheFollowingOrderItems(table);
        }

        [Then(@"the Registration process was successful")]
        public void ThenTheRegistrationProcessWasSuccessful()
        {
            TheRegistrationProcessWasSuccessful();
        }

        #endregion

        #region Common code

        internal static void SelectOrderItems(Browser browser, ConferenceInfo conferenceInfo, Table table)
        {
            // Navigate to Registration page
            browser.GoTo(Constants.RegistrationPage(conferenceInfo.Slug));

            foreach (var row in table.Rows)
            {
                browser.SelectListInTableRow(row["seat type"], row["quantity"]);
            }
        }

        internal static void ReservationConfirmed(Browser browser)
        {
            Assert.True(browser.SafeContainsText(Constants.UI.ReservationSuccessfull),
                string.Format("The following text was not found on the page: {0}", Constants.UI.ReservationSuccessfull));
        }

        private void TheRegistrationProcessWasSuccessful()
        {
            browser.WaitUntilContainsText(Constants.UI.RegistrationSuccessfull, Constants.UI.WaitTimeout.Seconds);
        }

        private void TheseOrderItemsShouldBeReserved(Table table)
        {
            foreach (var row in table.Rows)
            {
                Assert.True(browser.ContainsValueInTableRow(row["seat type"], row["quantity"]),
                    string.Format("The following text was not found on the page: {0} or {1}", row["seat type"], row["quantity"]));
            }
        }

        private void TheRegistrantProceedToConfirmThePayment()
        {
            browser.Click(Constants.UI.AcceptPaymentInputValue);
        }

        private void TheOrderShouldBeCreatedWithTheFollowingOrderItems(Table table)
        {
            // Check id the access code was created
            string accessCode = browser.FindText(new Regex("[A-Z0-9]{6}"));
            Assert.False(string.IsNullOrWhiteSpace(accessCode), "Access Code with pattern '[A-Z0-9]{6}' not found");

            //TODO: Remove after fix
            // Wait for order events to be digested. 
            Thread.Sleep(Constants.WaitTimeout);

            // Navigate to the Seat Assignement page
            browser.Click(Constants.UI.ProceedToSeatAssignementId);

            TheseOrderItemsShouldBeReserved(table);
        }

        private void TheMessageWillShowUp(string message)
        {
            Assert.True(browser.SafeContainsText(message),
                string.Format("The following text was not found on the page: {0}", message));
        }

        private void TheTotalShouldRead(int value)
        {
            Assert.True(browser.SafeContainsText(value.ToString(CultureInfo.InvariantCulture)),
                string.Format("The following text was not found on the page: {0}", value));
        }

        internal static void MakeTheReservation(Browser browser)
        {
            browser.ClickAndWait(Constants.UI.NextStepId, Constants.UI.ReservationSuccessfull);
        }

        internal static void MakeTheReservationWithSeatsAlreadyReserved(Browser browser)
        {
            browser.ClickAndWait(Constants.UI.NextStepId, Constants.UI.ReservationUnsuccessfull);
        }

        public void TheRegistrantProceedToCheckoutPayment()
        {
            browser.Click(Constants.UI.NextStepId);
        }

        #endregion
    }
}
