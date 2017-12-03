using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace beer
{
    public static class API
    {
        public static HttpClient Client()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", App.token);
            return client;
        }

    }
}
