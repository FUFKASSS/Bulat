using Enterprise.Web3.ProjectManager.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Enterprise.Web3.ProjectManager.Api.Data.PostgreSql.Configurations
{
    /// <summary>
    /// Конфигурация <see cref="Skill"/>
    /// </summary>
    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.ToTable("skill");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Name)
                .HasColumnName("name");

            builder.Property(x => x.Description)
                .HasColumnName("description");

            builder.Property(x => x.SkillTypeId)
                .HasColumnName("skill_type_id");

            builder.Property(x => x.MaxPoints)
                .HasColumnName("max_points");

            builder.Property(x => x.CreatedOn)
                .HasColumnName("created_on");

            builder.HasOne(x => x.SkillType)
                .WithMany(x => x.Skills)
                .HasForeignKey(x => x.SkillTypeId)
                .HasPrincipalKey(x => x.Id)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
