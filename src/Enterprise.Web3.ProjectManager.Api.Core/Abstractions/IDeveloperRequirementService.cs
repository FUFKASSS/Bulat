using Enterprise.Web3.ProjectManager.Api.Console;
using Enterprise.Web3.ProjectManager.Api.Core.Requests.DeveloperRequirementRequests;
using System.Collections.Generic;

namespace Enterprise.Web3.ProjectManager.Api.Core.Abstractions
{
    /// <summary>
    ///  Интерфейс требований к разработчику
    /// </summary>
    public interface IDeveloperRequirementService
    {
        /// <summary>
        /// Получить требования разработчика по списку 
        /// </summary>
        /// <returns>Скилл Айди</returns>
        Dictionary<string, List<DeveloperRequirement>> GetDeveloperRequirement();

        /// <summary>
        /// Создает строку в таблице
        /// </summary>
        /// <param name="entity">айди проекта, айди фичи и т.д.</param>
        void Add(DeveloperRequirement entity);

        /// <summary>
        /// Удалить строку с заданным айди
        /// </summary>
        /// <param name="id">айди</param>
        void Delete(int id);

        /// <summary>
        /// Изменяет строку в таблице
        /// </summary>
        /// <param name="entity">айди проекта, айди фичи и т.д.</param>
        void Update(DeveloperRequirement entity);

        /// <summary>
        /// Получает таблицу проектов из БД
        /// </summary>
        /// <returns>таблица проектов</returns>
        List<DeveloperRequirement> Get();

        /// <summary>
        /// Получает таблицу проектов из БД по айди
        /// </summary>
        /// <returns>таблица проектов</returns>
        /// /// <param name="id">айди</param>
        List<DeveloperRequirement> GetById(int id);
        /// <summary>
        /// Получение ответа с сущностью зароса
        /// </summary>
        /// <param name="enitity">сущность запроса</param>
        /// <returns>ИД</returns>
        SaveDeveloperRequirementResponse Add(SaveDeveloperRequirementRequest enitity);
    }
}
