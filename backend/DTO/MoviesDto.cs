using backend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DTO
{
    public class MoviesDto
    {
        [JsonProperty("movies")]
        public List<Movie> Movies { get; set; }

        public MoviesDto()
        {

        }
    }
}
