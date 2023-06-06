using Microsoft.EntityFrameworkCore;

namespace VideoGamesBackend.Models
{
    public class AppDbContext: DbContext // Heredamos de DbContext para poder conectarnos al contexto de la base de datos
    {
        // Realizamos el constructor dle contexto, le pasamos por parametros las opciones que seran dle tipo "<AppSbContext>"
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Videogame> Videogames { get; set;} // Creamos aqui el modelo de "Videogames" en la base de datos, que sera dle tipo "<Videogame>"
        public DbSet<Genre> Genres { get; set;} // Creamos aqui el modelo de "Genres" en la base de datos, que sera del tipo "<Genre>"
    }
}
