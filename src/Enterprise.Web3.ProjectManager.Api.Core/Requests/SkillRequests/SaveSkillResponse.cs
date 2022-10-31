using System;

namespace Enterprise.Web3.ProjectManager.Api.Core.Requests.SkillRequests
{
    /// <summary>
    /// Ответ на <see cref="SaveSkillRequest"/>
    /// </summary>
    public class SaveSkillResponse
    {
        /// <summary>
        /// ИД
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreatedOn { get; set; }
    }
}
