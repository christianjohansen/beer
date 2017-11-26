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
using Plugin.MediaManager;

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
            Step s = GenericRecipe.GetStep();
            testout.Text = s.text;
            if (s.minutes > 0)
            {
                seconds = 60 * s.minutes;
                timer.Text = "" + s.minutes + ":00";
            }
            timer.IsEnabled = (s.minutes > 0);
        }

        public void next(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new RecipeStep());
        }

        public void TimerTrigger(object sender, EventArgs e)
        {
            if ( running && !stop ) {
                CrossMediaManager.Current.PlaybackController.Stop();
                timer.Text = "0:00";
                timer.IsEnabled = false;
            } 
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
            seconds = sec;
            seconds = 10;
            while (!stop && seconds != 0)
            {
                await Task.Delay(1000);
                seconds--;
                int m = (int)Math.Floor((double)(seconds / 60));
                int s = ((seconds - 60 * m) + 100);
                timer.Text = "" + m + ":" + (s.ToString()).Substring(1, 2);
            }
            if (seconds != 0) timer.Text += " (paused)";
            //new ButtonTimer(1000, timer);
            timer.Text = "stop alarm";
            await CrossMediaManager.Current.Play("https://www.soundhelix.com/examples/mp3/SoundHelix-Song-1.mp3");
        }
    }
}
