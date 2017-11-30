using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Xamarin.Forms;

using Xamarin.Forms;

namespace beer
{
    public partial class Search : ContentPage
    {
        string lookfor = "";
        List<Recipe> recipes;

        public Search()
        {
            InitializeComponent();
        }

        async void testtest(object sender, EventArgs e)
        {
            lookfor = search.Text;
            if ( lookfor.Length > 2 )
            {
                list.Children.Clear();

                /*var authData = string.Format("{0}:{1}", "cj", "blabla");
                var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));*/

                /*HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", App.token);*/
                var response = await (Tools.APIClient()).GetAsync(new Uri(App.url+"/search/" + lookfor));
                if (response.IsSuccessStatusCode) recipes = JsonConvert.DeserializeObject<List<Recipe>>(await response.Content.ReadAsStringAsync());

                System.Diagnostics.Debug.WriteLine(recipes);


                foreach (var element in recipes)
                {
                    Button b = new Button() { Text = element.name,  };
                    b.Clicked += testtest2;
                    list.Children.Add(b);

                }

            }
        }

        async void testtest2(object sender, EventArgs e) {
            App.Current.MainPage.Navigation.PushAsync(new ChooseVolume());
        }

    }
}
