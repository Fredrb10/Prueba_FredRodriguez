using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FredRodriguez.Library.Travel.Models
{
    public class Autor
    {
        
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string nombres { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string apellidos { get; set; }
    }
}
