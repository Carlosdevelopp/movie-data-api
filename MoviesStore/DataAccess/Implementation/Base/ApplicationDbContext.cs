using DataAccess.Models.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementation.Base
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //DbSet para las entidades
        public DbSet<Movies> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de la relación uno a muchos
            modelBuilder.Entity<Movies>()
                .HasOne(m => m.Genres)
                .WithMany(g => g.Movies)
                .HasForeignKey(m => m.GenreId);

            modelBuilder.Entity<Movies>()
                .HasOne(a => a.Awards)
                .WithMany(c => c.Movies)
                .HasForeignKey(a => a.AwardId);

            // Configuración de claves primarias y otras restricciones si es necesario
            modelBuilder.Entity<Movies>()
                .HasKey(m => m.MovieId); // Configura la clave primaria

            modelBuilder.Entity<Awards>()
                .HasKey(c => c.AwardId); // Clave primaria para Category

            modelBuilder.Entity<Genres>()
                .HasKey(p => p.GenreId); // Clave primaria para Product
        }
    }
}