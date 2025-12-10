using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MukulsAutomationAssignment.Page
{
    public class CheckoutOverview
    {
        private readonly IPage _page;
        private ILocator _ItemName => _page.Locator(".inventory_item_name");
        private ILocator _FinishBtn => _page.Locator("#finish");
        public CheckoutOverview(IPage page) { _page = page; }

        public async Task<string> VerifyItem() {
            string itemname = await _ItemName.InnerTextAsync();
            return itemname;
        }
        public async Task ClickFinish() {
            await _FinishBtn.ClickAsync();
        }
    }
}
