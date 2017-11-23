using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace beer
{
    public partial class Test : ContentPage
    {
        public Test()
        {
            InitializeComponent();
        }

        public void florin(object sender, EventArgs e)
        {
            //MainPage = new NavigationPage(new ChooseVolume());
        }

        public void christian(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new ChooseVolume());
        }


    }
}
