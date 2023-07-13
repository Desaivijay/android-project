using Firebase.Auth;

namespace android_project
{
    public partial class RegistrationPage : ContentPage
    {
        private const string FirebaseApiKey = "YOUR_API_KEY";

        public RegistrationPage()
        {
            InitializeComponent();
        }

        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            string email = EmailEntry.Text;
            string password = PasswordEntry.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Registration", "Please enter email and password.", "OK");
                return;
            }

            try
            {
                var user = await FirebaseAuth.DefaultInstance.CreateUserWithEmailAndPasswordAsync(email, password);

                // Handle successful registration
                await DisplayAlert("Registration", "User registered successfully", "OK");

                // Navigate to the login page or any other desired page
                await Navigation.PushAsync(new LoginPage());
            }
            catch (FirebaseAuthException ex)
            {
                // Handle registration error
                await DisplayAlert("Registration", $"Registration failed: {ex.Message}", "OK");
            }
        }
    }
}
