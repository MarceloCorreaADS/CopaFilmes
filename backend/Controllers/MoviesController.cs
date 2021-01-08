using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend.Controllers
{
    [Route("/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
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
