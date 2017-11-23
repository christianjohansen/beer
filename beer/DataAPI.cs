using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

//var response = await client.GetAsync(new Uri("http://192.168.1.105:3000/recipe/-/2/-"));
//var response = await client.GetAsync(new Uri("http://10.140.73.173:3000/recipe/-/2/-"));

namespace beer
{
    public static class DataAPI
    {
        public static async Task<List<Recipe>> Load()
        {
            var response = await (new HttpClient()).GetAsync(new Uri("http://192.168.43.233:3000/-/2/-"));
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<Recipe>>(content);
            }
            else return null;
        }

    }
}

