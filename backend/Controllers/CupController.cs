using System;
using System.Collections.Generic;
using backend.DTO;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend.Controllers
{

    [Route("/cup")]
    [ApiController]
    public class CupController : ControllerBase
    {
        // POST: /cup>
        [HttpPost]
        public List<Movie> PostCupMovies([FromBody] MoviesDto movies)
        {
            try
            {
                Cup cup = Cup.New();

               foreach(Movie movie in movies.Movies)
               {
                    cup.AddMovie(movie);
               }

                cup.CupResult();

                List<Movie> response = new List<Movie>();

                foreach (Movie movie in cup.FinalResult)
                {
                    response.Add(movie);
                }

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
