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
        public string Id { get; }
        [Required]
        public string Titulo { get; }
        [Required]
        [Range(1000,9999)]
        public int Ano { get; }
        [Required]
        [Range(0, 10)]
        public decimal Nota { get; }
    
        private Movie()
        {

        }

        public Movie(string idMovie, string tituloMovie, int anoMovie, decimal notaMovie)
        {
            Id = idMovie;
            Titulo = tituloMovie;
            Ano = anoMovie;
            Nota = notaMovie;
        }
    }
}
