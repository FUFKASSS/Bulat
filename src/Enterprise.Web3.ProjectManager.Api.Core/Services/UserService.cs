using Enterprise.Web3.ProjectManager.Api.Core.Abstractions;
using Enterprise.Web3.ProjectManager.Api.Core.Entities;
using Enterprise.Web3.ProjectManager.Api.Core.Requests.UserRequests;
using System.Collections.Generic;

namespace Enterprise.Web3.ProjectManager.Api.Core
{
    /// <summary>
    /// Класс с бизнес-логикой пользователя
    /// </summary>
    public class UserService : IUserService
    {
        private IUserRepository _userRepository { get; set; }

        /// <summary>
        /// Конструктор UserService
        /// </summary>
        /// <param name="userRepository">Инжектируемый БД пользователей</param>
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Добавить пользователя в БД
        /// </summary>
        /// <param name="entity">Добавляемый пользователь</param>
        /// <returns>Ответ на добавление пользователя</returns>
        public SaveUserResponse Add(SaveUserRequest entity)
        {
            if (entity is null)
                throw new System.ArgumentNullException(nameof(entity));

            if (string.IsNullOrWhiteSpace(entity.Name))
                throw new System.Exception(
                    "У пользователя не заполнено обязательное поле: Имя");

            if (string.IsNullOrWhiteSpace(entity.Surname))
                throw new System.Exception(
                    "У пользователя не заполнено обязательное поле: Фамилия");

            if (string.IsNullOrWhiteSpace(entity.Login))
                throw new System.Exception(
                    "У пользователя не заполнено обязательное поле: Логин");

            if (string.IsNullOrWhiteSpace(entity.PasswordHash))
                throw new System.Exception(
                    "У пользователя не заполнено обязательное поле: Хэш пароль");

            return _userRepository.Add(new SaveUserRequest { 
                Name = entity.Name,
                Surname = entity.Surname,
                Patronymic = entity.Patronymic,
                Login = entity.Login,
                PasswordHash = entity.PasswordHash
            });
        }

        /// <summary>
        /// Изменить пользователя в БД по ИД
        /// </summary>
        /// <param name="entity">Изменяемый пользователь</param>
        public void Update(User entity)
        {
            if (entity is null)
                throw new System.ArgumentNullException(nameof(entity));

            if (entity.Id <= 0)
                throw new System.Exception("У поля ID не установлено валидное значение");

            if (string.IsNullOrWhiteSpace(entity.Name))
                throw new System.Exception(
                    "У пользователя не заполнено обязательное поле: Имя");

            if (string.IsNullOrWhiteSpace(entity.Surname))
                throw new System.Exception(
                    "У пользователя не заполнено обязательное поле: Фамилия");

            if (string.IsNullOrWhiteSpace(entity.Login))
                throw new System.Exception(
                    "У пользователя не заполнено обязательное поле: Логин");

            if (string.IsNullOrWhiteSpace(entity.PasswordHash))
                throw new System.Exception(
                    "У пользователя не заполнено обязательное поле: Хэш пароль");

            _userRepository.Update(entity);
        }

        /// <summary>
        /// Удалить пользователя по ИД
        /// </summary>
        /// <param name="id">ИД</param>
        public void Delete(int id)
        {
            if (id <= 0)
                throw new System.Exception("У поля ID не установлено валидное значение");

            _userRepository.Delete(id);
        }

        /// <summary>
        /// Получить список пользователей
        /// </summary>
        /// <returns>Список пользователей</returns>
        public List<User> Get()
        {
            return _userRepository.Get();
        }

        /// <summary>
        /// Получает пользователя по его Id
        /// </summary>
        /// <param name="id">Id пользователя</param>
        /// <returns>Пользователь с искомым Id</returns>
        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        /// <summary>
        /// Создать БД
        /// </summary>
        public void CreateTable()
        {
            _userRepository.CreateTable();
        }
    }
}
