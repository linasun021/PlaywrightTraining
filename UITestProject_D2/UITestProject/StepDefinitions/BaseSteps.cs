using BoDi;
using Microsoft.Playwright;
using TechTalk.SpecFlow.Infrastructure;

namespace UITestProject.StepDefinitions
{
    [Binding]
    public abstract class BaseSteps
    {
        protected readonly IPage page;
        protected IObjectContainer objectContainer;
        protected readonly ISpecFlowOutputHelper specFlowOutputHelper;

        protected BaseSteps(IObjectContainer objectContainer, ISpecFlowOutputHelper specFlowOutputHelper)
        {
            page = objectContainer.Resolve<IPage>();
            this.objectContainer = objectContainer;
            this.specFlowOutputHelper = specFlowOutputHelper;
        }
    }
}

