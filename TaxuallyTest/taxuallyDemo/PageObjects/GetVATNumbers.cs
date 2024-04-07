using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace TaxuallyTest.taxuallyDemo.PageObjects
{
    public class GetVATNumbers
    {
        private IPage _page;

        public GetVATNumbers(IPage page)
        {
            _page = page;
        }
        public async Task HelpmeGetVATNumbers(int numberOfCountriesToSelect)
        {
            {
                await _page.Locator(".col-7").First.ClickAsync();
                await _page.WaitForTimeoutAsync(1000);

                for (int i = 0; i < numberOfCountriesToSelect; i++)
                {
                    var nextButton = _page.Locator("app-add-country-vatnumber div.row > div.col-7 > div > button").First;

                    if (await nextButton.IsVisibleAsync())
                    {
                        await nextButton.ClickAsync();
                        await _page.WaitForTimeoutAsync(1000);
                    }
                    else
                    {
                        Console.WriteLine($"Expected to click {numberOfCountriesToSelect} buttons, but only {i} were available.");
                        break;
                    }
                }
            }
        }
    }
}
