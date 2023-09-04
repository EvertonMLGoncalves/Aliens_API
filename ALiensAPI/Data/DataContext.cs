using APIALiens.Models;
using Microsoft.EntityFrameworkCore;

namespace APIALiens.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Alien> Aliens { get; set; }
        public DbSet<Planeta> Planetas { get; set; }
        public DbSet<Poder> Poderes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Alien>()
                .HasMany(a => a.Poderes)
                .WithMany(p => p.AliensQuePossuem)
                .UsingEntity<Dictionary<string, object>>
                (
                "AlienPoder",
                j => j.HasOne<Poder>().WithMany().HasForeignKey("PoderId"),
                j => j.HasOne<Alien>().WithMany().HasForeignKey("AlienId")
                );

            modelBuilder.Entity<Alien>()
                .HasOne(a => a.PlanetaNatal)
                .WithMany(p => p.AliensHabitantes)
                .HasForeignKey(a => a.PlanetaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
