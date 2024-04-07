using Microsoft.Playwright;
using System.Threading.Tasks;

namespace TaxuallyTest.taxuallyDemo.PageObjects
{
    public class LoginPageObjects
    {
        private IPage _page;
        private readonly ILocator _UserName;
        private readonly ILocator _Password;
        private readonly ILocator _btnLogin;

        public LoginPageObjects(IPage page)
        {
            _page = page;
            _UserName = _page.Locator("#email");
            _Password = _page.Locator("#password");
            _btnLogin = _page.Locator("#next");
        }
        public async Task LoginValidCredentials(string username, string password)
        {
            await _UserName.FillAsync(username);
            await _Password.FillAsync(password);
            await _btnLogin.ClickAsync();
        }
    }
}
