using Microsoft.VisualStudio.TestTools.UnitTesting;
using backend.Models;

namespace MoviesCupTest
{
    [TestClass]
    public class MatchTest
    {
        [TestMethod]
        public void ReturnRightMovieWinner()
        {
            Movie movieExpected = Movie.New("tt1", "Teste 1", 2005, 9.9);
            Movie movieLoser = Movie.New("tt2", "Teste 2", 2009, 5.9);

            Match match = Match.New(movieLoser, movieExpected);

            Movie winner = match.MatchWinner();

            Assert.AreEqual(movieExpected, winner,"Filme vencedor incorreto");

        }
    }
}
