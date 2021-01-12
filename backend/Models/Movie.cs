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

        public static Movie New(string idMovie, string tituloMovie, int anoMovie, double notaMovie)
        {

            if (string.IsNullOrWhiteSpace(idMovie)) throw new ArgumentNullException(nameof(idMovie));
            if (string.IsNullOrWhiteSpace(tituloMovie)) throw new ArgumentNullException(nameof(tituloMovie));
            if (anoMovie <= 0) throw new ArgumentOutOfRangeException(nameof(anoMovie));
            if (notaMovie < 0.0 || notaMovie > 10) throw new ArgumentOutOfRangeException(nameof(notaMovie));

            return new Movie
            {
                Id = idMovie,
                Titulo = tituloMovie,
                Ano = anoMovie,
                Nota = notaMovie
            };
            
        }
    }
}
