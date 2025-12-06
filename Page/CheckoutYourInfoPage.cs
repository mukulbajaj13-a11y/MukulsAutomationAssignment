using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MukulsAutomationAssignment.POM
{
    public class CheckoutYourInfoPage
    {
        private IPage _page;
        private ILocator _Fname => _page.Locator("#first-name");
        private ILocator _Lname => _page.Locator("#last-name");
        private ILocator _ZipCode => _page.Locator("#postal-code");
        private ILocator _ContinueBtn=> _page.Locator("#continue");

        public CheckoutYourInfoPage(IPage page) { _page = page; }

        public async Task FillDetails(string Fname, string Lname, string ZipCode) {
            await _Fname.FillAsync(Fname);
            await _Lname.FillAsync(Lname);
            await _ZipCode.FillAsync(ZipCode);
        }
        public async Task ClickContinue() {
            await _ContinueBtn.ClickAsync();
        }
    }
}
