using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using Firebase.Database;
using Firebase;
using Google.Apis.Auth;
using Google.Apis.Auth.OAuth2;

namespace android_project
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
        }

       
        
    }
}
