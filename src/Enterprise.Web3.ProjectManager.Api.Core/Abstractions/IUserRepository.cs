using Enterprise.Web3.ProjectManager.Api.Core.Entities;
using Enterprise.Web3.ProjectManager.Api.Core.Requests.UserRequests;
using System.Collections.Generic;

namespace Enterprise.Web3.ProjectManager.Api.Core.Abstractions
{
	/// <summary>
	/// Интерфейс БД пользователей
	/// </summary>
	public interface IUserRepository
	{
        /// <summary>
        /// Добавление пользователя в БД
        /// </summary>
        /// <param name="entity">Пользователь</param>
        /// <returns>Ответ на добавление пользователя</returns>
        SaveUserResponse Add(SaveUserRequest entity);

		/// <summary>
		/// Получает список всех польхователей из БД
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
		/// Удаляет пользователя по Id из БД
		/// </summary>
		/// <param name="id">Id пользователя</param>
		void Delete(int id);

		/// <summary>
		/// Изменение сущности в БД по ИД
		/// </summary>
		/// <param name="entity">Изменяемая сущность</param>
		void Update(User entity);

		/// <summary>
		/// Создает таблицу в БД
		/// </summary>
		void CreateTable();
	}
}