using Library;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EntityTest
{
    public class EntityTestContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.json", optional: false);
            var config = configurationBuilder.Build();
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseNpgsql(config.GetConnectionString("main"))
                .Options; 
            return new ApplicationContext(options);
        }
    }
}
