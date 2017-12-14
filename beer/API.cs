using System;
using System.Text;
//using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
//using Newtonsoft.Json;
//using System.Linq;
//using System.Threading.Tasks;
using Newtonsoft.Json;


namespace beer
{
    public static class API
    {
        public static HttpClient Client(bool authenticate)
        {
            HttpClient client = new HttpClient();
            if ( authenticate ) client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", App.token);
            return client;
        }

        public static async void Login(string email, string password)
        {
            var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(email+":"+password));
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
            var response = await client.GetAsync(new Uri(App.url + "/login"));
            if (response.IsSuccessStatusCode)
            {
                App.token = await response.Content.ReadAsStringAsync();
                ((Test)App.test).setColor();
            }
        }

    }
}

/*
                 var authData = string.Format("{0}:{1}", "cj", "blabla");
                var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

HttpClient client = new HttpClient();
client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", App.token);
*/
