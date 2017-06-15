using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Digital.ComponentHelper;
using Digital.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Digital.StepDefinition
{
    [Binding]
    public sealed class QueryAPISteps
    {
        string actualAddress = null;

        [Given(@"I want to query the '(.*)' API")]
        public void GivenIWantToQueryTheAPI(string endpointURL)
        {
            //This will call the given API and return the response.
            //Then it puts one of the fields from the response so that you can check
            //the value when debugging.

            Account response = APIHelper.HTTPGetRequestDeserialize(endpointURL);
                                         

            //Account response = APIHelper.HTTPGetRequest(endpointURL);
            actualAddress = response.ClientAddress;
        }

        [Then(@"Address returned correctly")]
        public void ThenAddressReturnedCorrectly()
        {
            string expectedAddress = "4a Green End,Braughing,Ware,Hertfordshire,SP11 0LL";
            Assert.AreEqual(expectedAddress, actualAddress, "compare using are equal");
        }



    }
}
