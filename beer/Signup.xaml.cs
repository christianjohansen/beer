using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace beer
{
    public partial class Signup : ContentPage
    {
        public Signup()
        {
            InitializeComponent();
        }

        public void signup(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("signup");
        }
    }
}
