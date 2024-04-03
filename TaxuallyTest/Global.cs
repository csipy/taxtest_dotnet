using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace TaxuallyTest
{
    public static class Global
    { public static async Task<IPage> SetupAndLoginAsync()
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
            });

            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();

            await page.GotoAsync("https://github.com/login");
            // Interact with login form
            await page.GetByLabel("Username or email address").FillAsync("username");
            await page.GetByLabel("Password").FillAsync("password");
            await page.GetByRole(AriaRole.Button, new() { Name = "Sign in" }).ClickAsync();

            await context.StorageStateAsync(new()
            {
                Path = "State\\storage.json"
            });
            return page;

         }
    }
}
