using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EntityTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.json", optional: false);

            var config = configurationBuilder.Build();

            var options = new DbContextOptionsBuilder<AppContext>()
                .UseNpgsql(config.GetConnectionString("main"))
                .Options;
            var ctx = new AppContext(options);
            ctx.InitializeDb();
        }
    }

}