using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace beer
{
    public partial class Ingredients : ContentPage
    {
        List<Recipe> recipes;

        public Ingredients()
        {
            InitializeComponent();

            ShowIngredients();
        }

        public async void ShowIngredients() {
            var response = await (API.Client()).GetAsync(new Uri(App.url + "/recipe/" + App.units + "/" + App.recipe_id + "/" + App.volume));
            if (response.IsSuccessStatusCode) recipes = JsonConvert.DeserializeObject<List<Recipe>>(await response.Content.ReadAsStringAsync());

            GenericRecipe.setRecipe(recipes[0]);
            string temp = "";
            temp += recipes[0].name + "\n";
            temp += "\nmalts:\n";
            foreach (var malt in recipes[0].malt_used)
            {
                temp += " " + malt.name + " (" + malt.weight + " " + recipes[0].weight_unit + ")\n";
            }
            temp += "\nhops:\n";
            foreach (var hop in recipes[0].hop_used)
            {
                temp += " " + hop.name + " (" + hop.weight + " " + recipes[0].weight_unit + ")\n";
            }
            testout.Text = temp;

        }

        public void next(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new RecipeStep());
        }


    }
}
