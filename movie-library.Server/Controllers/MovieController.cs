using Microsoft.AspNetCore.Mvc;

namespace movie_library.Server.Controllers
{
    [ApiController]
    [Route("mymovies")]
    public class MovieController : Controller
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> Get()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://filmy.programdemo.pl/");
                var response = await client.GetAsync("mymovies");
                response.EnsureSuccessStatusCode();
                var movies = await response.Content.ReadFromJsonAsync<IEnumerable<Movie>>();
                return Ok(movies);
            }
        }
    }

    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }
        public int Rate { get; set; }
    }
}
