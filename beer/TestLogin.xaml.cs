using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace beer
{
    public partial class TestLogin : ContentPage
    {
        public TestLogin()
        {
            InitializeComponent();
        }

        public void login(object sender, EventArgs e)
        {
            API.Login(email.Text,password.Text);
        }

    }
}
