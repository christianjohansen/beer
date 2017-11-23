using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace beer
{
    public partial class ChooseVolume : ContentPage
    {
        public ChooseVolume()
        {
            InitializeComponent();
        }

        public void next(object sender, EventArgs e)
        {
            if (((Button)sender).Text == "liters")
            {
                App.volume = Convert.ToDouble(volume.Text);
                App.units = "eu";
            }
            else
            {
                App.volume = Convert.ToDouble(volume.Text) * 3.79;
                App.units = "us";
            }
            App.Current.MainPage.Navigation.PushAsync(new Ingredients());
        }

    }
}
