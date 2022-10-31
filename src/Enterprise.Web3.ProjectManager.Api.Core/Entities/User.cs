namespace Enterprise.Web3.ProjectManager.Api.Core.Entities
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User
    {
        /// <summary>
        /// ИД пользователя
        /// </summary>
        public int Id { get; set; }

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

        /// <summary>
        /// Вывод данных в консоль
        /// </summary>
        public void Print()
        {
            System.Console.WriteLine(
                $@"Id пользователя: {this.Id}
Имя: {this.Name}
Фамилия: {this.Surname}
Отчество: {this.Patronymic}
Логин: {this.Login}
Хэш пароля: {this.PasswordHash}");
        }
    }
}