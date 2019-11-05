using System;
using Newtonsoft.Json;

namespace PrismFilms.Models
{
    public class Movie
    {
        [JsonProperty("image")]
        public string image { get; set; }

        [JsonProperty("releaseYear")]
        public string releaseYear { get; set; }

        [JsonProperty("rating")]
        public double rating { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }
    }
}
