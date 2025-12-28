using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MukulsAutomationAssignment.Comman
{
    public class Cart
    {
        protected IPage _page;
        public Cart(IPage page) { _page = page; }
        private ILocator _Cart => _page.Locator(".shopping_cart_link");
        public async Task ClickOnCart()
        {
            await _Cart.ClickAsync();
        }

    }
}
