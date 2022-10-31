using Enterprise.Web3.ProjectManager.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Enterprise.Web3.ProjectManager.Api.Data.PostgreSql.Configurations
{
    /// <summary>
    /// Конфигурация <see cref="SkillType"/>
    /// </summary>
    public class SkillTypeConfiguration : IEntityTypeConfiguration<SkillType>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<SkillType> builder)
        {
            builder.ToTable("skill_type");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Name)
                .HasColumnName("name");

            builder.HasMany(x => x.Skills)
                .WithOne(x => x.SkillType)
                .HasForeignKey(x => x.SkillTypeId)
                .HasPrincipalKey(x => x.Id)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
