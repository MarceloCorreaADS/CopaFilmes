using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Movie
    {
        [Required]
        [JsonProperty("id")]
        public string Id { get; set; }
        [Required]
        [JsonProperty("titulo")]
        public string Titulo { get; set; }
        [Required]
        [Range(1000,9999)]
        [JsonProperty("ano")]
        public int Ano { get; set; }
        [Required]
        [Range(0, 10)]
        [JsonProperty("nota")]
        public double Nota { get; set; }
    
        private Movie()
        {

        }

        public Movie(string idMovie, string tituloMovie, int anoMovie, double notaMovie)
        {
            Id = idMovie;
            Titulo = tituloMovie;
            Ano = anoMovie;
            Nota = notaMovie;
        }
    }
}
