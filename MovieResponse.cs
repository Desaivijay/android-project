using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace android_project
{

    public class MovieResponse
    {
        public List<Movie> Results { get; set; }

        public MovieResponse()
        {
            Results = new List<Movie>();
        }
    }

    public class Movie
    {
        public string Title { get; set; }
        public string ReleaseDate { get; set; }
        public string Overview { get; set; }
        public string ImageUrl { get; set; }
        // Add additional properties as needed
    }
}