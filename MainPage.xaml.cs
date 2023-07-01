using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace android_project
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private TmdbApiClient _tmdbApiClient;
        private List<Movie> _moviesList;

        public MainPage()
        {
            InitializeComponent();

            _tmdbApiClient = new TmdbApiClient();
            _moviesList = new List<Movie>();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Fetch popular movies
            MovieResponse movieResponse = await _tmdbApiClient.GetPopularMoviesAsync();

            // Update UI with movie data
            _moviesList = movieResponse.Results;
            MoviesListView.ItemsSource = _moviesList;
        }

        private async void OnMovieSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Movie selectedMovie)
            {
                // Navigate to the MovieDetailsPage with selected movie details
                await Navigation.PushAsync(new MovieDetailsPage(selectedMovie));

                // Deselect the selected item in the ListView
                MoviesListView.SelectedItem = null;
            }
        }

        private void SearchMovies(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                // If the search term is empty, display all movies
                MoviesListView.ItemsSource = _moviesList;
            }
            else
            {
                // Filter movies based on the search term
                var filteredMovies = _moviesList.Where(m => m.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
                MoviesListView.ItemsSource = filteredMovies;
            }
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchTerm = e.NewTextValue;
            SearchMovies(searchTerm);
        }
    }
}
