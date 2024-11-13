using DataAccess.Models.Tables;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Implementation.Base
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //DbSet para las entidades
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Genres> Genres {  get; set; }

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

            // Configuración de claves primarias
            modelBuilder.Entity<Movies>()
                .HasKey(m => m.MovieId); 

            modelBuilder.Entity<Awards>()
                .HasKey(c => c.AwardId); 

            modelBuilder.Entity<Genres>()
                .HasKey(p => p.GenreId); 
        }
    }
}