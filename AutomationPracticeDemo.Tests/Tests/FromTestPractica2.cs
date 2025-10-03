
using AutomationPracticeDemo.Tests.Utils;
using AutomationPracticeDemo.Tests.Pages;


namespace AutomationPracticeDemo.Tests.Tests
{
    public class FromTestPractica2 : TestBase
    {

        [Test]
        public void TestGeneralPrincipal() {

            var formpage = new FromPagePractica2(Driver);
            formpage.Frm_Complete("Yeison Rojas", "yeison@test.com", "88888888", "Alajuela", "France");
            formpage.rb_ClickGender();
            formpage.Ck_box_dia();
            formpage.drop_Color();
            formpage.drop_Animal();
            

        }
        
    }
}
