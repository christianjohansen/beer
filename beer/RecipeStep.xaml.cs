using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace beercalc
{
    public partial class RecipeStep : ContentPage
    {
        HttpClient client;
        int page = 0;
        int seconds = 1000;
        Boolean stop = false;
        Boolean running = false;

        public RecipeStep()
        {
            InitializeComponent();

            test();
        }

        public async void test() {
            client = new HttpClient();

            var response = await client.GetAsync(new Uri("http://192.168.1.105:3000/test"));
            //var response = await client.GetAsync(new Uri("http://10.140.73.173:3000/recipe/-/2/-"));
            //var response = await client.GetAsync(new Uri("http://192.168.43.233:3000/test"));
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                List<Recipe> recipes = JsonConvert.DeserializeObject<List<Recipe>>(content);

                string temp = "";
                foreach (var recipe in recipes)
                {
                    temp += recipe.name + "\n";
                    temp += "malts:\n";
                    foreach (var malt in recipe.malt_used)
                    {
                        temp += " " + malt.name + "(" + malt.weight + "g)\n";
                    }
                    temp += "hops:\n";
                    foreach (var hop in recipe.hop_used)
                    {
                        temp += " " + hop.name + "(" + hop.weight + "g)\n";
                    }
                }
                testout.Text = temp;

            }
        }

        public void testtest(object sender, EventArgs e) {
            App.Current.MainPage.Navigation.PushAsync(new RecipeStep());
        }

        public void TimerTrigger(object sender, EventArgs e) {
            if (running && stop)
            {
                running = false;
                stop = false;
            }
            if ( !running && !stop ) 
            {
                StartTimer(seconds);
                running = true;
            }
            else if ( running && !stop )  stop = true;
        }

        async void StartTimer(int sec) {
            //System.Diagnostics.Debug.WriteLine("hejsa");
            seconds = sec;
            while ( !stop && seconds != 0 )
            {
                await Task.Delay(1000);
                seconds--;
                int m = (int)Math.Floor( (double)( seconds / 60 ) );
                int s = seconds - 60 * m;
                timer.Text = "" + m + ":" + s;
            }
            if ( seconds != 0 ) timer.Text += " (paused)";
            //new ButtonTimer(1000, timer);
        }


    }

}

