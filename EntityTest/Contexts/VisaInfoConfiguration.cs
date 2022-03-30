using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityTest
{
    public class VisaInfoConfiguration : IEntityTypeConfiguration<VisaInfo>
    {
        public void Configure(EntityTypeBuilder<VisaInfo> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
