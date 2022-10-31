using Enterprise.Web3.ProjectManager.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Enterprise.Web3.ProjectManager.Api.Data.PostgreSql.Configurations
{

    /// <summary>
    ///  Конфигурация <see cref="Consumer"/>
    /// </summary>
    public class ConsumerConfiguration : IEntityTypeConfiguration<Consumer>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Consumer> builder)
        {
            builder.ToTable("consumer");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Name)
                .HasColumnName("name");

            builder.Property(x => x.Description)
                .HasColumnName("description");

            builder.Property(x => x.Inn)
                .HasColumnName("inn");

            builder.Property(x => x.Address)
                .HasColumnName("address");

            builder.Property(x => x.Email)
                .HasColumnName("email");

            builder.Property(x => x.ConsumerTypeId)
                .HasColumnName("consumer_type_id");

            builder.HasOne(x => x.ConsumerType)
                .WithMany(x => x.Consumers)
                .HasForeignKey(x => x.ConsumerTypeId)
                .HasPrincipalKey(x => x.Id)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
