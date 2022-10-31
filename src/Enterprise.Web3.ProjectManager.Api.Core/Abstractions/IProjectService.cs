using Enterprise.Web3.ProjectManager.Api.Core.Entities;
using System.Collections.Generic;

namespace Enterprise.Web3.ProjectManager.Api.Core.Abstractions
{
    /// <summary>
    /// Интерфейс по работе с cервисом обработки проектов
    /// </summary>
    public interface IProjectService
    {
        /// <summary>
        /// Получиь названия проектов в группе по типу
        /// </summary>
        /// <returns>Названия проектов</returns>
        Dictionary<string, List<Project>> GetProjectName();

        /// <summary>
        /// Обновляет запись строки по Id
        /// </summary>
        /// <param name="entity">Сущность строк</param>
        void Update(Project entity);

        /// <summary>
        /// Удаляет строку по Id
        /// </summary>
        /// <param name="id">Id строки</param>
        void Delete(int id);

        /// <summary>
        /// Добавляет данные
        /// </summary>
        /// <param name="entity">Сущность данных</param>
        void Add(Project entity);


        /// <summary>
        /// Создание таблицы
        /// </summary>
        void CreateTable();
    }
}
