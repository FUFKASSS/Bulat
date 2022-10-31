using Enterprise.Web3.ProjectManager.Api.Core.Entities;
using System.Collections.Generic;

namespace Enterprise.Web3.ProjectManager.Api.Core.Abstractions
{
    /// <summary>
    /// Интерфейс репозитория заказчика
    /// </summary>
    public interface IConsumerRepository
    {
        /// <summary>
        /// Создает готовый элемент в таблице
        /// </summary>
        /// <param name="entity">сущеность элемента</param>
        /// <returns>количество заданных ячеек</returns>
        int Add(Consumer entity);

        /// <summary>
        /// Получает из базы данных все записи таблицы
        /// </summary>
        /// <returns>Список</returns>
        List<Consumer> Get();

        /// <summary>
        /// Получает из базы данных все записи таблицы
        /// </summary>
        /// <returns>Список по Id</returns>
        List<Consumer> Get(int Id);

        /// <summary>
        /// Изменение объекта в проекте
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="entity">сущность</param>
        void Update(Consumer entity);

        /// <summary>
        /// Удаление проекта
        /// </summary>
        /// <param name="id">id</param>
        void Delete(int id);

        /// <summary>
        /// Создает таблицу
        /// </summary>
        void CreateTable();
    }
}
