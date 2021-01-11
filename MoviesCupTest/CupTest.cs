using Microsoft.VisualStudio.TestTools.UnitTesting;
using backend.Models;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics.CodeAnalysis;

namespace MoviesCupTest
{
    [TestClass]
    public class CupTest
    {
        // MoviesCup = Preencher com os filmes que vão participar da Copa Filmes
        // ReturnExpected = Preencher com os filmes corretos que devem retornar
        [TestMethod]
        public void OrdenationMoviesIsCorrect()
        {
            List<Movie> MoviesCup = new List<Movie>();
            List<Movie> ReturnExpected = new List<Movie>();

            MoviesCup.Add(new Movie("tt3606756", "Os Incríveis 2", 2018, 8.5));
            MoviesCup.Add(new Movie("tt4881806", "Jurassic World: Reino Ameaçado", 2018, 6.7));
            MoviesCup.Add(new Movie("tt5164214", "Oito Mulheres e um Segredo", 2018, 6.3));
            MoviesCup.Add(new Movie("tt7784604", "Hereditário", 2018, 7.8));
            MoviesCup.Add(new Movie("tt4154756", "Vingadores: Guerra Infinita", 2018, 8.8));
            MoviesCup.Add(new Movie("tt5463162", "Deadpool 2", 2018, 8.1));
            MoviesCup.Add(new Movie("tt3778644", "Han Solo: Uma História Star Wars", 2018, 7.2));
            MoviesCup.Add(new Movie("tt3501632", "Thor: Ragnarok", 2017, 7.9));

            ReturnExpected.Add(new Movie("tt5463162", "Deadpool 2", 2018, 8.1));
            ReturnExpected.Add(new Movie("tt3778644", "Han Solo: Uma História Star Wars", 2018, 7.2));
            ReturnExpected.Add(new Movie("tt7784604", "Hereditário", 2018, 7.8));
            ReturnExpected.Add(new Movie("tt4881806", "Jurassic World: Reino Ameaçado", 2018, 6.7));
            ReturnExpected.Add(new Movie("tt5164214", "Oito Mulheres e um Segredo", 2018, 6.3));
            ReturnExpected.Add(new Movie("tt3606756", "Os Incríveis 2", 2018, 8.5));
            ReturnExpected.Add(new Movie("tt3501632", "Thor: Ragnarok", 2017, 7.9));
            ReturnExpected.Add(new Movie("tt4154756", "Vingadores: Guerra Infinita", 2018, 8.8));

            Cup CupMovies = new Cup(MoviesCup);

            List<Movie> CupMoviesOrdination = CupMovies.CupOrdination;

            CollectionAssert.AreEqual(ReturnExpected, CupMoviesOrdination, new MovieListComparer(), "Copa ordenada incorretamente!");
        }

        [TestMethod]
        public void SemifinalsResultsIsCorrect()
        {
            List<Movie> MoviesCup = new List<Movie>();
            List<Movie> ReturnExpected = new List<Movie>();

            MoviesCup.Add(new Movie("tt3606756", "Os Incríveis 2", 2018, 8.5));
            MoviesCup.Add(new Movie("tt4881806", "Jurassic World: Reino Ameaçado", 2018, 6.7));
            MoviesCup.Add(new Movie("tt5164214", "Oito Mulheres e um Segredo", 2018, 6.3));
            MoviesCup.Add(new Movie("tt7784604", "Hereditário", 2018, 7.8));
            MoviesCup.Add(new Movie("tt4154756", "Vingadores: Guerra Infinita", 2018, 8.8));
            MoviesCup.Add(new Movie("tt5463162", "Deadpool 2", 2018, 8.1));
            MoviesCup.Add(new Movie("tt3778644", "Han Solo: Uma História Star Wars", 2018, 7.2));
            MoviesCup.Add(new Movie("tt3501632", "Thor: Ragnarok", 2017, 7.9));


            ReturnExpected.Add(new Movie("tt4154756", "Vingadores: Guerra Infinita", 2018, 8.8));
            ReturnExpected.Add(new Movie("tt3501632", "Thor: Ragnarok", 2017, 7.9));
            ReturnExpected.Add(new Movie("tt3606756", "Os Incríveis 2", 2018, 8.5));
            ReturnExpected.Add(new Movie("tt4881806", "Jurassic World: Reino Ameaçado", 2018, 6.7));
          
            Cup CupMovies = new Cup(MoviesCup);

            CupMovies.CupResult();

            List<Movie> CupMoviesSemifinals = CupMovies.Semifinals;

            CollectionAssert.AreEqual(ReturnExpected, CupMoviesSemifinals, new MovieListComparer(), "Partidas semifnais incorretas!");
        }

        [TestMethod]
        public void finalsResultsIsCorrect()
        {
            List<Movie> MoviesCup = new List<Movie>();
            List<Movie> ReturnExpected = new List<Movie>();

            MoviesCup.Add(new Movie("tt3606756", "Os Incríveis 2", 2018, 8.8));
            MoviesCup.Add(new Movie("tt4881806", "Jurassic World: Reino Ameaçado", 2018, 6.7));
            MoviesCup.Add(new Movie("tt5164214", "Oito Mulheres e um Segredo", 2018, 6.3));
            MoviesCup.Add(new Movie("tt7784604", "Hereditário", 2018, 7.8));
            MoviesCup.Add(new Movie("tt4154756", "Vingadores: Guerra Infinita", 2018, 8.8));
            MoviesCup.Add(new Movie("tt5463162", "Deadpool 2", 2018, 8.1));
            MoviesCup.Add(new Movie("tt3778644", "Han Solo: Uma História Star Wars", 2018, 7.2));
            MoviesCup.Add(new Movie("tt3501632", "Thor: Ragnarok", 2017, 7.9));

            
            ReturnExpected.Add(new Movie("tt4154756", "Vingadores: Guerra Infinita", 2018, 8.8));
            ReturnExpected.Add(new Movie("tt3606756", "Os Incríveis 2", 2018, 8.8));



            Cup CupMovies = new Cup(MoviesCup);

            CupMovies.CupResult();

            List<Movie> CupMoviesfinals = CupMovies.Finals;

            CollectionAssert.AreEqual(ReturnExpected, CupMoviesfinals, new MovieListComparer(), "Partida final incorreta!");
        }

        [TestMethod]
        public void ReturnMovieListWith1stAnd2stPlaces()
        {
            List<Movie> MoviesCup = new List<Movie>();
            List<Movie> ReturnExpected = new List<Movie>();

            MoviesCup.Add(new Movie("tt3606756", "Os Incríveis 2", 2018, 8.5));
            MoviesCup.Add(new Movie("tt4881806","Jurassic World: Reino Ameaçado",2018,6.7));
            MoviesCup.Add(new Movie("tt5164214","Oito Mulheres e um Segredo",2018,6.3));
            MoviesCup.Add(new Movie("tt7784604","Hereditário",2018,7.8));
            MoviesCup.Add(new Movie("tt4154756","Vingadores: Guerra Infinita",2018,8.8));
            MoviesCup.Add(new Movie("tt5463162","Deadpool 2",2018,8.1));
            MoviesCup.Add(new Movie("tt3778644","Han Solo: Uma História Star Wars",2018,7.2));
            MoviesCup.Add(new Movie("tt3501632","Thor: Ragnarok",2017,7.9));

            
            ReturnExpected.Add(new Movie("tt4154756", "Vingadores: Guerra Infinita",2018,8.8));
            ReturnExpected.Add(new Movie("tt3606756", "Os Incríveis 2", 2018, 8.8));


            Cup CupMovies = new Cup(MoviesCup);

            List<Movie> ResultCup = CupMovies.CupResult();

            CollectionAssert.AreEqual(ReturnExpected, ResultCup, new MovieListComparer(), "Lista Final incorreta");
            
        }

        private class MovieListComparer : Comparer<Movie>
        {
            public override int Compare([AllowNull] Movie x, [AllowNull] Movie y)
            {

                int i = x.Id.CompareTo(y.Id);

                return i;
            }
        }
    }
}
