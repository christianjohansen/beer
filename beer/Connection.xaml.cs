using System;
using System.Collections.Generic;
using Plugin.Connectivity;

using Xamarin.Forms;

namespace beercalc
{
    public partial class Connection : ContentPage
    {
        public Connection()
        {
            InitializeComponent();
        }

        protected override void OnAppearing() {
            base.OnAppearing();
            string temp = "";
            foreach (var test in CrossConnectivity.Current.ConnectionTypes)
            {
                temp += test.ToString() + ", ";
            }
            connection_text.Text = temp;

            CrossConnectivity.Current.ConnectivityChanged += ConnectionChanged;

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            CrossConnectivity.Current.ConnectivityChanged -= ConnectionChanged;

        }

        public void ConnectionChanged(object sender, EventArgs e) {
            connection_text.Text = "skrammel";
        }
    }
}
