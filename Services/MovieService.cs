using Microsoft.Extensions.Configuration;
using MovieApplication.Enums;
using MovieApplication.Models.ApiResponseModels;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MovieApplication.Services
{
    public class MovieService
    {
        private readonly IConfiguration _config;


        public MovieService(IConfiguration config)
        {
            _config = config;
        }
        public async Task<MovieSearchResult> GetMovieAsync(string searchText, OrderChoice order)
        {
            if(searchText == "")
            {
                return new MovieSearchResult();
            }
            var client = new RestClient("https://imdb8.p.rapidapi.com/title/auto-complete?q=" + searchText);
            var request = new RestRequest();
            request.AddHeader("x-rapidapi-host", "imdb8.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", _config["RapidapiKey"]);
            RestResponse response =  await client.ExecuteAsync(request);
            MovieSearchResult movie =
                JsonSerializer.Deserialize<MovieSearchResult>(response.Content);
            if(order == OrderChoice.OrderbyTitleAscending)
            {
                movie.d = movie.d.OrderBy(result => result.l).ToList();
            }
            if(order == OrderChoice.OrderbyTitleDescending)
            {
                movie.d = movie.d.OrderByDescending(result => result.l).ToList();
            }
            return movie;
        }

    }
}
