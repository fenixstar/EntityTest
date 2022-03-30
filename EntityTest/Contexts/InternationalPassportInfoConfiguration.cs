using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityTest
{
    public class InternationalPassportInfoConfiguration : IEntityTypeConfiguration<InternationalPassportInfo>
    {
        public void Configure(EntityTypeBuilder<InternationalPassportInfo> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
