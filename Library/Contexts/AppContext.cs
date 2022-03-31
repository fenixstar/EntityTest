using Microsoft.EntityFrameworkCore;
namespace EntityTest
{
    public class AppContext: DbContext
    {
        private string ConfigString;
        public DbSet<PassportInfo> Passports { get; set; } = null!;
        public DbSet<InternationalPassportInfo> internationalPassportInfos { get; set; } = null!;
        public DbSet<NationalityInfo> NationalityInfos { get; set; } = null!;
        public DbSet<VisaInfo> VisaInfos { get; set; } = null!;

        public AppContext(DbContextOptions<AppContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PassportInfoConfiguration());
            modelBuilder.ApplyConfiguration(new NationalityInfoConfiguration());   
            modelBuilder.ApplyConfiguration(new VisaInfoConfiguration());
            modelBuilder.ApplyConfiguration(new NationalityInfoConfiguration());
            modelBuilder.ApplyConfiguration(new InternationalPassportInfoVisaInfoConfiguration());

            modelBuilder.Entity<InternationalPassportInfo>().HasOne(ip => ip.PassportInfo)
                .WithOne(pi => pi.InternationalPassportInfo)
                .HasForeignKey<InternationalPassportInfo>(x => x.PassportInfoKey);

        }
    }
}