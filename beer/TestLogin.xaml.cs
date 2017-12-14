using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace beer
{
    public partial class TestLogin : ContentPage
    {
        public TestLogin(string message,ContentPage after_login)
        {
            InitializeComponent();

            login_message.Text = message;
        }

        public void login(object sender, EventArgs e)
        {
            API.Login(email.Text,password.Text); 
        }


    }

}
