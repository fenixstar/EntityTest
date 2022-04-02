using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Library
{
    public class NationalityInfoConfiguration : IEntityTypeConfiguration<NationalityInfo>
    {
        public void Configure(EntityTypeBuilder<NationalityInfo> builder)
        {
            builder.HasKey(x => x.Id);


        }
    }
}
