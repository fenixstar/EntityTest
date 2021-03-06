using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Library
{
    public class InternationalPassportInfoVisaInfoConfiguration : IEntityTypeConfiguration<InternationalPassportInfoVisaInfo>
    {
        public void Configure(EntityTypeBuilder<InternationalPassportInfoVisaInfo> builder)
        {
            builder.HasKey(ipv => new { ipv.VisaInfoId, ipv.InternationalPassportId});
            
            builder.HasOne(ipv => ipv.InternationalPassportInfo)
                .WithMany(ip => ip.InternationalPassportInfoVisaInfos)
                .HasForeignKey(ipv => ipv.InternationalPassportId)
                .OnDelete(DeleteBehavior.Cascade); ;

            builder.HasOne(ipv => ipv.VisaInfo)
                .WithMany(v => v.InternationalPassportInfoVisaInfos)
                .HasForeignKey(ipv => ipv.VisaInfoId)
                .OnDelete(DeleteBehavior.Cascade); ;
        }
    }
}
