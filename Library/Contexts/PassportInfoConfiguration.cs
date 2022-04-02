using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library
{
    public class PassportInfoConfiguration : IEntityTypeConfiguration<PassportInfo>
    {
        public void Configure(EntityTypeBuilder<PassportInfo> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
