namespace Enterprise.Web3.ProjectManager.Api.Core.Requests.SkillRequests
{
    /// <summary>
    /// Запрос на создание скилла
    /// </summary>
    public class SaveSkillRequest
    {
        /// <summary>
        /// Название 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Умение
        /// </summary>
        public int SkillTypeId { get; set; }

        /// <summary>
        /// Уровень умения
        /// </summary>
        public int MaxPoints { get; set; }
    }
}
