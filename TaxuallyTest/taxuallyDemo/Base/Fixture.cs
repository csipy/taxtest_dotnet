using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;
using TaxuallyTest.taxuallyDemo.PageActions;
using System;
using System.IO;

namespace TaxuallyTest.taxuallyDemo.Base
{
    public class Fixture
    {
        private static IPlaywright? playwright;
        protected static IBrowser? browser;
        protected static string? storageStatePath;

        [OneTimeSetUp]
        public static async Task GlobalSetUp()
        {
            playwright = await Playwright.CreateAsync();
            browser = await playwright.Chromium.LaunchAsync();
            var page = await browser.NewPageAsync();
            string baseUrl = TestContext.Parameters["BASE_URL_PROD"];
            await page.GotoAsync(baseUrl);

            var loginPageActions = new LoginPageActions(page);
            string decryptedPassword = PasswordDecryptor.Decrypt(Constants.encryptedPassword);
            await loginPageActions.LoginValidCredentials("csilla.csipak@yahoo.com", decryptedPassword);
            await loginPageActions.AssertValidLogin();

            storageStatePath = Path.Combine(AppContext.BaseDirectory, "storageState.json");
            await page.Context.StorageStateAsync(new BrowserContextStorageStateOptions { Path = storageStatePath });

            await page.CloseAsync();
        }

        [OneTimeTearDown]
        public async Task GlobalTearDown()
        {
            if (browser != null)
            {
                await browser.CloseAsync();
                browser = null;
            }
        }
    }
}
