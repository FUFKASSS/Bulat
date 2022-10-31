using Enterprise.Web3.ProjectManager.Api.Core.Entities;
using System.Collections.Generic;

namespace Enterprise.Web3.ProjectManager.Api.Core.Abstractions
{
    /// <summary>
    /// Интерфейс сервисов скилов разработчика
    /// </summary>
    public interface IDeveloperSkillService
    {
        /// <summary>
        /// Получить скилы в группировке по типу
        /// </summary>
        /// <returns>Скилы</returns>
        Dictionary<string, List<DeveloperSkill>> GetDeveloperSkills();

        /// <summary>
        /// Добавить сущность в таблицу
        /// </summary>
        /// <param name="entity">Сущность скила разработчика</param>
        void Add(DeveloperSkill entity);

        /// <summary>
        /// Удалить сущность из таблицы
        /// </summary>
        /// <param name="id">ИД сущности скила разработчика</param>
        void Delete(int id);

        /// <summary>
        /// Обновить сущность в таблице
        /// </summary>
        /// <param name="entity">Сущность скила разработчика</param>
        void Update(DeveloperSkill entity);
    }
}
