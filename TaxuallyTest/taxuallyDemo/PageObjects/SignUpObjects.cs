using Microsoft.Playwright;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TaxuallyTest.taxuallyDemo.PageObjects
{
    public class SignUpObjects
    {
        private IPage _page;

        public SignUpObjects(IPage page)
        {
            _page = page;
        }
        public async Task ChooseDropdown()
        {
            await _page.GetByRole(AriaRole.Combobox).GetByRole(AriaRole.Textbox).ClickAsync();
            await _page.GetByRole(AriaRole.Option, new() { Name = "Croatia" }).ClickAsync();
        }
        public async Task ClickonNextStepButton()
        {
            var nextStepButton =_page.Locator("[data-unique-id='payment-service-subscriptions_button-next-step']");
            await nextStepButton.ClickAsync();
            await _page.WaitForTimeoutAsync(2000);

            bool completedStepHeader = await _page.Locator(".step__header.completed").IsVisibleAsync();
            Assert.AreEqual(completedStepHeader, true);
        }
    }
}
