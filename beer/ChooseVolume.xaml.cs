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

            setButtons();
        }

        public void setButtons() 
        {   
            if ( App.units == "eu" ) {
                eu.BackgroundColor = Color.FromHex("aa07800a");
                us.BackgroundColor = Color.FromHex("aa1960aa");
                volume.Placeholder = "Enter number of liters";
            }
            else {
                us.BackgroundColor = Color.FromHex("aa07800a");
                eu.BackgroundColor = Color.FromHex("aa1960aa");
                volume.Placeholder = "Enter number of gallons";
            }
        }

        public void metric(object sender, EventArgs e) 
        {
            App.units = "eu";
            setButtons();
        }

        public void imperial(object sender, EventArgs e)
        {
            App.units = "us";
            setButtons();
        }

        public void set_volume(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new Ingredients(volume.Text,App.units));
        }


    }
}
