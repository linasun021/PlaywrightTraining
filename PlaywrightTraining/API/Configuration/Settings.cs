using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingAutomationFramework.API.Configuration
{
    public class Settings
    {
        public string ApiKey { get; set; }
        public string BaseUrl { get; set; }
        public MySection MySection { get; set; }
    }

    public class MySection
    {
        public string SomeProperty { get; set; }
    }
}
