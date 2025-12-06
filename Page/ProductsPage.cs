using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MukulsAutomationAssignment.POM
{
    public class ProductsPage
    {
        private IPage _page;
        private ILocator _AddBtn => _page.Locator(".btn.btn_primary.btn_small.btn_inventory ");
        private ILocator _RemoveBtn => _page.Locator(".btn.btn_secondary.btn_small.btn_inventory");
        private ILocator _CartbagCount => _page.Locator(".shopping_cart_badge");
        private ILocator _itemsName => _page.Locator(".inventory_item_name");

        private ILocator _Cart => _page.Locator(".shopping_cart_link");
        public ProductsPage(IPage page)
        {
            _page = page;
        }

        public async Task AddtoCart(string Item1,string item2) {

            int itemsCount = await _itemsName.CountAsync();
            for (int i = 0; i < itemsCount; i++) {
                string CurrenItem=await _itemsName.Nth(i).InnerTextAsync();
                if (CurrenItem==Item1 || CurrenItem==item2) {
                    await _AddBtn.Nth(i).ClickAsync();
                    continue;
                }
            }
        }

        public async Task<int> CartCount() { 
            int count= int.Parse(await _CartbagCount.InnerTextAsync());
            return count;
        }

        public async Task RemoveItem()
        {
            int ItemsAdd = await _RemoveBtn.CountAsync();
            if (ItemsAdd > 1)
            {
                await _RemoveBtn.Nth(1).ClickAsync();
            }
            else {
                throw new Exception("There are no items added to cart");
            }
        }
        public async Task ClickOnCart() {
            await _Cart.ClickAsync();
        }

    }
}
