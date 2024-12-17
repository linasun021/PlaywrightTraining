using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITestProject.Models.Components.Dialogs
{
    public class LogoutDialog<T>
    {
        private readonly ILocator rootElement;
        private readonly T parent;

        public LogoutDialog(ILocator rootElement, T parent)
        {
            this.rootElement = rootElement;
            this.parent = parent;
        }
    }
}




