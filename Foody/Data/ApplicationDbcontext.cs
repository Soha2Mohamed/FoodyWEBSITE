using Foody.Models;
using Microsoft.EntityFrameworkCore;

namespace Foody.Data
{
    public class ApplicationDbcontext : DbContext
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options): base (options)
        {
                
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
       
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<FeaturedMeal> FeaturedMeals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Comment>()
    .HasOne(c => c.User)
    .WithMany(u => u.Comments)
    .HasForeignKey(c => c.UserId)
    .OnDelete(DeleteBehavior.NoAction);  // Disable cascading delete


            modelBuilder.Entity<Playlist>()
    .HasOne(c => c.User)
    .WithMany(u => u.Playlists)
    .HasForeignKey(c => c.UserId)
    .OnDelete(DeleteBehavior.NoAction);  // Disable cascading delete

            modelBuilder.Entity<Rating>()
    .HasOne(c => c.User)
    .WithMany(u => u.Ratings)
    .HasForeignKey(c => c.UserId)
    .OnDelete(DeleteBehavior.NoAction);  // Disable cascading delete


        }
    }
}
