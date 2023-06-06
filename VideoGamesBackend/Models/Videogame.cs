using System.ComponentModel.DataAnnotations;

namespace VideoGamesBackend.Models
{
    public class Videogame
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        public DateTime? ReleaseDate { get; set; } // esta propiedad podria llegar vacia /  no obligatoria
        public int Rating { get; set; }
        [Required]
        public string[] Platformas { get; set; } = new string[] { };
        public ICollection<Genre> Genres { get; set; } = new List<Genre>(); // aqui armamos la relacion entre los videojuegos y los generos
        public bool CreateDB { get; set;} = false;

    }
}
