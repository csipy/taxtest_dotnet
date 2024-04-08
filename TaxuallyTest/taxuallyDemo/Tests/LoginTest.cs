using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;
using TaxuallyTest.taxuallyDemo.Base;
using TaxuallyTest.taxuallyDemo.PageActions;

namespace Taxually.Tests;

[TestFixture]
public class LoginTest
{
    private IPlaywright? playwright;
    private IBrowser? browser;
    private IPage? page;

    [SetUp]
    public async Task SetUp()
    {
        playwright = await Playwright.CreateAsync();
        browser = await playwright.Chromium.LaunchAsync();
        var context = await browser.NewContextAsync();
        page = await context.NewPageAsync();

        string baseUrl = TestContext.Parameters["BASE_URL_PROD"];
        await page.GotoAsync(baseUrl);
    }
    [Test]
    public async Task ValidLoginTest()
    {
        {
            var loginPageActions = new LoginPageActions(page);
            string decryptedPassword = PasswordDecryptor.Decrypt(Constants.encryptedPassword);
            await loginPageActions.LoginValidCredentials("csilla.csipak@yahoo.com", decryptedPassword);
            await loginPageActions.AssertValidLogin();
        }
    }
    [TearDown]
    public async Task TearDown()
    {
        if (browser != null)
        {
            await browser.CloseAsync();
            browser = null;
        }
    }
}
