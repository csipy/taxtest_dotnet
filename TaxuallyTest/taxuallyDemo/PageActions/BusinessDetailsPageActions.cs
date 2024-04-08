using TaxuallyTest.taxuallyDemo.Base;
using TaxuallyTest.taxuallyDemo.PageObjects;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace TaxuallyTest.taxuallyDemo.PageActions
{
    public class BusinessDetailsPageActions
    {
        private BusinessDetailsPageObjects _pageObjects;
        private IPage _page;

        public BusinessDetailsPageActions(BusinessDetailsPageObjects pageObjects, IPage page)
        {
            _pageObjects = pageObjects;
            _page = page;
        }

        public async Task SelectLegalStatusAsCompany()
        {
            await _pageObjects.LegalStatusCompanyField.ClickAsync();
            await _page.WaitForSelectorAsync(".ng-option-label:text('Company')");
            await _page.ClickAsync(".ng-option-label:text('Company')");
            await _page.WaitForTimeoutAsync(1000);
        }

        public async Task FillBusinessDetails()
        {
            TestDataGenerator testDataGenerator = new TestDataGenerator();

            await _pageObjects.LegalNameField.FillAsync(testDataGenerator.GenerateFullLegalName());
            await _pageObjects.RegistrationField.FillAsync(testDataGenerator.RandomNumberGenerator().ToString());
            await _pageObjects.DatePicker.ClickAsync();
            await _pageObjects.DateToday.ClickAsync();
            await _pageObjects.StateField.FillAsync("TestState");
            await _pageObjects.ZIPCodeField.FillAsync("1097");
            await _pageObjects.CityField.FillAsync("Budapest");
            await _pageObjects.StreetField.FillAsync("Viola");
            await _pageObjects.HouseNumberField.FillAsync("165");
            await _pageObjects.NextStepButton.ClickAsync();
        }
    }
}
