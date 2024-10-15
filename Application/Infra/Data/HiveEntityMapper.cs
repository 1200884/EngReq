using Hapibee.Backend.Application.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hapibee.Backend.Application.Infra.Data
{
    internal class HiveEntityMapper : IEntityTypeConfiguration<Hive>
    {
        public void Configure(EntityTypeBuilder<Hive> builder)
        {
            builder.Property(x => x.Id);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.HiveCode);
            builder.HasIndex(x => x.HiveCode).IsUnique();
            builder.Property(x => x.NumberOfHandles);
            builder.Property(x => x.NumberOfQueenBees);
        }
    }
}