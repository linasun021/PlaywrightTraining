using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace UITestProject.Models.Components.Dialogs
{
    public class LoginDialog<T>
    {
        private readonly IPage page;
        private readonly T parent;

        public LoginDialog(IPage page, T parent)
        {
            this.page = page;
            this.parent = parent;
        }
        public ILocator LoginWarning => page.Locator("#login-warning");
        public ILocator UsernameInput => page.GetByLabel("Username");
        public ILocator PasswordInput => page.GetByLabel("Password");
        public ILocator AgreeCheckbox => page.GetByLabel("I agree to the terms of service");
        public ILocator CancelButton => page.GetByRole(AriaRole.Button, new() { Name = "Cancel" });
        public ILocator LoginButton => page.GetByRole(AriaRole.Button, new() { Name = "Log In" });

        // Actions
        public LoginDialog<T> EnterUsername(string username)
        {
            UsernameInput.FillAsync(username).Wait();
            return this;
        }

        public LoginDialog<T> EnterPassword(string password)
        {
            PasswordInput.FillAsync(password).Wait();
            return this;
        }

        public LoginDialog<T> CheckAgreeCheckbox()
        {
            AgreeCheckbox.CheckAsync().Wait();
            return this;
        }

        public LoginDialog<T> ClickLoginButton()
        {
            LoginButton.ClickAsync().Wait();
            return this;
        }

        public LoginDialog<T> ClickCancelButton()
        {
            CancelButton.ClickAsync().Wait();
            return this;
        }

        public void Login(string username, string password)
        {
            EnterUsername(username)
               .EnterPassword(password)
               .CheckAgreeCheckbox()
               .ClickLoginButton();
        }
    }
}




