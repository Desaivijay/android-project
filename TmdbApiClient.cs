using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace android_project
{
    public class TmdbApiClient
    {
        private const string BaseUrl = "https://api.themoviedb.org/3/";
        private const string ApiKey = "5f1cf8ab9bc249f701a7c4a96f1292f5"; // Replace with your actual API key

        public async Task<MovieResponse> GetPopularMoviesAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"{BaseUrl}movie/popular?api_key={ApiKey}";

                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
                MovieResponse movieResponse = JsonConvert.DeserializeObject<MovieResponse>(json);

                return movieResponse;
            }
        }
    }
}

