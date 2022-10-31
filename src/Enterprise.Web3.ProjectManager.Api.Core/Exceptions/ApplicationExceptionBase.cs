using System;

namespace Enterprise.Web3.ProjectManager.Api.Core.Exceptions
{
    /// <summary>
    /// Кастомное исключение приложения
    /// </summary>
    public class ApplicationExceptionBase : Exception
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="message">Сообщение</param>
        public ApplicationExceptionBase(string message) : base(message)
        {
        }
    }
}
