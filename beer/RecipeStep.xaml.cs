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
            if (GenericRecipe.isLast)
            {
                nextstep.Text = "finished";
                nextstep.BackgroundColor = Color.FromHex("aaf4a200");
            }
            testout.Text = s.text;
            EggWatch.setWatch(s.minutes, timer);
            timer.IsEnabled = (EggWatch.seconds > 0);
        }

        public void next(object sender, EventArgs e)
        {
            if (!GenericRecipe.isLast) App.Current.MainPage.Navigation.PushAsync(new RecipeStep());
            else App.Current.MainPage.Navigation.PopToRootAsync();
        }

        public void TimerTrigger(object sender, EventArgs e)
        {
            EggWatch.Trigger();
        }

    }
}
