using System;

namespace Enterprise.Web3.ProjectManager.Api.Core.Entities
{
    /// <summary>
    /// Навыки
    /// </summary>
    public class Skill
    {
        /// <summary>
        /// Id строки
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// фывфыафыа
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Название 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Тип скила
        /// </summary>
        public int SkillTypeId { get; set; }

        /// <summary>
        /// Уровень умения
        /// </summary>
        public int MaxPoints { get; set; }

        /// <summary>
        /// Тип скила
        /// </summary>
        public SkillType SkillType { get; set; }
    }
}
