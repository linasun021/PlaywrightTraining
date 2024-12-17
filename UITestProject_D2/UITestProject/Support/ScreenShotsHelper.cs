using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Infrastructure;
using TrainingAutomationFramework.UI.Drivers;

namespace UITestProject.Support
{
    public static class ScreenShotsHelper
    {
        public static void TakeScreenshot(ISpecFlowOutputHelper specFlowOutputHelper, IPage page)
        {
            var screenshotPath = Path.Combine(Directory.GetCurrentDirectory(), $"{Path.GetRandomFileName()}.png");
            page.ScreenshotAsync(new PageScreenshotOptions 
            {
                Path = screenshotPath,
                FullPage = true
            }).Wait();
            specFlowOutputHelper.AddAttachment(screenshotPath);
        }
    }
}
