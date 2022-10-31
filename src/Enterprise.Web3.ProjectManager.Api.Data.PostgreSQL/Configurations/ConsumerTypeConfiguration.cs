using Enterprise.Web3.ProjectManager.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Enterprise.Web3.ProjectManager.Api.Data.PostgreSql.Configurations
{
    /// <summary>
    /// Конфигурация <see cref="ConsumerType"/>
    /// </summary>
    public class ConsumerTypeConfiguration : IEntityTypeConfiguration<ConsumerType>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<ConsumerType> builder)
        {
            builder.ToTable("consumer_type");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Name)
                .HasColumnName("name");

            builder.HasMany(x => x.Consumers)
                .WithOne(x => x.ConsumerType)
                .HasForeignKey(x => x.ConsumerTypeId)
                .HasPrincipalKey(x => x.Id)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
