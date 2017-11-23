using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using System.Reflection;

namespace beer
{
    public partial class RecipeStep : ContentPage
    {
        Boolean stop = false;
        Boolean running = false;
        int seconds;

        public RecipeStep()
        {
            InitializeComponent();

            test2();
        }

        public void test2() {
            //testout.Text = GenericRecipe.GetStep();

        }

        public void next(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new RecipeStep());
        }

        public void TimerTrigger(object sender, EventArgs e)
        {
            if (running && stop)
            {
                running = false;
                stop = false;
            }
            if (!running && !stop)
            {
                StartTimer(seconds);
                running = true;
            }
            else if (running && !stop) stop = true;
        }

        async void StartTimer(int sec)
        {
            //System.Diagnostics.Debug.WriteLine("hejsa");
            seconds = sec;
            while (!stop && seconds != 0)
            {
                await Task.Delay(1000);
                seconds--;
                int m = (int)Math.Floor((double)(seconds / 60));
                int s = seconds - 60 * m;
                timer.Text = "" + m + ":" + s;
            }
            if (seconds != 0) timer.Text += " (paused)";
            //new ButtonTimer(1000, timer);
        }
    }
}
