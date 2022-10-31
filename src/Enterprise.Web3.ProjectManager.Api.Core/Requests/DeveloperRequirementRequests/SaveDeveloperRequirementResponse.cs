using System;

namespace Enterprise.Web3.ProjectManager.Api.Core.Requests.DeveloperRequirementRequests
{
    /// <summary>
    /// Ответ на <see cref="SaveDeveloperRequirementRequest"/>
    /// </summary>
    public class SaveDeveloperRequirementResponse
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
