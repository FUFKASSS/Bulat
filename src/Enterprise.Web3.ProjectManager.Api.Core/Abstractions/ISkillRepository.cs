using Enterprise.Web3.ProjectManager.Api.Core.Entities;
using System.Collections.Generic;

namespace Enterprise.Web3.ProjectManager.Api.Data.PostgreSql.Repositories
{
    /// <summary>
    /// ыапукрку
    /// </summary>
    public interface ISkillRepository
    {
        /// <summary>
        /// варврукр
        /// </summary>
        /// <param name="entity">укрукр</param>
        /// <returns>укрукр</returns>
        int Add(Skill entity);

        /// <summary>
        /// Получает из базы данных все записи таблицы
        /// </summary>
        /// <returns>Список умений</returns>
        List<Skill> Get();
    }
}
