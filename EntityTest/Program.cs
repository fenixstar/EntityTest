using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Library;

namespace EntityTest
{
    class Program 
    {
        static void Main(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.json", optional: false);

            var config = configurationBuilder.Build();

            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseNpgsql(config.GetConnectionString("main"))
                .Options;
            var ctx = new ApplicationContext(options);
            ctx.InitializeDb();
            DataLayer.EmulateData(ctx); 
            var bus = new BuisnessLogicLayer();
            bus.ChangeNameInPassport("Tony", 1, ctx);
            bus.CreatePassport("Vladimir", "Mitrofanov",1, ctx);
        }
    }

}