using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

namespace TaxuallyTest.taxuallyDemo.Base
{
    public class CountrySelector
    {
        private IPage _page;

        public CountrySelector(IPage page)
        {
            _page = page;
        }
        public async Task SelectTargetCountries(int numberOfCountriesToSelect)
        {
            const int maxNumberOfCountries = 9;
            numberOfCountriesToSelect = Math.Min(numberOfCountriesToSelect, maxNumberOfCountries);
            var countryButtons = _page.Locator("div.row:first-of-type > div > button");
            var countryButtonCount = await countryButtons.CountAsync();

            Console.WriteLine($"Number of country buttons in the first row: {countryButtonCount}");

            int buttonsToClick = Math.Min(numberOfCountriesToSelect, countryButtonCount);
            for (int i = 0; i < buttonsToClick; i++)
            {
                    await countryButtons.Nth(i).ClickAsync();
                    await _page.WaitForTimeoutAsync(1000);
            }
        }

    }
}
