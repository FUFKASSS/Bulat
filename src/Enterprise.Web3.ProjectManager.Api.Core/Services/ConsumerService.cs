using Enterprise.Web3.ProjectManager.Api.Core.Abstractions;
using Enterprise.Web3.ProjectManager.Api.Core.Entities;
using Enterprise.Web3.ProjectManager.Api.Core.Requests.ConsumerRequests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enterprise.Web3.ProjectManager.Api.Core.Services
{
    /// <summary>
    /// Сервис с логикой по работе с данными объектов(получением,удаление и тд...)
    /// </summary>
    public class ConsumerService : IConsumerService
    {
        readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">Контекст БД</param>
        public ConsumerService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Изменение объекта в проекте
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="entity">сущность объекта проекта</param>
        public async Task<UpdateConsumerResponse> Update(UpdateConsumerRequest entity)
        {
            if (entity.Name == null)
            {
                throw new ArgumentNullException(nameof(entity.Name), "Имя не может быть пустым");
            }
            var upd = await _dbContext.Consumers.FirstOrDefaultAsync(x => x.Id == entity.id);

            upd.Name = entity.Name;
            upd.Description = entity.Description;
            upd.Inn = entity.Inn;
            upd.Address = entity.Address;
            upd.Email = entity.Email;
            upd.ConsumerTypeId = entity.ConsumerTypeId;

            await _dbContext.SaveChangesAsync();
            return new UpdateConsumerResponse { Id = entity.id };
        }

        /// <summary>
        /// Удаление проекта
        /// </summary>
        /// <param name="id">id</param>
        public async Task<Consumer> Delete(int id)
        {
            if (id < 0)
            {
                throw new Exception("ID не может быть отрицательным");
            }
            var Delete = _dbContext.Consumers.Where(x => x.Id == id).FirstOrDefaultAsync();
            _dbContext.Consumers.Remove(await Delete);
            await _dbContext.SaveChangesAsync();
            return await Delete;
        }


        /// <summary>
        /// Добавляет данные в БД
        /// </summary>
        /// <param name="entity">Пользователь</param>
        /// <returns>Добавленные данные в БД</returns>
        public async Task<SaveConsumerResponse> Add(SaveConsumerRequest entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (string.IsNullOrWhiteSpace(entity.Name))
            {
                throw new Exception("Не заполнено поле Название");
            }

            if (entity.Inn < 0)
            {
                throw new Exception("Неправильный ИНН");
            }
            var consumerType = _dbContext.ConsumerTypes.FirstOrDefault(x => x.Id == entity.ConsumerTypeId);
            if (consumerType == null)
            {
                consumerType = new ConsumerType
                {
                    Id = entity.ConsumerTypeId,
                    Name = entity.Name
                };
            }
            var consumer = new Consumer
            {
                Name = entity.Name,
                Description = entity.Description,
                Inn = entity.Inn,
                Address = entity.Address,
                Email = entity.Email,
                ConsumerType = consumerType
            };
            var s = _dbContext.Consumers.AddAsync(consumer);

            await _dbContext.SaveChangesAsync();
            return new SaveConsumerResponse
            {
                Id = consumer.Id
            };
        }

        /// <summary>
        /// Получает таблицу
        /// </summary>
        /// <returns>таблицу</returns>
        public async Task<List<Consumer>> GetTable()
        {
            return await _dbContext.Consumers.ToListAsync();
        }

        /// <summary>
        /// Пользователя из БД
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns>Пользователя из БД по ID</returns>
        public async Task<Consumer> GetTable(int Id)
        {
            return await _dbContext.Consumers.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }
    }
}
