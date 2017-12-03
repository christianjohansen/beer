using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        ObservableCollection<Recipe> list = new ObservableCollection<Recipe>();
        List<Recipe> recipes = new List<Recipe>();

        public Search()
        {
            InitializeComponent();

            recipe_list.ItemsSource = list;
        }

        public void SelectItem(object sender, SelectedItemChangedEventArgs e) {
            App.recipe_id = ( (Recipe)( ((ListView)sender).SelectedItem ) ).id;
            App.Current.MainPage.Navigation.PushAsync(new ChooseVolume());
        }

        async void testtest(object sender, EventArgs e)
        {
            lookfor = search.Text;
            if (lookfor.Length > 2 )
            {
                var response = await (API.Client()).GetAsync(new Uri(App.url+"/search/" + lookfor));
                if (response.IsSuccessStatusCode) recipes = JsonConvert.DeserializeObject<List<Recipe>>(await response.Content.ReadAsStringAsync());

                list.Clear();
                foreach (var element in recipes ) list.Add(element);

            }
        }

    }
}

/*
                 //list.Children.Clear();

                var authData = string.Format("{0}:{1}", "cj", "blabla");
                var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

HttpClient client = new HttpClient();
client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", App.token);
*/