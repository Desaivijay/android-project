using Firebase.Auth;

namespace android_project
{
    public partial class LoginPage : ContentPage
    {
        private const string FirebaseApiKey = "AIzaSyCpnMW0r1CxjaP1bLMrkLtgiWcGCZuiADU";

        public LoginPage()
        {
            InitializeComponent();
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            string email = EmailEntry.Text;
            string password = PasswordEntry.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Login", "Please enter email and password.", "OK");
                return;
            }

            try
            {
                var user = await FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync(email, password);

                // Handle successful login
                await DisplayAlert("Login", "User logged in successfully", "OK");

                // Navigate to the main page or any other desired page
                await Navigation.PushAsync(new MainPage());
            }
            catch (FirebaseAuthException ex)
            {
                // Handle login error
                await DisplayAlert("Login", $"Login failed: {ex.Message}", "OK");
            }
        }
    }
}
