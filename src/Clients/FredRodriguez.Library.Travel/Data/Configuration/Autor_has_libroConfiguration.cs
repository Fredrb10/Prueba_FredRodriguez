using FredRodriguez.Library.Travel.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace FredRodriguez.Library.Travel.Data.Configuration
{
    public class Autor_has_libroConfiguration
    {
        public Autor_has_libroConfiguration(EntityTypeBuilder<Autor_has_libro> entityBuilder)
        {
          


            var autorLibro = new List<Autor_has_libro>();
            for (var i = 1; i < 10; i++)
            {
                autorLibro.Add(new Autor_has_libro
                {
                    id = i,
                     autor_id = i,
                      libro_isbn = "978-958-5191-95-" + i.ToString()

                });
            }


            entityBuilder.HasData(autorLibro);
        }
    }
}
