using Hapibee.Backend.Application.Domain;
using JsonNet.ContractResolvers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Hapibee.Backend.Application.Infra.Data
{
    internal class ApiaryEntityMapper : IEntityTypeConfiguration<Apiary>
    {
        private static readonly JsonSerializerSettings Settings = new()
        {
            ContractResolver = new PrivateSetterContractResolver()
        };

        public void Configure(EntityTypeBuilder<Apiary> builder)
        {
            builder.Property(x => x.Id);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ApiaryCode);
            builder.HasIndex(x => x.ApiaryCode).IsUnique();
            builder.Property(x => x.BeekeeperCode);
            builder.Property(x => x.IsLocatedInControlledArea);

            builder.Property(x => x.Location)
                .HasConversion(
                    @object => JsonConvert.SerializeObject(@object),
                    json => JsonConvert.DeserializeObject<CoordinatePoints>(json, Settings));

            builder.Property(x => x.CreationDate);

            builder.HasMany(ia => ia.Hives)
                .WithOne(ia => ia.Apiary)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(ia => ia.Requests)
                .WithOne(ia => ia.Apiary)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.CreationStatusType);
        }
    }
}