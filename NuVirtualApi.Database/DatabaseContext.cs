using NuVirtualApi.Database.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace NuVirtualApi.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { }

        public DbSet<FavoriteMeal> FavoriteMeals { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<NutritionGoal> NutritionGoals { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Workout> Workouts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
