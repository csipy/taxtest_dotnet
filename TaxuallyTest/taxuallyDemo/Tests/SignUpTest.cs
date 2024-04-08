using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;
using TaxuallyTest.taxuallyDemo.Base;
using TaxuallyTest.taxuallyDemo.PageActions;
using TaxuallyTest.taxuallyDemo.PageObjects;
using System;

namespace Taxually.Tests;

[TestFixture]
public class SignUpTest : Fixture
{
    private IPage? page;
    private IBrowserContext? context;

    [SetUp]
    public async Task SetUp()
    {
        if (browser == null) throw new InvalidOperationException("Browser not initialized");
        if (string.IsNullOrEmpty(storageStatePath)) throw new InvalidOperationException("Storage state path is not available");

        context = await browser.NewContextAsync(new BrowserNewContextOptions { StorageStatePath = storageStatePath });
        page = await context.NewPageAsync();

        string baseUrl = TestContext.Parameters["BASE_URL_PROD"];
        await page.GotoAsync(baseUrl);
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
}
