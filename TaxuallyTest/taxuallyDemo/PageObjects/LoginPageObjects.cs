using Microsoft.Playwright;

namespace TaxuallyTest.taxuallyDemo.PageObjects
{
    public class LoginPageObjects
    {
        private IPage _page;
        public ILocator UserName => _page.Locator("#email");
        public ILocator Password => _page.Locator("#password");
        public ILocator BtnLogin => _page.Locator("#next");

        public LoginPageObjects(IPage page)
        {
            _page = page;
        }
    }
}
