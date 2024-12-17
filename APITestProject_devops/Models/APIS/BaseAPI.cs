using APITestProject.Models.DTOS;
using APITestProject.Models.DTOS.ResponseDTO;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace APITestProject.Models.Requests
{
    public abstract class BaseAPI<T> where T : BaseAPI<T>
    {
        IAPIRequestContext _aPIRequestContext;
        public BaseAPI(IAPIRequestContext aPIRequestContext)
        {
            _aPIRequestContext = aPIRequestContext;
        }

        private string resourceUrl;

        public IAPIResponse Get(Dictionary<string, object> queryParams)
        {
            return _aPIRequestContext.GetAsync(resourceUrl,new() { Params = queryParams }).Result;
        }

        public IAPIResponse Post(string payload)
        {
            string jsonPayload = JsonSerializer.Serialize(payload);

            // Create the request options with the serialized payload
            var options = new APIRequestContextOptions
            {
                DataObject = jsonPayload
            };

            // Execute the POST request with the options
            return _aPIRequestContext.PostAsync(resourceUrl, options).Result;
        }

        //public string Patch(string payload)
        //{
        //    var request = new RestRequest(resourceUrl, Method.Patch);
        //    request.AddStringBody(payload, ContentType.Json);
        //    return Run(request);
        //}

        //public string Delete()
        //{
        //    var request = new RestRequest(resourceUrl, Method.Delete);
        //    return Run(request);
        //}

        //// Returns the RestResponse Object of the LAST response this BaseApi received
        //public RestResponse GetRawResponse() => rawResponse;

        //// Overwrites all the headers with a new set of headers
        //public void SetHeaders(Dictionary<string, string> headers) => this.headers = headers;

        //// Overwrites all the queryParams with a new set of queryParameters
        //public void SetQueryParameters(Dictionary<string, string> queryParameters) => this.queryParameters = queryParameters;

        //private string Run(RestRequest request)
        //{
        //    foreach (var parameter in queryParameters)
        //    {
        //        request.AddQueryParameter(parameter.Key, parameter.Value);
        //    }
        //    request.AddHeaders(headers);
        //    rawResponse = client.Execute(request);
        //    return rawResponse.Content;
        //}

        //This function updates the resource Url for the Api Instance.
        //The resource url is appended to the baseUrl to make any call
        protected void SetResourceUrl(string resourceUrl)
        {
            //Remove leading slash as not needed for RestSharp implementation
            if (resourceUrl.StartsWith('/') || resourceUrl.StartsWith('\\'))
                {
                    resourceUrl = resourceUrl[1..];
                }
            this.resourceUrl = resourceUrl;
        }
    }
}
