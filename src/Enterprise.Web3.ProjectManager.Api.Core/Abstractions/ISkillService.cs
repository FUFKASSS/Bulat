using Enterprise.Web3.ProjectManager.Api.Core.Entities;
using Enterprise.Web3.ProjectManager.Api.Core.Requests.SkillRequests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Enterprise.Web3.ProjectManager.Api.Core.Abstractions
{
    /// <summary>
    /// Интерфейс
    /// </summary>
    public interface ISkillService
    {
        /// <summary>
        /// Получить скилы в группировке по типу
        /// </summary>
        /// <returns>Скилы</returns>
        Task<Dictionary<string, List<Skill>>> GetSkillsAsync(string name);

        /// <summary>
        /// ыапкцп
        /// </summary>
        /// <param name="entity">укп</param>
        /// <returns>ИД</returns>
        SaveSkillResponse Add(SaveSkillRequest entity);
    }
}
