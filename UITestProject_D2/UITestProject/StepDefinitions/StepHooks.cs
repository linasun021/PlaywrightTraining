using BoDi;
using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;
using TrainingAutomationFramework.UI.Configuration;
using TrainingAutomationFramework.UI.Drivers;
using TrainingAutomationFramework.UI.Utilities;
using UITestProject.Models.Pages;
using UITestProject.Support;

namespace UITestProject.StepDefinitions
{
    [Binding]
    public class StepHooks
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IObjectContainer _objectContainer;
        private IPage _page;
        private Settings _settings;

        private ISpecFlowOutputHelper _specFlowOutputHelper;

        public StepHooks(IObjectContainer objectContainer, ScenarioContext scenarioContext, ISpecFlowOutputHelper specFlowOutputHelper)
        {
            this._objectContainer = objectContainer;
            _scenarioContext = scenarioContext;
            _settings = DriverFactory.GetSettings();
            _specFlowOutputHelper = specFlowOutputHelper;
        }

        [BeforeScenario]
        public void Setup()
        {
            if (!_settings.Screenshot)
            {
                Console.WriteLine("Screenshot capture is currently disabled. To enable this feature, please update the settings file accordingly.");
            }

            _page = DriverFactory.GetPageAsync().Result;
            _objectContainer.RegisterInstanceAs(_page);
        }

        [AfterScenario]
        public void Shutdown()
        {
            var filePath = (_scenarioContext.ScenarioInfo.Arguments.Count > 0) ? _scenarioContext.ScenarioInfo.Title + "_" + _scenarioContext.ScenarioInfo.Arguments[0] : _scenarioContext.ScenarioInfo.Title;
            DriverFactory.CloseAsync(filePath).Wait();
        }

        [AfterStep]
        public void AfterStep()
        {
            ScreenShotsHelper.TakeScreenshot(_specFlowOutputHelper, _page);            
        }
    }

}
