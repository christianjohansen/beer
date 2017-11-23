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
            App.volume = Convert.ToDouble(volume.Text);
            App.Current.MainPage.Navigation.PushAsync(new Ingredients());
        }

    }
}
