using System;
using System.Collections.Generic;
using System.Net.Http;
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



                /*var authData = string.Format("{0}:{1}", Constants.Username, Constants.Password);
                var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

                client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);*/



                var response = await(new HttpClient()).GetAsync(new Uri("http://192.168.1.105:3000/search/" + lookfor));
                if (response.IsSuccessStatusCode) recipes = JsonConvert.DeserializeObject<List<Recipe>>(await response.Content.ReadAsStringAsync());

                foreach (var element in recipes)
                {
                    Button b = new Button() { Text = element.name };
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
