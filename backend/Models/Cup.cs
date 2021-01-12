using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Cup
    {
        public Movie Winner { get; private set; }
        public Movie SecondPlace { get; private set; }


        private List<Movie> _movies; // o original é privado e só pode ser modificado por essa classe
        public IEnumerable<Movie> Movies => _movies.AsReadOnly(); // Copia exposta apenas para leitura

        private List<Movie> _cupOrdination; // o original é privado e só pode ser modificado por essa classe
        public IEnumerable<Movie> CupOrdination => _cupOrdination.AsReadOnly(); // Copia exposta apenas para leitura

        private List<Movie> _semifinals; // o original é privado e só pode ser modificado por essa classe
        public IEnumerable<Movie> Semifinals => _semifinals.AsReadOnly(); // Copia exposta apenas para leitura

        private List<Movie> _finals; // o original é privado e só pode ser modificado por essa classe
        public IEnumerable<Movie> Finals => _finals.AsReadOnly(); // Copia exposta apenas para leitura

        private List<Movie> _finalResult; // o original é privado e só pode ser modificado por essa classe
        public IEnumerable<Movie> FinalResult => _finalResult.AsReadOnly(); // Copia exposta apenas para leitura


        

        private Cup()
        {

        }

        public static Cup New()
        {
            // Metodo que cria a copa iniciando as listas

            return new Cup
            {
                _finalResult = new List<Movie>(),
                _movies = new List<Movie>(),
                _semifinals = new List<Movie>(),
                _finals = new List<Movie>()
            };
        }

        public void AddMovie(Movie movie)
        {
            //metodo para adicionar novos filmes à copa
            if(movie is null) throw new ArgumentNullException(nameof(movie));

            //verifico se ja foi atingida a quantidade máxima de filmes na copa
            if (_movies.Count == 8) throw new InvalidOperationException("Movies quantity already complete!");
            _movies.Add(movie);
        }
            
            

        public void CupResult()
        {
            if (_movies.Count != 8) throw new InvalidOperationException("Incorrect movies quantity!");

            _cupOrdination = _movies.OrderBy(m => m.Titulo.Trim()).ToList();

            //Variaveis auxiliares
            Match match;
            Movie matchWinner;
            List<Movie> finalsAux = new List<Movie>();

            int CupRange = _cupOrdination.Count() - 1;

            //Verifico o tamanho da lista
            int j = CupRange;
            //For com metade da lista, pois metade da lista enfrentará a outra metade
            // j-- usado para definir o indice ultimo da lista e irá diminuindo
            for (int i = 0; i <= (CupRange/2); i++, j--)
            {
                //definição da partida - primeiro enfrenta o ultimo, segundo o penultimo e assim por diante
                match = Match.New(_cupOrdination[i], _cupOrdination[j]);
                matchWinner = match.MatchWinner();
                // lista com os Filmes da semifinal
                _semifinals.Add(matchWinner);
            }

            for(int i = 0; i <= ((Semifinals.Count())/2); i += 2)
            {
                match = Match.New(_semifinals[i], _semifinals[i+1]);
                matchWinner = match.MatchWinner();
                _finals.Add(matchWinner);
            }

            //Partida final
            match = Match.New(_finals[0], _finals[1]);
            //Guardo o vencedor na propriedade da classe
            Winner = match.MatchWinner();

            //Adiciono o vencedor na lista de Resultado primeiro para ser o indice 0 da lista
            _finalResult.Add(Winner);

            //Usado variavel auxiliar para não perder ordenação da Final
            foreach(Movie m in Finals)
            {
                finalsAux.Add(m);
            }
            //Removo o vencedor para saber quem é o segundo lugar
            finalsAux.Remove(Winner);

            //Salvo o segundo lugar na propriedade da classe
            SecondPlace = finalsAux[0];

            //adiciono o segundo lugar na lista de resultado
            _finalResult.Add(SecondPlace);

        }
    }
}
