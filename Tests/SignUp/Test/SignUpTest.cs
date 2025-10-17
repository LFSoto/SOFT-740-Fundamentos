using AutomationPracticeDemo.Tests.Tests.SignUp.Data;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationPracticeDemo.Tests.Tests.SignUp.Test
{
    public class SignUpTest : TestBase
    {
        [Test, TestCaseSource(typeof(SignUpData), nameof(SignUpData.TestCases))]
        public void SignUpTest(SignUpData data)
        {
            
        }
    }
}