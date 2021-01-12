using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using backend.DTO;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
                Cup cup = new Cup(movies.Movies);

                List<Movie> cupResult = cup.CupResult();

                return cupResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        HttpClient client = new HttpClient();
        // GET: /movies>
        [HttpGet]
        public async Task<List<Movie>> GetAllMovies()
        {
            try
            {
                string url = "http://copafilmes.azurewebsites.net/api/filmes";
                var response = await client.GetStringAsync(url);
                var movies = JsonConvert.DeserializeObject<List<Movie>>(response);
                return movies;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
