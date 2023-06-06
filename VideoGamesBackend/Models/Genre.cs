using System.ComponentModel.DataAnnotations;

namespace VideoGamesBackend.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        //public ICollection<Videogame> Videogames { get;set; } = new List<Videogame>();
        public bool CreateDB { get; set; } = false;
    }
}
