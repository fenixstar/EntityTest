using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library
{
    public class InternationalPassportInfoConfiguration : IEntityTypeConfiguration<InternationalPassportInfo>
    {
        public void Configure(EntityTypeBuilder<InternationalPassportInfo> builder)
        {
            builder.HasKey(x => x.Id);
            //modelBuilder.Entity<InternationalPassportInfo>()
            builder.HasOne(ip => ip.PassportInfo)
                .WithOne(pi => pi.InternationalPassportInfo)
                .HasForeignKey<InternationalPassportInfo>(x => x.PassportInfoKey);
        }
    }
}
