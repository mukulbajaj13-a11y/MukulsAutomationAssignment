using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MukulsAutomationAssignment.Page
{
    public class CheckoutComplete
    {
        private IPage _page;
        private ILocator _ConfirmMsg => _page.Locator(".complete-header");
        private ILocator _DispatachMsg => _page.Locator(".complete-text");
        public CheckoutComplete(IPage page) { _page = page; }
        public async Task<string> ConfirmText() {
            string msg = await _ConfirmMsg.InnerTextAsync();
            return msg;
        }
        public async Task<string> DispatchMsg() {
            string msg = await _DispatachMsg.InnerTextAsync();
            return msg;
        }
    }
}
