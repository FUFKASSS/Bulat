using Enterprise.Web3.ProjectManager.Api.Console;
using Enterprise.Web3.ProjectManager.Api.Core.Abstractions;
using Enterprise.Web3.ProjectManager.Api.Core.Requests.DeveloperRequirementRequests;
using Microsoft.AspNetCore.Mvc;

namespace Enterprise.Web3.ProjectManager.Api.Api.Controllers
{
    /// <summary>
    /// Контроллер потребностей к разработчику
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class DeveloperRequirementConroller : ControllerBase
    {
        private readonly IDeveloperRequirementService _developerRequirementService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="developerRequirementService">Сервис потребностей к разработчику</param>
        public DeveloperRequirementConroller(IDeveloperRequirementService developerRequirementService)
        {
            _developerRequirementService = developerRequirementService;
        }

        /// <summary>
        /// Получить список требований к разработчику
        /// </summary>
        /// <param name="request">Фильтр</param>
        /// <returns>Список требованийк разработчику</returns>
        [HttpGet]
        public DeveloperRequirement[] Get()
        {
            return _developerRequirementService.Get().ToArray();
        }

        /// <summary>
        /// Получить требования к разработчику по ИД
        /// </summary>
        /// <param name="id">ИД</param>
        /// <returns>Требоавиня к разработчику</returns>
        [HttpGet("{id}")]
        public DeveloperRequirement[] GetById([FromRoute] int id)
        {
            return _developerRequirementService.GetById(id).ToArray();
        }

        /// <summary>
        /// Сохранить требования к разработчику
        /// </summary>
        /// <param name="entity">Данные</param>
        /// <returns>ИД</returns>
        [HttpPost]
        public SaveDeveloperRequirementResponse Save([FromBody] SaveDeveloperRequirementRequest entity)
        {
            return _developerRequirementService.Add(entity);
        }

        /// <summary>
        /// Обновить данные скилла
        /// </summary>
        /// <param name="id">ИД</param>
        /// <param name="entity">Данные</param>
        [HttpPut("{id}")]
        public void Update([FromRoute] int id, [FromBody] DeveloperRequirement entity)
        {
            entity.Id = id;
            _developerRequirementService.Update(entity);
        }

        /// <summary>
        /// Удалить требования к разработчику
        /// </summary>
        /// <param name="id">ИД</param>
        [HttpDelete("{id}")]
        public void Delete([FromRoute] int id)
        {
            _developerRequirementService.Delete(id);
        }
    }
}
