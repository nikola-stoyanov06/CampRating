using CampRating.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CampRating.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Review>()
                .HasOne(r => r.CampingPlace)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.CampingPlaceId)
                .OnDelete(DeleteBehavior.Cascade);
        }
        public DbSet<Review> Review { get; set; }
        public DbSet<CampingPlace> CampingPlace { get; set; }
    }
}
