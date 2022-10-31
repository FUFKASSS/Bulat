namespace Enterprise.Web3.ProjectManager.Api.Core.Requests.UserRequests
{
    /// <summary>
    /// Запрос на создание пользователя
    /// </summary>
    public class SaveUserRequest
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string Patronymic { get; set; }

        /// <summary>
        /// Логин пользователя в системе
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Хэш пароля пользователя в системе
        /// </summary>
        public string PasswordHash { get; set; }
    }
}
