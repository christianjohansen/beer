using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Xamarin.Forms;


namespace beer
{
    public partial class Search : ContentPage
    {
        string lookfor = "";
        ObservableCollection<RecipeSearch> list = new ObservableCollection<RecipeSearch>();
        List<RecipeSearch> recipes = new List<RecipeSearch>();

        public Search()
        {
            InitializeComponent();

            recipe_list.ItemsSource = list;

            GetSearchResults();
        }

        public void SelectItem(object sender, SelectedItemChangedEventArgs e) {
            if (((ListView)sender).SelectedItem == null) return;
            App.recipe_id = ((RecipeSearch)(((ListView)sender).SelectedItem)).id;
            App.Current.MainPage.Navigation.PushAsync(new Ingredients());
            ((ListView)sender).SelectedItem = null;
        }

        async void testtest(object sender, EventArgs e)
        {
            GetSearchResults(); 
        }

        async void GetSearchResults() {
            lookfor = search.Text;
            if (lookfor == null || lookfor.Equals("")) lookfor = "*"; 
            var response = await(API.Client(false)).GetAsync(new Uri(App.url + "/search/"+lookfor));
            if (response.IsSuccessStatusCode) recipes = JsonConvert.DeserializeObject<List<RecipeSearch>>(await response.Content.ReadAsStringAsync());


            int a = 0;
            list.Clear();
            foreach (var element in recipes) list.Add(element.setFormat(RecipeSearch.colors[a++ % 2]));
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