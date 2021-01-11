using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;
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
        [EnableCors(origins: "http://localhost/3000", headers: "*", methods: "*")]
        [HttpPost]
        public List<Movie> PostCupMovies([FromBody]MoviesDto movies)
        {
            Cup cup = new Cup(movies.Movies);

            List<Movie> cupResult = cup.CupResult();

            return cupResult;
        }
    }
}
