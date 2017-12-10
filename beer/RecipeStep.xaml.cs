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
        public RecipeStep()
        {
            InitializeComponent();

            Step s = GenericRecipe.GetStep();
            testout.Text = s.text;
            EggWatch.setWatch(s.minutes, timer);
            timer.IsEnabled = (EggWatch.seconds > 0);
        }

        public void next(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new RecipeStep());
        }

        public void TimerTrigger(object sender, EventArgs e)
        {
            EggWatch.Trigger();
        }

    }
}
