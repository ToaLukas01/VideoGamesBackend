using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoGamesBackend.Models;

namespace VideoGamesBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideogameController : ControllerBase
    {
        private readonly AppDbContext _context; // creamos esta varaible para poder acceder al contexto de la base de datos

        // Inizializamos el contructor con el contexto de la base de datos
        public VideogameController(AppDbContext context)
        {
            _context = context; //
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var videogames = await _context.Videogames.ToListAsync();
                return Ok(videogames);
            }
            catch (Exception ex)
            {
                return BadRequest($"Hubo un error al traer los videojuegos: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var videogame = await _context.Videogames.FindAsync(id);
                if(videogame == null)
                {
                    return NotFound();
                }
                return Ok(videogame);
            }
            catch (Exception ex)
            {
                return BadRequest($"Hubo un error en el detalle del videojuegos: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var videogame = await _context.Videogames.FindAsync(id);
                if (videogame == null)
                {
                    return NotFound();
                }
                _context.Videogames.Remove(videogame);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Hubo un error al borrar el videojuegos: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Videogame videogame)
        {
            try
            {
                if(videogame.Name == null || videogame.Description == null || videogame.Platformas == null)
                {
                    return BadRequest($"El videojeugo debe tener campos obligatorios como el nombre, descripcion y plataformas");
                }
                _context.Videogames.Add(videogame);
                await _context.SaveChangesAsync();
                return Ok($"El videojuego fue creado con exito: {videogame}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Hubo un error al crear el videojuegos: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Videogame videogame)
        {
            try
            {
                if(id != videogame.Id)
                {
                    return BadRequest($"No se reconose el ID:{id} para editar");
                }
                var updateGame = await _context.Videogames.FindAsync(id);
                if(updateGame!= null)
                {
                    return BadRequest($"No se a encontrado el videojuego solicitado");
                }
                updateGame.Id = id;
                updateGame.Name = videogame.Name;
                updateGame.Description = videogame.Description;
                updateGame.ReleaseDate = videogame.ReleaseDate;
                updateGame.Rating = videogame.Rating;
                updateGame.Platformas = videogame.Platformas;
                updateGame.Genres = videogame.Genres;
                updateGame.CreateDB = videogame.CreateDB;

                await _context.SaveChangesAsync();
                return Ok($"Se a actualizaod el videojeugo: {videogame}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Hubo un error al editar el videojuegos: {ex.Message}");
            }
        }


    }
}
