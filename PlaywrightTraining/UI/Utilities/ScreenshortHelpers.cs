using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAutomationFramework.UI.Configuration;
using TrainingAutomationFramework.UI.Drivers;

namespace TrainingAutomationFramework.UI.Utilities
{
    public static class ScreenshotHelper
    {
        private static int _screenshotCounter = 0;
        private static Settings _settings;

        static ScreenshotHelper()
        {
            _settings = DriverFactory.GetSettings();
        }

        public static async Task CaptureScreenshotAsync(IPage page, string scenarioName, string stepDescription)
        {
            if (!_settings.Screenshot)
            {
                return;
                }
            var directory = Path.Combine(Directory.GetCurrentDirectory(), "Screenshots", scenarioName);
            Directory.CreateDirectory(directory);

            var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            var fileName = $"{stepDescription}_{timestamp}_{_screenshotCounter++}.png";
            var fullPath = Path.Combine(directory, fileName);

            await page.ScreenshotAsync(new PageScreenshotOptions
            {
                Path = fullPath,
                FullPage = true
            });

            Console.WriteLine($"Screenshot saved to: {fullPath}");
        }
    }
}
