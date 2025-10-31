using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AutomationPracticeDemo.Tests.StepDefinitions.Login
{
    public class LoginSteps
    {
        [Given("")]
        public void NavigateTo(string page) {
            //Code to navigate to the any page
            if (page == "Login") { 
                //Navigate to Login page
            }
        }
    }
}
