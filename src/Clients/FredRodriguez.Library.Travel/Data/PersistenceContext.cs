using FredRodriguez.Library.Travel.Data.Configuration;
using FredRodriguez.Library.Travel.Models;
using Microsoft.EntityFrameworkCore;

namespace FredRodriguez.Library.Travel.Data
{
    public class PersistenceContext : DbContext
    {
        public PersistenceContext(DbContextOptions<PersistenceContext> options) : base(options)
        {

        }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Autor_has_libro> Autores_Has_Libros { get; set; }
        public DbSet<Editorial> Editoriales { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema("FredRodriguez");

            ModelConfig(builder);
        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new AutorConfiguration(modelBuilder.Entity<Autor>());
            new EditorialConfiguration(modelBuilder.Entity<Editorial>());
            new LibroConfiguration(modelBuilder.Entity<Libro>());
        }

    }
}
