using Microsoft.Playwright;
using UITestProject.Models.Components.Dialogs;
using static System.Net.Mime.MediaTypeNames;

namespace UITestProject.Models.Pages
{
    public abstract class BasePage<T> where T : BasePage<T>
    {
        protected readonly IPage page;

        // Locators
        private ILocator ContactMenu => page.Locator("#menu-contact");
        public ILocator LoginButton => page.GetByRole(AriaRole.Button, new() { Name = "Login" });
        private ILocator LogoutMenu => page.Locator("#menu-logout");
        private ILocator LogoutModal => page.Locator("#logout-modal");
        private ILocator ShopMenu => page.Locator("#menu-shop");
        private ILocator CartMenu => page.Locator("#menu-cart");
        private ILocator CartCountLocator => page.Locator("#cart-count");
        private ILocator LoginGreeting => page.Locator("#login-greeting");

        protected BasePage(IPage page) => this.page = page;

        public ContactPage ClickContactMenu()
        {
            ContactMenu.ClickAsync().Wait();
            return new ContactPage(page);
        }
        public LoginDialog<T> ClickLoginMenu()
        {
            LoginButton.ClickAsync().Wait();
            return new LoginDialog<T>(page, this as T);
        }


        public LogoutDialog<T> ClickLogoutMenu()
        {
            LogoutMenu.ClickAsync().Wait();
            return new LogoutDialog<T>(LogoutModal, this as T);
        }

        public ShopPage ClickShopMenu()
        {
            ShopMenu.ClickAsync().Wait();
            return new ShopPage(page);
        }

        public CartPage ClickCartMenu()
        {
            CartMenu.ClickAsync().Wait();
            return new CartPage(page);
        }

        public int CartCount => int.Parse(CartCountLocator.TextContentAsync().Result);

        public string GetUser()
        {
            var greeting = LoginGreeting.AllAsync().Result;
            return greeting.Count == 0 ? string.Empty : greeting[0].TextContentAsync().Result;
        }

        //public T Logout() => ClickLogoutMenu().ClickYesButton();
    }

}

