using Microsoft.EntityFrameworkCore;
using HomeworkApp.Model.DatabaseModels;

namespace HomeworkApp.Model
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Clothes> ClothesTable { get; set; }
    }
}