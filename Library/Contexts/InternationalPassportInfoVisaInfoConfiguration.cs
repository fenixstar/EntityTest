using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace EntityTest
{
    public class InternationalPassportInfoVisaInfoConfiguration : IEntityTypeConfiguration<InternationalPassportInfoVisaInfo>
    {
        public void Configure(EntityTypeBuilder<InternationalPassportInfoVisaInfo> builder)
        {
            builder.HasKey(ipv => new { ipv.VisaInfoId, ipv.InternationalPassportId});
            
            builder.HasOne(ipv => ipv.InternationalPassportInfo)
                .WithMany(ip => ip.InternationalPassportInfoVisaInfos)
                .HasForeignKey(ipv => ipv.InternationalPassportId);

            builder.HasOne(ipv => ipv.VisaInfo)
                .WithMany(v => v.InternationalPassportInfoVisaInfos)
                .HasForeignKey(ipv => ipv.VisaInfoId);
        }
    }
}
