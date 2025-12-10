using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MukulsAutomationAssignment.POM
{
    public class YourCartpage
    {
        private readonly IPage _page;
        private ILocator _Item => _page.Locator(".inventory_item_name");
        private ILocator _CheckoutBtn => _page.Locator("#checkout");
        public YourCartpage(IPage page) { _page = page; }

        public async Task<string> VerifyItem() { 
        string item= await _Item.InnerTextAsync();
        return item;
        }

        public async Task ClickContinue() { 
        await _CheckoutBtn.ClickAsync();
        }
    }
}
