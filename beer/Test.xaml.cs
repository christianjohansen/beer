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

        public void login(object sender, EventArgs e)
        {
            //MainPage = new NavigationPage(new ChooseVolume());
            App.Current.MainPage.Navigation.PushAsync(new TestLogin());
        }

        public void signup(object sender, EventArgs e)
        {
            //MainPage = new NavigationPage(new ChooseVolume());
        }

        public void brew(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new Search());
        }

        public void newrecipe(object sender, EventArgs e)
        {
            if ( App.token != "" ) App.Current.MainPage.Navigation.PushAsync(new NewRecipe());
        }


    }
}
