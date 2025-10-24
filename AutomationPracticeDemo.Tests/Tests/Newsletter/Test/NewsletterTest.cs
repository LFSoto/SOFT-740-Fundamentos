using AutomationPracticeDemo.Tests.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPracticeDemo.Tests.Tests.Newsletter.Test
{
    public class NewsletterTest:TestBase
    {
        [Test]
        public void NewsletterSubscriptionTest()
        {
            var page = new Pages.NewsletterSection(Driver);
            var email = "SOFT-740@cenfotec.com";
            page.Subscribe(email);
            ScreenshotHelper.TakeScreenshot(Driver, "NewsletterSubscription.png");
            var successMessage = page.GetSubscribeMessage();
            Assert.That(successMessage, Does.Contain("You have been successfully subscribed!"));
        }
    }
}
