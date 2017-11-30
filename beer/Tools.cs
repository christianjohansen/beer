using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace beer
{
    public static class Tools
    {
        public static async Task<HttpResponseMessage> APIRequest(string command)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", App.token);
            var response = await client.GetAsync(new Uri(App.url + "/" + command));
            return response;
        }

        public static HttpClient APIClient() {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", App.token);
            return client;
        }
    }
}

/*
 * HttpResponseMessage */
