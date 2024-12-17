using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAutomationFramework.API.Configuration;

namespace TrainingAutomationFramework.Api.Drivers
{
    public class PlaywrightDriver
    {
        private static readonly Task<IAPIRequestContext>? _requestContext = null;
        private static Settings? _settings;

        static PlaywrightDriver()
        {
            var configReader = new ConfigurationReader();
            _settings = configReader.GetSettings();
            _requestContext = CreateAPIConext();
        }

        public static IAPIRequestContext? ApiRequestContext => _requestContext?.GetAwaiter().GetResult();
        private static async Task<IAPIRequestContext> CreateAPIConext()
        {
            var playwright = await Playwright.CreateAsync();

            return await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions
            {
                BaseURL = _settings?.BaseUrl,
                IgnoreHTTPSErrors = true
            });
        }
        public static Settings GetSettings()
        {
            return _settings;
        }

        public static void Dispose()
        {
            _requestContext?.Dispose();
        }
    }
}
