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
            // Login Page
            LoginPage lp = new LoginPage(_page);
            await lp.login();

            //Produces Page
            ProductsPage pp= new ProductsPage(_page);
            await pp.AddtoCart("Sauce Labs Backpack", "Sauce Labs Bike Light", "Sauce Labs Bolt T-Shirt"); //Addinng Products to Cart
            int CartCount= await pp.CartCount();
            Assert.That(CartCount, Is.EqualTo(3), "Cart count mismatch after adding items"); // Checking items in cart
            await pp.RemoveItem();
            int CartCountAfterRemoved= await pp.CartCount();
            Assert.That(CartCountAfterRemoved, Is.EqualTo(1), "Cart count mismatch after removing items");
            await pp.ClickOnCart();

            //Your CartPage Page
            YourCartpage yp= new YourCartpage(_page);
            string itemName= await yp.VerifyItem();
            Assert.That(itemName, Is.EqualTo("Sauce Labs Backpack"), "Wrong item displayed in cart");
            await yp.ClickContinue();

            //Checkout Your Info Page
            CheckoutYourInfoPage cp = new CheckoutYourInfoPage(_page);
            await cp.FillDetails("Mukul", "Bajaj", "123");
            await cp.ClickContinue();

            //Checkout Overview Page
            CheckoutOverview co = new CheckoutOverview(_page);
            string ItemName = await co.VerifyItem();
            Assert.That(ItemName, Is.EqualTo("Sauce Labs Backpack"), "Wrong item displayed in checkout overview");
            await co.ClickFinish();

            //Checkout Complete Page
            CheckoutComplete cc= new CheckoutComplete(_page);
            string msg1= await cc.ConfirmText();
            Assert.That(msg1, Is.EqualTo("Thank you for your order!"), "Order completion message mismatch");

        }
    }
}
