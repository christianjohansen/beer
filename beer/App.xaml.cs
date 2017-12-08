﻿using System;
using System.Collections.Generic;
using Plugin.Connectivity;

using Xamarin.Forms;


namespace beer
{
    public partial class App : Application
    {
        public static double volume;
        public static string units;
        public static string token = "";
        public static string url = "http://192.168.1.105:3000";
        //public static string url = "http://192.168.43.233:3000";
        //public static string url = "http://10.140.73.167:3000";
        public static int recipe_id = 2;

        public static NavigationPage front;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Test());
            /*front = new NavigationPage(new Test());
            MainPage = new MasterDetailPage()
            {
                Master = new MenuPage() {Title = "hallo"},
                Detail = front
            };*/

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
