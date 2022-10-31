using Enterprise.Web3.ProjectManager.Api.Core.Entities;
using System.Collections.Generic;

namespace Enterprise.Web3.ProjectManager.Api.Core.Abstractions
{
    /// <summary>
    /// Интерфейс по работе с репозиторием обработки проектов
    /// </summary>
    public interface IProjectRepository
    {
        /// <summary>
        /// Создать строку в таблице
        /// </summary>
        /// <param name="entity">Сущность проекта</param>
        /// <returns>Кол-во созданных строк</returns>
        int Add(Project entity);

        /// <summary>
        /// Изменение (обновление) объекта в проекте
        /// </summary>
        /// <param name="entity"></param>
        void Update(Project entity);

        /// <summary>
        /// Удаление проекта
        /// </summary>
        /// <param name="id">id</param>
        void Delete(int id);


        /// <summary>
        /// Получить список проектов
        /// </summary>
        /// <returns>кол-во проектов</returns>
        List<Project> Get();

        /// <summary>
        /// Создание таблицы
        /// </summary>
        void CreateTable();
    }
}
