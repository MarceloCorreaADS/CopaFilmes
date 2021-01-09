using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Match
    {
        public Movie Movie1st;
        public Movie Movie2st;

        private Match()
        {

        }

        public Match(Movie Movie1stMatch, Movie Movie2stMatch)
        {
            Movie1st = Movie1stMatch;
            Movie2st = Movie2stMatch;            
        }

        public Movie MatchWinner()
        {
            List<Movie> UnorderedMovies = new List<Movie>();
            UnorderedMovies.Add(Movie1st);
            UnorderedMovies.Add(Movie2st);

            // Regra de empate: Definido pela ordem alfabética.
            // Filmes perdem a ordenação por causa das chaves, por isso reoordeno antes de realizar a disputa
            List<Movie> orderedMovies = UnorderedMovies.OrderBy(m => m.Titulo.Trim()).ToList();
            // Se a nota do primeiro filme for maior ou igual a do segundo ele vence.
            Movie winner = orderedMovies[0].Nota >= orderedMovies[1].Nota ? orderedMovies[0] : orderedMovies[1];

            return winner;
        }
    }
}
