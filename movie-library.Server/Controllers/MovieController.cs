using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movie_library.Server;

[ApiController]
[Route("movies")]
public class MovieController : ControllerBase
{
    private readonly AppDbContext _context;

    public MovieController(AppDbContext context)
    {
        _context = context;
    }

    // GET: /movies
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
    {
        return await _context.Movies.ToListAsync();
    }

    // POST: /movies/sampleMovies
    [HttpPost("sampleMovies")]
    public async Task<ActionResult> SyncMoviesFromExternalApi()
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("https://filmy.programdemo.pl/");

            try
            {
                var response = await client.GetAsync("mymovies");
                response.EnsureSuccessStatusCode();
                var externalMovies = await response.Content.ReadFromJsonAsync<IEnumerable<Movie>>();

                if (externalMovies == null)
                {
                    return NotFound("No movies were retrieved from the external API.");
                }

                foreach (var externalMovie in externalMovies)
                {
                    var exists = await _context.Movies.AnyAsync(m => m.ExternalId == externalMovie.Id);

                    if (!exists)
                    {
                        var newMovie = new Movie
                        {
                            ExternalId = externalMovie.Id,
                            Title = externalMovie.Title,
                            Director = externalMovie.Director,
                            Year = externalMovie.Year,
                            Rate = externalMovie.Rate
                        };

                        _context.Movies.Add(newMovie);
                    }
                }

                await _context.SaveChangesAsync();

                return Ok("Movies from the external API have been successfully synchronized.");
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error fetching movies from external API: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }


    // POST: /mymovies
    [HttpPost]
    public async Task<IActionResult> AddMovie(Movie movie)
    {
        if (movie == null)
        {
            return BadRequest("Movie cannot be null");
        }

        movie.Id = 0;

        _context.Movies.Add(movie);
        await _context.SaveChangesAsync();

        return Ok();
    }

    // PUT: /mymovies/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMovie(int id, Movie movie)
    {
        if (id != movie.Id)
            return BadRequest();

        _context.Entry(movie).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Movies.Any(m => m.Id == id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // DELETE: /mymovies/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMovie(int id)
    {
        var movie = await _context.Movies.FindAsync(id);
        if (movie == null)
            return NotFound();

        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
