using Microsoft.Playwright;
using System.Threading.Tasks;
using TaxuallyTest.taxuallyDemo.Base;

namespace TaxuallyTest.taxuallyDemo.PageObjects
{
    public class BusinessDetailsPageObjects
    {
        private IPage _page;
        public BusinessDetailsPageObjects(IPage page)
        {
            _page = page;
        }
        public async Task BusinessDetailPage()
        {
            TestDataGenerator testDataGenerator = new TestDataGenerator();

            var LegalStatusCompanyField = _page.GetByRole(AriaRole.Combobox);
            await LegalStatusCompanyField.ClickAsync();
            await _page.WaitForSelectorAsync(".ng-option-label:text('Company')");
            await _page.ClickAsync(".ng-option-label:text('Company')");
            await _page.WaitForTimeoutAsync(1000);

            var LegalNameField = _page.Locator("#companyLegalNameOfBusiness");
            await LegalNameField.ClearAsync();
            string fullLegalName = testDataGenerator.GenerateFullLegalName();
            await LegalNameField.FillAsync(fullLegalName);
            await _page.WaitForTimeoutAsync(1000);

            var RegistrationField = _page.Locator("#companyRegistrationNumber");
            await RegistrationField.ClearAsync();
            int randomNumberGenerator = testDataGenerator.RandomNumberGenerator();
            await RegistrationField.FillAsync(randomNumberGenerator.ToString());
            await _page.WaitForTimeoutAsync(1000);

            var DatePicker = _page.Locator("#companyIncorporationDate").First;
            await DatePicker.ClickAsync();
            await _page.WaitForTimeoutAsync(1000);

            var DateToday = _page.Locator("div[role='gridcell'].ngb-dp-day.ngb-dp-today");
            await DateToday.ClickAsync();
            await _page.WaitForTimeoutAsync(1000);

            var StateField = _page.Locator("#companyState");
            await StateField.ClearAsync();
            await StateField.FillAsync("TestState");
            await _page.WaitForTimeoutAsync(1000);

            var ZIPCodeField = _page.Locator("#companyZipCode");
            await ZIPCodeField.ClearAsync();
            await ZIPCodeField.FillAsync("1097");
            await _page.WaitForTimeoutAsync(1000);

            var CityField = _page.Locator("#companyCity");
            await CityField.ClearAsync();
            await CityField.FillAsync("Budapest");
            await _page.WaitForTimeoutAsync(1000);

            var StreetField = _page.Locator("#companyStreet");
            await StreetField.ClearAsync();
            await StreetField.FillAsync("Viola");
            await _page.WaitForTimeoutAsync(1000);

            var HouseNumberField = _page.Locator("#companyHouseNumber");
            await HouseNumberField.ClearAsync();
            await HouseNumberField.FillAsync("165");
            await _page.WaitForTimeoutAsync(1000);

            var nextStepButton = _page.Locator("[data-unique-id='registration-flow-company-info_button-next-step']");
            await nextStepButton.ClickAsync();
            await _page.WaitForTimeoutAsync(1000);
        }
    }
}
