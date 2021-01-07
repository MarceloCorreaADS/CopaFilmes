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
            Movie movieExpected = new Movie("tt1", "Teste 1", 2005, 9.9);
            Movie movieLoser = new Movie("tt2", "Teste 2", 2009, 5.9);

            Match match = new Match(movieLoser, movieExpected);

            Movie winner = match.MatchWinner();

            Assert.AreEqual(movieExpected, winner,"Filme vencedor incorreto");

        }
    }
}
