using System.Threading.Tasks;
using NUnit.Framework;
using Microsoft.Playwright;

namespace TaxuallyTest
{
    public class PlaywrightTests
    {
        private IPlaywright _playwright;
        private IBrowser _browser;
        private IPage _page;
        private IBrowserContext _context;

        [SetUp]
        public async Task Setup()
        {
            Global.SetupAndLoginAsync();
            var context = await browser.NewContextAsync(new()
            {
                StorageStatePath = "state.json"
            });
            //_playwright = await Playwright.CreateAsync();
            //_browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            //{
            //    Headless = false
            //});
            //_context = await browser.NewContextAsync(new()
            //{
            //    StorageStatePath = "State\\storage.json"
            //});
            //_page = await _browser.NewPageAsync();
        }

        [Test]
        public async Task ExampleTest()
        {
            await _page.GotoAsync("https://example.com");
            var title = await _page.TitleAsync();
            Assert.AreEqual("Example Domain", title);
        }
        [TearDown]
        public async Task TearDown()
        {
            await _browser.CloseAsync();
            _playwright.Dispose();
        }
    }
}