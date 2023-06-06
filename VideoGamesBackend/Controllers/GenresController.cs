using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoGamesBackend.Models;

namespace VideoGamesBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly AppDbContext _context; // creamos esta varaible para poder acceder al contexto de la base de datos

        // Inizializamos el contructor con el contexto de la base de datos
        public GenresController(AppDbContext context)
        {
            _context = context; //
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var genres = await _context.Genres.ToListAsync();
                return Ok(genres);
            }
            catch (Exception ex)
            {
                return BadRequest($"Hubo un error al traer los generos: {ex.Message}");
            }
        }



    }
}
