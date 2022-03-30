using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace EntityTest
{
    public class NationalityInfoConfiguration : IEntityTypeConfiguration<NationalityInfo>
    {
        public void Configure(EntityTypeBuilder<NationalityInfo> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
