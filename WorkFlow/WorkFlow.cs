using MukulsAutomationAssignment.Base;
using MukulsAutomationAssignment.Page;
using MukulsAutomationAssignment.POM;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MukulsAutomationAssignment.WorkFlow
{
   
    public class WorkFlow : GlobalSetup
    {
        [Test]
        public async Task TestWorkFlow(){
            LoginPage lp = new LoginPage(_page);
            await lp.login();
            ProductsPage pp= new ProductsPage(_page);
            await pp.AddtoCart("Sauce Labs Backpack", "Sauce Labs Bike Light", "Sauce Labs Bolt T-Shirt");
            int CartCount= await pp.CartCount();
            Assert.That(CartCount, Is.EqualTo(3), "Cart count mismatch after adding items");
            await pp.RemoveItem();
            int CartCountAfterRemoved= await pp.CartCount();
            Assert.That(CartCountAfterRemoved, Is.EqualTo(1), "Cart count mismatch after removing items");
            await pp.ClickOnCart();
            YourCartpage yp= new YourCartpage(_page);
            string itemName= await yp.VerifyItem();
            Assert.That(itemName, Is.EqualTo("Sauce Labs Backpack"), "Wrong item displayed in cart");
            await yp.ClickContinue();
            CheckoutYourInfoPage cp= new CheckoutYourInfoPage(_page);
            await cp.FillDetails("Mukul", "Bajaj", "123");
            await cp.ClickContinue();
            CheckoutOverview co = new CheckoutOverview(_page);
            string ItemName = await co.VerifyItem();
            Assert.That(ItemName, Is.EqualTo("Sauce Labs Backpack"), "Wrong item displayed in checkout overview");
            await co.ClickFinish();
            CheckoutComplete cc= new CheckoutComplete(_page);
            string msg1= await cc.ConfirmText();
            Assert.That(msg1, Is.EqualTo("Thank you for your order!"), "Order completion message mismatch");

        }
    }
}
