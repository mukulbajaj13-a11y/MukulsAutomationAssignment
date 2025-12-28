using Microsoft.Playwright;
using MukulsAutomationAssignment.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MukulsAutomationAssignment.POM
{
    public class ProductsPage:Cart
    {
        private readonly IPage _page;
        private ILocator _AddBtn => _page.Locator(".btn.btn_primary.btn_small.btn_inventory ");
        private ILocator _RemoveBtn => _page.Locator(".btn.btn_secondary.btn_small.btn_inventory");
        private ILocator _CartbagCount => _page.Locator(".shopping_cart_badge");
        private ILocator _itemsName => _page.Locator(".inventory_item_name");

        public ProductsPage(IPage page):base (page)
        {
            _page = page;
        }

        public async Task AddtoCart(string Item1,string item2,string item3) {

            int itemsCount = await _itemsName.CountAsync();
            for (int i = 0; i < itemsCount; i++) {
                string CurrenItem=await _itemsName.Nth(i).InnerTextAsync();
                if (CurrenItem==Item1 || CurrenItem==item2 || CurrenItem==item3) {
                    await _AddBtn.Nth(i).ClickAsync();
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
                for (int i = (ItemsAdd - 1); i > 0; i--)
                {
                    await _RemoveBtn.Nth(i).ClickAsync();
                }
            }
            else {
                throw new Exception("Items in cart are leass than one or no product is in the cart");
            }

        }
        

    }
}
