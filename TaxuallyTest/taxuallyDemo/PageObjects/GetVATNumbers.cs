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
                // Click the first button that's separate from the sequence
                await _page.Locator(".col-7").First.ClickAsync();
                await _page.WaitForTimeoutAsync(1000);

                // Assume the first of the sequence is now the "next" button
                for (int i = 0; i < numberOfCountriesToSelect; i++)
                {
                    // After each click, re-evaluate the locator to get the current "first" button in the sequence
                    var nextButton = _page.Locator("app-add-country-vatnumber div.row > div.col-7 > div > button").First;

                    // Check if the button exists to avoid errors if there are fewer buttons than expected
                    if (await nextButton.IsVisibleAsync())
                    {
                        await nextButton.ClickAsync();
                        await _page.WaitForTimeoutAsync(1000);
                    }
                    else
                    {
                        Console.WriteLine($"Expected to click {numberOfCountriesToSelect} buttons, but only {i} were available.");
                        break; // Exit the loop if there are no more buttons to click
                    }
                }
            }
        }
    }
}
