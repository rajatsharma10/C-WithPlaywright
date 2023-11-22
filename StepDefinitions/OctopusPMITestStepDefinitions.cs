using OctopusPMI.Pages;
using SpecFlowOctopusPMI.Drivers;
using System;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using static System.Net.WebRequestMethods;

namespace SpecFlowOctopusPMI.StepDefinitions
{
    [Binding]
    public class OctopusPMITestStepDefinitions
    {

        public readonly LoginPage _loginpage;
        public readonly Driver _driver;

        public OctopusPMITestStepDefinitions(Driver driver)
        {
            _driver = driver;
            _loginpage = new LoginPage(_driver.Page);

        }

        [Given(@"navigate to application")]
        public   void  GivenNavigateToApplication()
        {
           _driver.Page.GotoAsync(url: "https://dev.octopuspmi.com/login");
        }


        [Given(@"login & enter username and password")]
        public async Task GivenLoginEnterUsernameAndPassword(Table table)
        {
               dynamic data = table.CreateDynamicInstance();
              //await _loginpage.LoginwithCrediantals((string)data.UserName, (string)data.Password);
               await _loginpage.LoginwithCrediantals(UserName: "testuser", Password: "123");
               await _driver.Page.WaitForTimeoutAsync(5000);
        }
         
    }

}
