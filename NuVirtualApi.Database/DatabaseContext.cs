using NuVirtualApi.Database.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace NuVirtualApi.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                    .HasKey(u => new { u.Id });

            var familleA = new User
            {
                Id = 1,
                Birthday = new DateTime(1994, 07, 31),
                Email = "koalaviril@gmail.com",
                FirstName = "Nicolas",
                LastName = "Vigouroux",
                Height = 168,
                Weight = 76.1,
                Pseudo = "koalaviril",
                Password = "NuVirtualApi@01"
            };

            modelBuilder.Entity<User>().HasData(familleA);
        }
    }
}
