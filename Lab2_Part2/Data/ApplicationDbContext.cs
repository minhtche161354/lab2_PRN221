using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Lab2_Part2.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<SchoolContext>
    {
        public SchoolContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SchoolContext>();
            optionsBuilder.UseSqlServer("Server=YourServer; Database=YourDb; Integrated Security=true; MultipleActiveResultSets=true; Trusted_Connection=True");

            return new SchoolContext(optionsBuilder.Options);
        }
    }
}
