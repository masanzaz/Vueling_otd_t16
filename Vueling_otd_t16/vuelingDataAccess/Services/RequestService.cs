﻿using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using vuelingDomain.Helper;

namespace vuelingDataAccess
{
    public class RequestService
    {
        protected DataTable GetData(string url, string name)
        {
            string path = $"{url}{name}";
            var client = new RestClient(path);
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Connection", "keep-alive");
            var response = client.Execute(request);

            string stringResult = (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == 0) ? PersistData.ReadFile(name) : response.Content;

            DataTable dataSet = JsonConvert.DeserializeObject<DataTable>(stringResult);
            return dataSet;
        }
    }
}
