using System;
using System.Collections.Generic;
using Plugin.Connectivity;

using Xamarin.Forms;


namespace beer
{
    public partial class App : Application
    {
        public static double volume;
        public static string units;
        public static string token = "Y2o6YmxhYmxh";
        public static string url = "http://192.168.1.105:3000";
        public static int recipe_id = 2;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Test());

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
