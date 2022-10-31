using Enterprise.Web3.ProjectManager.Api.Core.Entities;
using Enterprise.Web3.ProjectManager.Api.Core.Requests.ConsumerRequests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Enterprise.Web3.ProjectManager.Api.Core.Abstractions
{
    public interface IConsumerService
    {

        /// <summary>
        /// Обновляет запись строки
        /// </summary>
        /// <param name="entity">Сущность строк</param>
        Task<UpdateConsumerResponse> Update(UpdateConsumerRequest entity);

        /// <summary>
        /// Удаляет строку по Id
        /// </summary>
        /// <param name="id">Id строки</param>
        Task<Consumer> Delete(int id);

        /// <summary>
        /// Получает таблицу из БД
        /// </summary>
        /// <returns>таблицу</returns>
        Task<List<Consumer>> GetTable();

        /// <summary>
        /// Получает таблицу из БД по Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Таблицу из БД по Id</returns>
        Task<Consumer> GetTable(int Id);

        /// <summary>
        /// Добавляет пользователя
        /// </summary>
        /// <param name="entity">Пользователь</param>
        /// <returns>Добавленного пользователя</returns>
        Task<SaveConsumerResponse> Add(SaveConsumerRequest entity);
    }
}
