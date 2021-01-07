using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Cup
    {
        public List<Movie> Movies;

        private Cup()
        {

        }

        public Cup(List<Movie> cupMovies)
        {
            // Recebendo a lista de filmes participantes ja à ordeno em ordem alfabética.
            Movies = cupMovies.OrderBy(m => m.Titulo.Trim().Substring(m.Titulo.Trim().IndexOf(" "))).ToList();
        }

        public List<Movie> CupResult()
        {
            List<Movie> RankedMovies = new List<Movie>();
            List<Movie> NotRankedMovies = Movies;
            
            return RankedMovies;
        }
    }
}
