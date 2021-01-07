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
            Match match;
            Movie matchWinner;
            List<Movie> Semifinals = new List<Movie>();
            List<Movie> final = new List<Movie>();
            List<Movie> Ranked = new List<Movie>();

            int j = Movies.Count();
            for (int i = 0; i < (Movies.Count()/2); i++, j--)
            {
                match = new Match(Movies[i], Movies[j]);
                matchWinner = match.MatchWinner();
                Semifinals.Add(matchWinner);
            }

            for(int i = 0; i < (Semifinals.Count()/2); i += 2)
            {
                match = new Match(Movies[i], Movies[i+1]);
                matchWinner = match.MatchWinner();
                final.Add(matchWinner);
            }

            match = new Match(final[0], final[1]);
            matchWinner = match.MatchWinner();

            final.Remove(matchWinner);
            Ranked.Add(matchWinner);

            Ranked.Add(final[0]);

            return Ranked;
        }
    }
}
