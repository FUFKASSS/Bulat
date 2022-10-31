using Enterprise.Web3.ProjectManager.Api.Core.Entities;
using Enterprise.Web3.ProjectManager.Api.Core.Requests.UserRequests;
using System.Collections.Generic;

namespace Enterprise.Web3.ProjectManager.Api.Core.Abstractions
{
    /// <summary>
    /// Интерфейс бизнес-логики пользователя
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Добавить пользователя в БД
        /// </summary>
        /// <param name="entity">Добавляемый пользователь</param>
        /// <returns>Ответ на добавление пользователя</returns>
        SaveUserResponse Add(SaveUserRequest entity);

        /// <summary>
        /// Изменить пользователя в БД по ИД
        /// </summary>
        /// <param name="entity">Изменяемый пользователь</param>
        void Update(User entity);

        /// <summary>
        /// Удалить пользователя по ИД
        /// </summary>
        /// <param name="id">ИД</param>
        void Delete(int id);

        /// <summary>
        /// Получить список пользователей
        /// </summary>
        /// <returns>Список пользователей</returns>
        List<User> Get();

        /// <summary>
        /// Получает пользователя по его Id
        /// </summary>
        /// <param name="id">Id пользователя</param>
        /// <returns>Пользователь с искомым Id</returns>
        User GetById(int id);

        /// <summary>
        /// Создать БД
        /// </summary>
        void CreateTable();
    }
}