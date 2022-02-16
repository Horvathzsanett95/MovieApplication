using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApplication.Models.ApiResponseModels
{
    // Model of the IMDb api's movie search result
    public class MovieSearchResult
    {
        // The collection of the movie search result
        public List<d> d { get; set; }

        // The search string
        public string q { get; set; }

        public int v { get; set; }
    }

    // Model of the movie that results in the search
    public class d
    {
        // The id of the search result
        public string id { get; set; }

        // The title of the search result
        public string l { get; set; }

        public i i { get; set; }
    }

    public class i
    {
        public string imageUrl { get; set; }
    }
}
