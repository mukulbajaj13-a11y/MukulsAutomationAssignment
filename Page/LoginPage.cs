using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MukulsAutomationAssignment.POM
{
    public class LoginPage //Internal is used when used in the same soluation
    {
        public IPage _page;
        public LoginPage(IPage Page) { _page = Page; }
        private ILocator _usernames => _page.Locator("#login_credentials");
        private ILocator _password => _page.Locator(".login_password");

        private ILocator _loginbtn => _page.Locator(".submit-button.btn_action");
        private ILocator _FillUsername => _page.Locator("#user-name");
        private ILocator _FillPassword => _page.Locator("#password");

        public async Task<string> GetUsername() {
            
            string usernames = await _usernames.InnerTextAsync();
            string[] ListOfUsernames= usernames.Split('\n');
            string username = ListOfUsernames[1].Trim();
            return username;
        }

        public async Task<string> GetPassword() {
            string passwordText = await _password.InnerTextAsync();
            string[] passwordDetails = passwordText.Split('\n');
            string password = passwordDetails[1].Trim();
            return password;
        }

        public async Task login() {
            string username = await GetUsername();
            string password = await GetPassword();
            await _FillUsername.FillAsync(username);
            await _FillPassword.FillAsync(password);
            await _loginbtn.ClickAsync();
        }




    }
}
