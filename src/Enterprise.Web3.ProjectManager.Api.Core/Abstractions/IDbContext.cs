using Enterprise.Web3.ProjectManager.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Enterprise.Web3.ProjectManager.Api.Core.Abstractions
{
    /// <summary>
    /// Контекст БД
    /// </summary>
    public interface IDbContext
    {
        /// <summary>
        /// Скиллы
        /// </summary>
        DbSet<Skill> Skills { get; }

        /// <summary>
        /// Типы скилов
        /// </summary>
        DbSet<SkillType> SkillTypes { get; }

        /// <summary>
        /// Заказчики
        /// </summary>
        DbSet<Consumer> Consumers { get; }

        /// <summary>
        /// Типы заказчиков
        /// </summary>
        DbSet<ConsumerType> ConsumerTypes { get; }

        /// <summary>
        /// Сохранить изменения единицы работы
        /// </summary>
        /// <param name="cancellationToken">Токен отмены запроса</param>
        /// <returns>-</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Сохранить изменения единицы работы
        /// </summary>
        /// <returns>-</returns>
        int SaveChanges();
    }
}
