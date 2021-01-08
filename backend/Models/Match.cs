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
            // Regra de empate: Definido pela ordem alfabética.
            // Filmes já estão em ordem alfabética.
            // Se a nota do primeiro filme for maior ou igual a do segundo ele vence.
            Movie winner = Movie1st.Nota >= Movie2st.Nota ? Movie1st : Movie2st;

            return winner;
        }
    }
}
