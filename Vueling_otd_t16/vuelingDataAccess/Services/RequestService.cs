using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace vuelingDataAccess
{
    public class RequestService
    {
        protected DataTable GetData(string path)
        {
            var client = new RestClient(path);
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Connection", "keep-alive");
            var response = client.Execute(request);
            DataTable dataSet = JsonConvert.DeserializeObject<DataTable>(response.Content);
            return dataSet;
        }
    }
}
