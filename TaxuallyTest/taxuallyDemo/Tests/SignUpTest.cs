using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;
using TaxuallyTest.taxuallyDemo.PageObjects;
using TaxuallyTest.taxuallyDemo.Base;

namespace Taxually.Tests;

public class Tests
{
    private IPlaywright? playwright;
    private IBrowser? browser;
    private IPage? page;
    private IBrowserContext? context;

    [SetUp]
    public async Task SetUp()
    {
        playwright = await Playwright.CreateAsync();
        browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
        page = await browser.NewPageAsync();
        await page.GotoAsync(Constants.BASE_URL);
        var loginPageObjects = new LoginPageObjects(page);
        string decryptedPassword = PasswordDecryptor.Decrypt(Constants.encryptedPassword);
        await loginPageObjects.LoginValidCredentials("csilla.csipak@yahoo.com", decryptedPassword);
        await page.WaitForURLAsync("https://app.taxually.com/app/signup");
        Assert.AreEqual("https://app.taxually.com/app/signup", page.Url);
    }
    [Test]
    public async Task SignUp()
    {
        {
            var signUp = new SignUpObjects(page);
            var countrySelector = new CountrySelector(page);
            var getVATNumber = new GetVATNumbers(page);
            var fillinBusinessDetailsPage = new BusinessDetailsPageObjects(page);

            await signUp.ChooseDropdown();

            int numberOfCountriesToSelect = 9; // Define the number of countries as a variable

            await countrySelector.SelectTargetCountries(numberOfCountriesToSelect);
            await page.WaitForTimeoutAsync(2000);

            // Then use the same variable to click on the corresponding number of VAT buttons
            await getVATNumber.HelpmeGetVATNumbers(numberOfCountriesToSelect);

            await page.WaitForTimeoutAsync(2000);
            await signUp.ClickonNextStepButton();

            await fillinBusinessDetailsPage.BusinessDetailPage();
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
