using FredRodriguez.Library.Travel.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace FredRodriguez.Library.Travel.Data.Configuration
{
    public class AutorConfiguration
    {
        public AutorConfiguration(EntityTypeBuilder<Autor> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.id);
            entityBuilder.Property(x => x.nombres).IsRequired();
            entityBuilder.Property(x => x.apellidos).IsRequired();


            var autor = new List<Autor>();

            for (var i = 1; i < 10; i++)
            {
                autor.Add(new Autor
                {
                     id = i,
                      nombres = "Nombre del autor " + i,
                      apellidos = $"Apellidos del autor {i}"

                });
            }

            entityBuilder.HasData(autor);
        }
    }
}
