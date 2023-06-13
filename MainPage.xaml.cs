namespace android_project;

public partial class MainPage : ContentPage
{

    public List<Movie> movies { get; set; }

    public MainPage()
    {
        InitializeComponent();

        Movies = new List<Movie>
            {
                new Movie { Title = "Movie 1", Director = "Director 1", Year = 2021 },
                new Movie { Title = "Movie 2", Director = "Director 2", Year = 2022 },
                // Add more movies as needed
            };

        BindingContext = this;
    }

    private async void OnMovieSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is Movie selectedMovie)
        {
            await Navigation.PushAsync(new MovieDetailPage(selectedMovie));
            MoviesListView.SelectedItem = null;
        }
    }
}

	


