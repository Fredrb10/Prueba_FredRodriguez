using FredRodriguez.Library.Travel.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace FredRodriguez.Library.Travel.Data.Configuration
{
    public class LibroConfiguration
    {
        public LibroConfiguration(EntityTypeBuilder<Libro> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.isbn);
            entityBuilder.Property(x => x.titulo).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.sinopsis).IsRequired().HasMaxLength(200);
            entityBuilder.Property(x => x.n_paginas).IsRequired().HasMaxLength(3);

            //Libros por defecto
            var libros = new List<Libro>();
            
            for(var i = 1; i < 10; i++)
            {
                libros.Add(new Libro
                {
                    id = System.Guid.NewGuid(),
                    isbn = "978-958-5191-95-" + i.ToString(),
                    titulo = "Libro " + i.ToString(),
                    sinopsis = $"Sinopsis libro {i} ",
                    n_paginas = 10,
                     id_Editorial = i

                });   
            }

            entityBuilder.HasData(libros);
        }
    }
}
