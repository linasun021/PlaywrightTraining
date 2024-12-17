using Microsoft.Playwright;
using static System.Net.Mime.MediaTypeNames;

namespace UITestProject.Models.Pages
{
    public class HomePage : BasePage<HomePage>
    {
        public HomePage(IPage page) : base(page) { }

        public ILocator JupiterPrimeLogo => page.GetByRole(AriaRole.Link, new() { Name = "Jupiter Prime Home" });

        //public bool IsPageLoaded()
        //{
        //    return VerifyJupiterPrimeLogoDisplayed();
        //}
    }

}
