using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FreelancerFlow.API.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            optionsBuilder.UseSqlServer(
                "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Mock;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=True"
            );

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}