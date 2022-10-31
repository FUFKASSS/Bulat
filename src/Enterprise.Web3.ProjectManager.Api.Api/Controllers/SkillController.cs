using Enterprise.Web3.ProjectManager.Api.Core.Abstractions;
using Enterprise.Web3.ProjectManager.Api.Core.Entities;
using Enterprise.Web3.ProjectManager.Api.Core.Requests.SkillRequests;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Enterprise.Web3.ProjectManager.Api.Api.Controllers
{
    /// <summary>
    /// Контроллер скиллов
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _skillService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="skillService">Сервис скиллов</param>
        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        /// <summary>
        /// Получить список скиллов
        /// </summary>
        /// <param name="request">Фильтр</param>
        /// <returns>Список скиллов</returns>
        [HttpGet]
        public async Task<Dictionary<string, List<Skill>>> GetAsync([FromQuery] string name)
            => await _skillService.GetSkillsAsync(name);

        /// <summary>
        /// Получить данные скилла
        /// </summary>
        /// <param name="id">ИД</param>
        /// <returns>Скилл</returns>
        [HttpGet("{id}")]
        public Skill Get([FromRoute] int id)
        {
            return new Skill
            {
                Id = id,
                Name = "sdfgher"
            };
        }

        /// <summary>
        /// Сохранить скилл
        /// </summary>
        /// <param name="entity">Данные</param>
        /// <returns>ИД</returns>
        [HttpPost]
        public SaveSkillResponse Save([FromBody] SaveSkillRequest entity)
        {
            return _skillService.Add(entity);
        }

        /// <summary>
        /// Обновить данные скилла
        /// </summary>
        /// <param name="id">ИД</param>
        /// <param name="entity">Данные</param>
        [HttpPut("{id}")]
        public void Update([FromRoute] int id, [FromBody] Skill entity)
        {

        }

        /// <summary>
        /// Удалить скилл
        /// </summary>
        /// <param name="id">ИД</param>
        [HttpDelete("{id}")]
        public void Delete([FromRoute] int id)
        {
        }
    }
}
