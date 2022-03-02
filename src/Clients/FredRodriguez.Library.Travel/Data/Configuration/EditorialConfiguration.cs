using FredRodriguez.Library.Travel.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace FredRodriguez.Library.Travel.Data.Configuration
{
    public class EditorialConfiguration
    {
        public EditorialConfiguration(EntityTypeBuilder<Editorial> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.id);
            entityBuilder.Property(x => x.nombre).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.sede).IsRequired().HasMaxLength(50);

            var editorial = new List<Editorial>();

            for (var i = 1; i < 10; i++)
            {
                editorial.Add(new Editorial
                {
                    id = i,
                    nombre = "Editorial " + i.ToString(),
                     sede = $"Sede {i}"

                }); 
            }

            entityBuilder.HasData(editorial);
        }
    }
}
