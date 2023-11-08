using Eğitim_Portalı.Models;
using Microsoft.EntityFrameworkCore;

namespace Eğitim_Portalı.Data
{
    public class EğitimPortalıDbContext : DbContext
    {
        public EğitimPortalıDbContext(DbContextOptions<EğitimPortalıDbContext> options):base (options) 
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rol>()
                .HasMany(r => r.yetkiler)
                .WithMany(y => y.roller);

            modelBuilder.Entity<Eğitim>().Property(e => e.günlükFiyat).HasColumnType("decimal(18,2)");
        }

        public DbSet<Eğitim> eğitimler { get; set; }
        public DbSet<Kullanıcı> kullanıcılar { get; set; }
        public DbSet<AlınanEğitim> alınanEğitimler { get; set; }
        public DbSet<Rol> roller { get; set; }
        public DbSet<Yetki> yetkiler { get; set; }
    }    
}
