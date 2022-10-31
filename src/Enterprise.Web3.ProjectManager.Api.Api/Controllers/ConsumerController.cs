using Enterprise.Web3.ProjectManager.Api.Core.Abstractions;
using Enterprise.Web3.ProjectManager.Api.Core.Entities;
using Enterprise.Web3.ProjectManager.Api.Core.Requests.ConsumerRequests;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Enterprise.Web3.ProjectManager.Api.Api.Controllers
{
    /// <summary>
    /// Контроллер Пользователей
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ConsumerController : ControllerBase
    {
        private readonly IConsumerService _consumerService;

        /// <summary>
        /// Контроллер Ползователей
        /// </summary>
        /// <param name="consumerService">сервис пользователей</param>
        public ConsumerController(IConsumerService consumerService)
        {
            _consumerService = consumerService;
        }

        /// <summary>
        /// Получить заказчиков
        /// </summary>
        /// <param name="request">Фильтр</param>
        /// <returns>Список заказчиков</returns>
        [HttpGet]
        public async Task<List<Consumer>> Get()
        {
            return await _consumerService.GetTable();
        }

        /// <summary>
        /// Получить данные определенного заказчика
        /// </summary>
        /// <param name="id">ИД</param>
        /// <returns>Заказчик</returns>
        [HttpGet("{id}")]
        public async Task<Consumer> Get([FromRoute] int id)
        {
            return await _consumerService.GetTable(id);
        }

        /// <summary>
        /// Сохранить заказчика
        /// </summary>
        /// <param name="entity">Данные</param>
        /// <returns>ИД</returns>
        [HttpPost]
        public async Task<SaveConsumerResponse> Save([FromBody] SaveConsumerRequest entity)
        {
            return await _consumerService.Add(entity);
        }

        /// <summary>
        /// Удалить заказчика
        /// </summary>
        /// <param name="id">ИД</param>
        [HttpDelete("{id}")]
        public async Task<Consumer> Delete([FromRoute] int id)
        {

            return await _consumerService.Delete(id);

        }

        /// <summary>
        /// Обновляет заказчика
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="entity">пользователь</param>
        [HttpPut("{id}")]
        public async Task<UpdateConsumerResponse> Update([FromRoute] int id, [FromBody] UpdateConsumerRequest entity)
        {
            return await _consumerService.Update(entity);

        }
    }
}
