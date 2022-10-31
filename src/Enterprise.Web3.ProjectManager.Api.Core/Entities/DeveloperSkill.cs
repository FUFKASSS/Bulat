namespace Enterprise.Web3.ProjectManager.Api.Core.Entities
{
    /// <summary>
    /// Навык разработчика
    /// </summary>
    public class DeveloperSkill
    {
        /// <summary>
        /// ИД пользователя
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ИД разработчика
        /// </summary>
        public int DeveloperId { get; set; }

        /// <summary>
        /// ИД навыка
        /// </summary>
        public int SkillId { get; set; }

        /// <summary>
        /// Количество баллов
        /// </summary>
        public int Points { get; set; }

        /// <summary>
        /// Комментарий
        /// </summary>
        public string Comment { get; set; }
    }
}