using System;
using System.Collections.Generic;
using Plugin.Connectivity;

using Xamarin.Forms;


namespace beer
{
    public partial class App : Application
    {
        public static double volume;
        public static string units = "eu";
        public static string token = "";
        public static string url = "http://192.168.1.105:3000"; // hjemme
        //public static string url = "http://10.140.64.88:3000"; // skole
        public static int recipe_id = 2;

        public static NavigationPage front;
        public static ContentPage test;

        public App()
        {
            InitializeComponent();

            test = new Test(); 
            MainPage = new NavigationPage(test);

            if (!CrossConnectivity.Current.IsConnected) MainPage.Navigation.PushAsync(new NoConnection());
        }

        protected override void OnStart()
        {
            CrossConnectivity.Current.ConnectivityChanged += ConnectionChanged;

        }

        public void ConnectionChanged(object sender, EventArgs e)
        {
            if (CrossConnectivity.Current.IsConnected) MainPage.Navigation.PopAsync();
            else MainPage.Navigation.PushAsync(new NoConnection());
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
