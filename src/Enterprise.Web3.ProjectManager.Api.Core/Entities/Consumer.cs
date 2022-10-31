namespace Enterprise.Web3.ProjectManager.Api.Core.Entities
{
    /// <summary>
    ///  Заказчик
    /// </summary>
    public class Consumer
    {
        /// <summary>
        /// Ид
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Инн
        /// </summary>
        public int Inn { get; set; }

        /// <summary>
        /// Адрес
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Емеил
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Тип скила
        /// </summary>
        public ConsumerType ConsumerType { get; set; }

        /// <summary>
        /// Тип скила
        /// </summary>
        public int ConsumerTypeId { get; set; }
    }
}