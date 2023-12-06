using Microsoft.EntityFrameworkCore;

namespace LoadFileToDatabase.Database
{
    public class Context : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyDatabase;Integrated Security=True");
            }
        }
    }
}
