﻿namespace Enterprise.Web3.ProjectManager.Api.Core.Requests.DeveloperRequirementRequests
{
    /// <summary>
    /// Запрос на создание потребности к разработчику
    /// </summary>
    public class SaveDeveloperRequirementRequest
    {
        /// <summary>
        /// ИД проекта
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// ИД фичи проекта
        /// </summary>
        public int ProjectFeatureId { get; set; }

        /// <summary>
        /// Описание проекта
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// ИД требуемого скилла
        /// </summary>
        public int SkillId { get; set; }

        /// <summary>
        /// Количество баллов у разработчика в определенном скилле
        /// </summary>
        public int Points { get; set; }

        /// <summary>
        /// Количество часов, на сколько нужен разработчик с заданным скиллом
        /// </summary>
        public int Hours { get; set; }
    }
}
