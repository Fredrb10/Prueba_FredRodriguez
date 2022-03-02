using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FredRodriguez.Library.Travel.Models
{
    public class Libro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
     
        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string isbn { get; set; }
        public int id_Editorial { get; set; }
        [Required(ErrorMessage ="{0} es un campo obligatorio")]  
        [StringLength(50, ErrorMessage ="El {0} debe tener minimo {2} y maximo {1} caracteres", MinimumLength = 2)]
        [Display(Name ="Título")]
        public string titulo { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [StringLength(200, ErrorMessage = "El {0} debe tener minimo {2} y maximo {1} caracteres", MinimumLength = 10)]
        public string sinopsis { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [RegularExpression("^[0-9]*$")]
        [Display(Name = "Numero de paginas")]
        public int n_paginas { get; set; }
    }
}
