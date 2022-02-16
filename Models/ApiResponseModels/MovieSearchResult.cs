using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApplication.Models.ApiResponseModels
{
    //Model of the IMDb api's movie search result
    public class MovieSearchResult
    {
        public List<d> d { get; set; }

        public string q { get; set; }

        public int v { get; set; }
    }

    public class d
    {
        public string id { get; set; }

        public string l { get; set; }
    }
}
