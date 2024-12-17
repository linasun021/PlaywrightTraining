using BoDi;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAutomationFramework.Api.Drivers;
using TrainingAutomationFramework.UI.Drivers;

namespace APITestProject.StepDefinitions
{
    [Binding]
    public class StepHooks
    {
        private readonly IObjectContainer _objectContainer;

        private IAPIRequestContext _apiRequestContext;
        public StepHooks(IObjectContainer objectContainer) => this._objectContainer = objectContainer;

        [BeforeScenario]
        public void Setup()
        {
            _apiRequestContext = PlaywrightDriver.ApiRequestContext;
            _objectContainer.RegisterInstanceAs(_apiRequestContext);
        }

        [AfterScenario]
        public void Shutdown()
        {
            PlaywrightDriver.Dispose();
        }
    }
}
