using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HelloXamarinWorld
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void loginButton_Clicked(object sender, EventArgs e)
        {
            bool isEmptyUserName = string.IsNullOrEmpty(userNameEntry.Text);
            bool isEmptyPassword = string.IsNullOrEmpty(PasswordEntry.Text);
            if (isEmptyUserName || isEmptyPassword)
            {

            }
            else
            {
                Navigation.PushAsync(new HomePage());
            }
        }
    }
}
