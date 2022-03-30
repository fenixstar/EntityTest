using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityTest
{
    public class PassportInfoConfiguration : IEntityTypeConfiguration<PassportInfo>
    {
        public void Configure(EntityTypeBuilder<PassportInfo> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
