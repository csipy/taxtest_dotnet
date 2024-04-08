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
        public ILocator LegalStatusCompanyField => _page.GetByRole(AriaRole.Combobox);
        public ILocator LegalNameField => _page.Locator("#companyLegalNameOfBusiness");
        public ILocator RegistrationField => _page.Locator("#companyRegistrationNumber");
        public ILocator DatePicker => _page.Locator("#companyIncorporationDate").First;
        public ILocator DateToday => _page.Locator("div[role='gridcell'].ngb-dp-day.ngb-dp-today");
        public ILocator StateField => _page.Locator("#companyState");
        public ILocator ZIPCodeField => _page.Locator("#companyZipCode");
        public ILocator CityField => _page.Locator("#companyCity");
        public ILocator StreetField => _page.Locator("#companyStreet");
        public ILocator HouseNumberField => _page.Locator("#companyHouseNumber");
        public ILocator NextStepButton => _page.Locator("[data-unique-id='registration-flow-company-info_button-next-step']");
    }
}
