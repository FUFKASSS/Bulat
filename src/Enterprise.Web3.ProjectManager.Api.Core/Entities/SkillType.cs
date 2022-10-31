using System.Collections.Generic;

namespace Enterprise.Web3.ProjectManager.Api.Core.Entities
{
    /// <summary>
    /// Тип навыка
    /// </summary>
    public class SkillType
    {
        /// <summary>
        /// Id строки
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Скиллы
        /// </summary>
        public List<Skill> Skills { get; set; }
    }
}
