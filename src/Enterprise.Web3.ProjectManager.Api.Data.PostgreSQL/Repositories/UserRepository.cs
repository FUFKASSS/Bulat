using Dapper;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using Enterprise.Web3.ProjectManager.Api.Core.Entities;
using Enterprise.Web3.ProjectManager.Api.Core.Abstractions;
using Enterprise.Web3.ProjectManager.Api.Core.Requests.UserRequests;

namespace Enterprise.Web3.ProjectManager.Api.Data.PostgreSql.Repositories
{
	/// <summary>
	/// БД пользователей
	/// </summary>
	public class UserRepository : IUserRepository
	{
		private readonly IDbConnection _dbConnection;

		/// <summary>
		/// Конструктор UserRepository
		/// </summary>
		/// <param name="dbConnection">Инжектируемое БД подключение</param>
		public UserRepository(IDbConnection dbConnection)
		{
			_dbConnection = dbConnection;
		}

        /// <summary>
        /// Добавление пользователя в БД
        /// </summary>
        /// <param name="entity">Пользователь</param>
        /// <returns>Ответ на добавление пользователя</returns>
        public SaveUserResponse Add(SaveUserRequest entity)
		{
			_dbConnection.Execute(@"INSERT INTO public.user (
	                name,
	                surname,
	                patronymic,
	                login,
	                password_hash
                ) VALUES (
	                @name,
	                @surname,
	                @patronymic,
	                @login,
	                @passwordHash
                );",
	entity);

			return new SaveUserResponse
            {
                Id = _dbConnection.QueryFirstOrDefault<int>(
                @$"SELECT id FROM public.user
                WHERE name = {entity.Name},
                surname = {entity.Surname},
                patronymic = {entity.Patronymic},
                login = {entity.Login},
                password_hash = {entity.PasswordHash}")
            };
		}

		/// <summary>
		/// Удаляет пользователя по Id из БД
		/// </summary>
		/// <param name="id">Id пользователя</param>
		public void Delete(int id)
		{
			_dbConnection.Execute(@"DELETE FROM public.user
				WHERE id = @id",
				new { id });
		}

		/// <summary>
		/// Получает список всех польхователей из БД
		/// </summary>
		/// <returns>Список пользователей</returns>
		public List<User> Get()
		{
			List<User> users = _dbConnection.Query<User>("SELECT * FROM public.user").ToList();

			return users;
		}

        /// <summary>
        /// Получает пользователя по его Id
        /// </summary>
        /// <param name="id">Id пользователя</param>
        /// <returns>Пользователь с искомым Id</returns>
        public User GetById(int id)
        {
            return _dbConnection.QueryFirstOrDefault<User>(
                @$"SELECT * FROM public.user
                WHERE id = {id}");
        }

		/// <summary>
		/// Создает таблицу в БД
		/// </summary>
		public void CreateTable()
		{
			_dbConnection.Execute(@"CREATE TABLE IF NOT EXISTS public.user (
				id int4 NOT NULL GENERATED ALWAYS AS IDENTITY,
				name text NOT NULL,
				surname text NOT NULL,
				patronymic text NULL,
				login text NOT NULL,
				password_hash text NOT NULL,
				CONSTRAINT user_pk PRIMARY KEY(id)
			); ");
		}

		/// <summary>
		/// Изменение сущности в БД по ИД
		/// </summary>
		/// <param name="entity">Изменяемая сущность</param>
		public void Update(User entity)
		{
			_dbConnection.Execute(
@"UPDATE public.user
SET name = @name, surname = @surname, patronymic = @patronymic, login = @login, password_hash = @passwordHash
WHERE id = @id;",
	entity);
		}
	}
}