using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Library
{
    public class ApplicationContext: DbContext
    { 
        public DbSet<PassportInfo> Passports { get; set; } = null!;
        public DbSet<InternationalPassportInfo> InternationalPassportInfos { get; set; } = null!;
        public DbSet<NationalityInfo> NationalityInfos { get; set; } = null!;
        public DbSet<VisaInfo> VisaInfos { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PassportInfoConfiguration());
            modelBuilder.ApplyConfiguration(new NationalityInfoConfiguration());   
            modelBuilder.ApplyConfiguration(new VisaInfoConfiguration());
            modelBuilder.ApplyConfiguration(new InternationalPassportInfoConfiguration());
            modelBuilder.ApplyConfiguration(new InternationalPassportInfoVisaInfoConfiguration());
        }
    }
}