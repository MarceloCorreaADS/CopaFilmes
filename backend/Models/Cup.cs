using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Cup
    {
        public List<Movie> Movies;
        public Movie Winner;
        public Movie SecondPlace;
        public List<Movie> CupOrdination;
        public List<Movie> Semifinals;
        public List<Movie> Finals;

        private Cup()
        {

        }

        public Cup(List<Movie> cupMovies)
        {
            // Recebendo a lista de filmes participantes ja à ordeno em ordem alfabética.
            Movies = cupMovies;
            CupOrdination = Movies.OrderBy(m => m.Titulo.Trim()).ToList();
            Semifinals = new List<Movie>();
            Finals = new List<Movie>();

        }

        public List<Movie> CupResult()
        {
            //Variaveis auxiliares
            Match match;
            Movie matchWinner;
            List<Movie> finalsAux = new List<Movie>();
            List<Movie> Ranked = new List<Movie>();

            int CupRange = CupOrdination.Count() - 1;

            //Verifico o tamanho da lista
            int j = CupRange;
            //For com metade da lista, pois metade da lista enfrentará a outra metade
            // j-- usado para definir o indice ultimo da lista e irá diminuindo
            for (int i = 0; i <= (CupRange/2); i++, j--)
            {
                //definição da partida - primeiro enfrenta o ultimo, segundo o penultimo e assim por diante
                match = new Match(CupOrdination[i], CupOrdination[j]);
                matchWinner = match.MatchWinner();
                // lista com os Filmes da semifinal
                Semifinals.Add(matchWinner);
            }

            for(int i = 0; i <= ((Semifinals.Count())/2); i += 2)
            {
                match = new Match(Semifinals[i], Semifinals[i+1]);
                matchWinner = match.MatchWinner();
                Finals.Add(matchWinner);
            }

            //Partida final
            match = new Match(Finals[0], Finals[1]);
            //Guardo o vencedor na propriedade da classe
            Winner = match.MatchWinner();
            //Adiciono o vencedor na lista de retorno primeiro para ser o indice 0 da lista
            Ranked.Add(Winner);

            //Usado variavel auxiliar para não perder ordenação da Final
            foreach(Movie m in Finals)
            {
                finalsAux.Add(m);
            }
            //Removo o vencedor para saber quem é o segundo lugar
            finalsAux.Remove(Winner);
            //Salvo o segundo lugar na propriedade da classe
            SecondPlace = finalsAux[0];

            //adiciono o segundo lugar na lista de retorno 
            Ranked.Add(SecondPlace);

            //Ranked[0] = Winner / Ranked[1] = SecondPlace
            return Ranked;
        }
    }
}
