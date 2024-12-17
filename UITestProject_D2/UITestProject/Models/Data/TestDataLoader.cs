using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TrainingAutomationFramework.UI.Drivers;
using UITestProject.Models.Data.DTO;

namespace UITestProject.Models.Data
{
    public class TestDataLoader
    {
        public static User LoadUser(string userKey)
        {
            string environment = DriverFactory.GetSettings().Environment??"DEV";

            string fileName = $@".\Models\Data\JSON\UserDetails{environment}.json";
            string filePath = Path.Combine(AppContext.BaseDirectory, fileName);
            string jsonData = File.ReadAllText(filePath);

            Dictionary<string, User> users = JsonSerializer.Deserialize<Dictionary<string, User>>(jsonData);

            if (users != null && users.TryGetValue(userKey, out User user))
            {
                return user;
            }
            else
            {
                throw new KeyNotFoundException($"User with key '{userKey}' not found.");
            }
        }
    }
}
