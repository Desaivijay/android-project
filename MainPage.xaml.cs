namespace android_project;

public partial class MainPage : ContentPage
{
    private TmdbApiClient _tmdbApiClient;
   

    public MainPage()
    {
        InitializeComponent();

        _tmdbApiClient = new TmdbApiClient();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Fetch popular movies
        MovieResponse movieResponse = await _tmdbApiClient.GetPopularMoviesAsync();

        // Update UI with movie data
        MoviesListView.ItemsSource = movieResponse.Results;
    }
    
}

	


