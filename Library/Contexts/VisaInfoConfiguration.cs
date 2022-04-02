using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library
{
    public class VisaInfoConfiguration : IEntityTypeConfiguration<VisaInfo>
    {
        public void Configure(EntityTypeBuilder<VisaInfo> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
