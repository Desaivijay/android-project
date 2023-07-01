using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;



namespace android_project
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieDetailsPage : ContentPage
    {
        private Image MovieImages;

        public MovieDetailsPage(Movie selectedMovie)
        {
            InitializeComponent();
            BindingContext = selectedMovie;
            MovieImages = new Image();
            LoadImage(selectedMovie.ImageUrl);
        }
        private async void LoadImage(string imageUrl)
        {
            try
            {
                if (string.IsNullOrEmpty(imageUrl))
                {
                    Console.WriteLine("Image URL is empty");
                    return;
                }

                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(imageUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var imageBytes = await response.Content.ReadAsByteArrayAsync();
                        MovieImage.Source = ImageSource.FromStream(() => new MemoryStream(imageBytes));
                    }
                    else
                    {
                        Console.WriteLine($"Error loading movie image: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading movie image: {ex.Message}");
            }

        }
    }
}
