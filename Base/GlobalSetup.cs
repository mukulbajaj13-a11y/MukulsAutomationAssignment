using Microsoft.Playwright;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MukulsAutomationAssignment.Base

{
    public class GlobalSetup
    {
        protected IPlaywright _playwright;
        protected IBrowser _browser;
        protected IPage _page;

        [OneTimeSetUp]
        public async Task OneTimeStep()
        {
            _playwright = await Playwright.CreateAsync();
            _browser= await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless=false, SlowMo=500,});
        }
        [SetUp]
        public async Task Setup() { 
            var context= await _browser.NewContextAsync();
            _page= await _browser.NewPageAsync();
            await _page.GotoAsync("https://www.saucedemo.com/");
        }
        [TearDown]
        public async Task TearDown() { 
            await _page.Context.CloseAsync();
        }
        [OneTimeTearDown]
        public async Task OneTimeTearDown()
        {
            await _browser.CloseAsync();
            _playwright.Dispose();
        }
    }
}
