using Microsoft.EntityFrameworkCore;

namespace EntityTest
{
    public static class Extensions
    {
        public static void InitializeDb<TContext>(this TContext context)
            where TContext : DbContext
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
