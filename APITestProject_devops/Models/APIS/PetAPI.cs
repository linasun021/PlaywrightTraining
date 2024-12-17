using APITestProject.Models.Requests;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace APITestProject.Models.APIS
{
    public class PetAPI : BaseAPI<PetAPI>
    {
        public PetAPI(IAPIRequestContext aPIRequestContext) : base(aPIRequestContext)
        {
        }

        public IAPIResponse GetPetByStatus(string status)
        {
            SetResourceUrl($"pet/findByStatus/");
            var queryParams = new Dictionary<string, object>
            {
                { "status", $"{status}" }
            };
            return Get(queryParams);
        }
    }
}
