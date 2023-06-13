using Android.Graphics;

namespace android_project;

public partial class NewPage1 : ContentPage
{
	public NewPage1(Movie movie)
	{
        InitializeComponent();

        // Set the movie object as the BindingContext
        BindingContext = movie;
    }
}