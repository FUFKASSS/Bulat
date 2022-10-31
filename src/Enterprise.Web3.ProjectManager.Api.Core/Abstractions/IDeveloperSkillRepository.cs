using Enterprise.Web3.ProjectManager.Api.Core.Entities;
using System.Collections.Generic;

namespace Enterprise.Web3.ProjectManager.Api.Core.Abstractions
{
    /// <summary>
    /// Репозиторий скиллов разработчика
    /// </summary>
    public interface IDeveloperSkillRepository
    {
        /// <summary>
        /// Удалить сущность из таблицы
        /// </summary>
        /// <param name="id">ИД сущности скила разработчика</param>
        void Delete(int id);

        /// <summary>
        /// Добавляет сущность в таблицу
        /// </summary>
        /// <param name="entity">Сущность скила разработчика</param>
        int Add(DeveloperSkill entity);

        /// <summary>
        /// Получает из базы данных все записи таблицы
        /// </summary>
        /// <returns>Список умений</returns>
        List<DeveloperSkill> Get();

        /// <summary>
        /// Обновить сущность в таблице
        /// </summary>
        /// <param name="entity">Сущность скила разработчика</param>
        void Update(DeveloperSkill entity);
    }
}
