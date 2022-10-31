using Enterprise.Web3.ProjectManager.Api.Core.Abstractions;
using Enterprise.Web3.ProjectManager.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Enterprise.Web3.ProjectManager.Api.Data.PostgreSql
{
    /// <summary>
    /// Контекст БД
    /// </summary>
    public class EfContext : DbContext, IDbContext
    {
        /// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="options">Параметры подключения к БД</param>
		public EfContext(
            DbContextOptions<EfContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Скиллы
        /// </summary>
        public DbSet<Skill> Skills { get; set; }

        /// <summary>
        /// Типы скилов
        /// </summary>
        public DbSet<SkillType> SkillTypes { get; set; }

        /// <summary>
        /// Заказчики
        /// </summary>
        public DbSet<Consumer> Consumers { get; set; }

        /// <summary>
        /// Типы заказчиков
        /// </summary>
        public DbSet<ConsumerType> ConsumerTypes { get; set; }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EfContext).Assembly);
        }
    }
}
