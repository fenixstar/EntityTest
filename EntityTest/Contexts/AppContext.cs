using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace EntityTest
{
    public class PassportInfoConfigContext : IEntityTypeConfiguration<PassportInfo>
    {
        public void Configure(EntityTypeBuilder<PassportInfo> builder)
        {
            builder.ToTable("passport_info", schema: "passport_story");
            builder.Property(p => p.PassportId).IsRequired();
            builder.Property(p => p.FirstName).IsRequired();
            builder.Property(p => p.SecondName).IsRequired();
            builder.Property(p => p.nationalityInfo).IsRequired();
        }
    }
    public class NationalityInfoConfigContext : IEntityTypeConfiguration<NationalityInfo>
    {
        public void Configure(EntityTypeBuilder<NationalityInfo> builder)
        {
            builder.ToTable("nationality_info", schema: "passport_story");
            builder.Property(n => n.NationalityID).IsRequired();
            builder.Property(n => n.Name).IsRequired();
            builder.Property(n => n.DateStart).IsRequired();
        }
    }
    public class InternationalPassportInfoConfigContext : IEntityTypeConfiguration<InternationalPassportInfo>
    {
        public void Configure(EntityTypeBuilder<InternationalPassportInfo> builder)
        {
            builder.ToTable("international_passport_info", schema: "passport_story");
            builder.Property(ip => ip.InternationalPassportId).IsRequired();
            builder.Property(ip => ip.InternationalPassportFirstName).IsRequired();
            builder.Property(ip => ip.InternationalPassportLastName).IsRequired();
            builder.Property(ip => ip.DateStart).IsRequired();
            builder.Property(ip => ip.DateEnd).IsRequired();
        }
    }
    public class VisaInfoConfigContext : IEntityTypeConfiguration<VisaInfo>
    {
        public void Configure(EntityTypeBuilder<VisaInfo> builder)
        {
            builder.ToTable("visa_info", schema: "passport_story");
            builder.Property(v => v.VisaID).IsRequired();
            builder.Property(v => v.VisaStart).IsRequired();
            builder.Property(v => v.VisaEnd).IsRequired();
        }
    }
    public class AppContext: DbContext
    {
        private string ConfigString;
        public DbSet<PassportInfo> Passports { get; set; } = null!;
        public DbSet<InternationalPassportInfo> internationalPassportInfos { get; set; } = null!;
        public DbSet<NationalityInfo> NationalityInfos { get; set; } = null!;
        public DbSet<VisaInfo> VisaInfos { get; set; } = null!;
        public AppContext(string _host, string _port, string _database, string _username, string _password) 
        {
            ConfigString = string.Format("Host={0};Port={1};Database={2};Username={3};Password={4}", _host, _port, _database, _username, _password);
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {   
            optionsBuilder.UseNpgsql(ConfigString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PassportInfoConfigContext());
            modelBuilder.ApplyConfiguration(new NationalityInfoConfigContext());
            modelBuilder.ApplyConfiguration(new VisaInfoConfigContext());
            modelBuilder.ApplyConfiguration(new InternationalPassportInfoConfigContext());
            //modelBuilder.Entity<PassportInfo>().HasOne(p => p.nationalityInfo).WithMany(n => n.NationalityID)

        }
    }
}