using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;
using TaxuallyTest.taxuallyDemo.PageObjects;

namespace TaxuallyTest.taxuallyDemo.PageActions
{
    public class LoginPageActions
    {
        private IPage page;
        private LoginPageObjects _loginPageObjects;

        public LoginPageActions(IPage page)
        {
            this.page = page;
            _loginPageObjects = new LoginPageObjects(page);
        }

        public async Task LoginValidCredentials(string username, string password)
        {
            await _loginPageObjects.UserName.FillAsync(username);
            await _loginPageObjects.Password.FillAsync(password);
            await _loginPageObjects.BtnLogin.ClickAsync();
        }
        public async Task AssertValidLogin()
        {
            await this.page.WaitForURLAsync("https://app.taxually.com/app/signup");
            Assert.AreEqual("https://app.taxually.com/app/signup", this.page.Url);
        }
    }
}
