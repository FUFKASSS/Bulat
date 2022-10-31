using System.Collections.Generic;

namespace Enterprise.Web3.ProjectManager.Api.Console.Abstractions
{
    /// <summary>
    /// Интерфейс репозитория требований к разработчику
    /// </summary>
    public interface IDeveloperRequirementRepository
    {
        /// <summary>
        /// Создает строку в таблице
        /// </summary>
        /// <param name="entity">айди проекта, айди фичи и т.д.</param>
        /// <returns>Количество изменненых ячеек</returns>
        int Add(DeveloperRequirement entity);

        /// <summary>
        /// Получает из базы данных все записи таблицы
        /// </summary>
        /// <returns>Список требований к разработчику</returns>
        List<DeveloperRequirement> Get();

        /// <summary>
        /// Удалить строку с заданным айди
        /// </summary>
        /// <param name="id">айди</param>
        void Delete(int Id);

        /// <summary>
        /// Изменить строку в таблице
        /// </summary>
        /// <param name="entity">айди проекта, айди фичи и т.д.</param>
        void Update(DeveloperRequirement entity);

        /// <summary>
        /// Получить список проектов по ИД
        /// </summary>
        /// <param name="Id">ИД</param>
        /// <returns>Проекты</returns>
        List<DeveloperRequirement> GetById(int Id);
    }
}
