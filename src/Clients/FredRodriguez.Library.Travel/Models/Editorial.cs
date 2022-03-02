using System.ComponentModel.DataAnnotations;

namespace FredRodriguez.Library.Travel.Models
{
    public class Editorial
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string sede { get; set; }
    }
}
