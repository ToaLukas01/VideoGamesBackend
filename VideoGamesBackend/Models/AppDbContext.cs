using Microsoft.EntityFrameworkCore;
using System.Linq;
using VideoGamesBackend.Controllers;
using VideoGamesBackend.Models;

namespace VideoGamesBackend.Models
{
    public class AppDbContext: DbContext // Heredamos de DbContext para poder conectarnos al contexto de la base de datos
    {
        // Realizamos el constructor dle contexto, le pasamos por parametros las opciones que seran dle tipo "<AppSbContext>"
        //public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Videogame> Videogames { get; set;} // Creamos aqui el modelo de "Videogames" en la base de datos, que sera dle tipo "<Videogame>"
        public DbSet<Genre> Genres { get; set;} // Creamos aqui el modelo de "Genres" en la base de datos, que sera del tipo "<Genre>"

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=VideogamesApiDB;Trusted_Connection=True;");
        }
    }

    public class GameController
    {
        public async Task SaveVideogamesToDB()
        {
            var apiController = new ApiController(); // Creamos una instancia de ApiController
            List<Videogame> videogames = await apiController.GetVideogamesFromAPI();

            using(var context = new AppDbContext())
            {
                foreach(var videogame in videogames)
                {
                    if(!context.Videogames.Any(v => v.Id == videogame.Id))
                    {
                        context.Videogames.Add(videogame);
                    }
                }
                context.SaveChanges();
            }
        }
    }


}
