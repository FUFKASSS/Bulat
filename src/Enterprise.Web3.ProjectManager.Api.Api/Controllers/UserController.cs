using Enterprise.Web3.ProjectManager.Api.Core.Abstractions;
using Enterprise.Web3.ProjectManager.Api.Core.Entities;
using Enterprise.Web3.ProjectManager.Api.Core.Requests.UserRequests;
using Microsoft.AspNetCore.Mvc;

namespace Enterprise.Web3.ProjectManager.Api.Api.Controllers
{
    /// <summary>
    /// Контроллер пользователя
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="userService">Сервис пользователя</param>
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Получить список пользователей
        /// </summary>
        /// <returns>Список пользователей</returns>
        [HttpGet]
        public User[] Get()
        {
            return _userService.Get().ToArray();
        }

        /// <summary>
        /// Получает пользователя по его Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Пользователь с искомым Id</returns>
        [HttpGet("{id}")]
        public User GetById([FromRoute] int id)
        {
            return _userService.GetById(id);
        }

        /// <summary>
        /// Сохранить нового пользователя
        /// </summary>
        /// <param name="user">Данные</param>
        /// <returns>Id</returns>
        [HttpPost]
        public SaveUserResponse Save([FromBody] SaveUserRequest user)
        {
            return _userService.Add(user);
        }
        
        /// <summary>
        /// Обновить данные пользователя
        /// </summary>
        /// <param name="id">Id пользователя</param>
        /// <param name="user">Обновленные данные</param>
        [HttpPut("{id}")]
        public void Update([FromRoute] int id, [FromBody] User user)
        {
            user.Id = id;
            _userService.Update(user);
        }

        /// <summary>
        /// Удалить пользователя по Id
        /// </summary>
        /// <param name="id">Id</param>
        [HttpDelete("{id}")]
        public void Delete([FromRoute] int id)
        {
            _userService.Delete(id);
        }
    }
}
