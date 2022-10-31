using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.Web3.ProjectManager.Api.Core.Entities
{
    /// <summary>
    /// Сущность итерации проекта
    /// </summary>
    public class ProjectIteration
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название итерации
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Id проекта
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// Дата старта итерации
        /// </summary>
        public DateTime StartedOn { get; set; }

        /// <summary>
        /// Дата финиша итерации
        /// </summary>
        public DateTime FinishedOn { get; set; }
    }
}
