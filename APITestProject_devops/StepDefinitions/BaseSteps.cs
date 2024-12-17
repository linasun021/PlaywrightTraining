using BoDi;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestProject.StepDefinitions
{
    [Binding]
    public abstract class BaseSteps
    {
        protected readonly IAPIRequestContext apiRestquestContext;
        protected IObjectContainer objectContainer;

        protected BaseSteps(IObjectContainer objectContainer)
        {
            apiRestquestContext = objectContainer.Resolve<IAPIRequestContext>();
            this.objectContainer = objectContainer;
        }

    }
}