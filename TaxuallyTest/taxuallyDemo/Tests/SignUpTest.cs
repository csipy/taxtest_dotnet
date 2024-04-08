using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;
using TaxuallyTest.taxuallyDemo.Base;
using TaxuallyTest.taxuallyDemo.PageActions;
using TaxuallyTest.taxuallyDemo.PageObjects;

namespace Taxually.Tests;

public class Tests
{
    private IPlaywright? playwright;
    private IBrowser? browser;
    private IPage? page;

    [SetUp]
    public async Task SetUp()
    {
        playwright = await Playwright.CreateAsync();
        browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
        page = await browser.NewPageAsync();
        string baseUrl = TestContext.Parameters["BASE_URL_PROD"];
        await page.GotoAsync(baseUrl);

        var loginPageActions = new LoginPageActions(page);
        string decryptedPassword = PasswordDecryptor.Decrypt(Constants.encryptedPassword);
        await loginPageActions.LoginValidCredentials("csilla.csipak@yahoo.com", decryptedPassword);
        await loginPageActions.AssertValidLogin();
    }
    [Test]
    public async Task SignUp()
    {
        {
            var businessDetailsPageObjects = new BusinessDetailsPageObjects(page);
            var businessDetailsPageActions = new BusinessDetailsPageActions(businessDetailsPageObjects, page);
            var signUp = new SignUpObjects(page);
            var countrySelector = new CountrySelector(page);
            var getVATNumber = new GetVATNumbers(page);

            await signUp.ChooseDropdown();

            int numberOfCountriesToSelect = 3; // Define the number of countries as a variable

            await countrySelector.SelectTargetCountries(numberOfCountriesToSelect);
            await page.WaitForTimeoutAsync(2000);

            // Then use the same variable to click on the corresponding number of VAT buttons
            await getVATNumber.HelpmeGetVATNumbers(numberOfCountriesToSelect);

            await page.WaitForTimeoutAsync(2000);
            await signUp.ClickonNextStepButton();
            await businessDetailsPageActions.SelectLegalStatusAsCompany();
            await businessDetailsPageActions.FillBusinessDetails();
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
