namespace Enterprise.Web3.ProjectManager.Api.Core.Requests.ConsumerRequests
{
    public class UpdateConsumerRequest
    {
        /// <summary>
        /// Ид
        /// </summary>
        public int id { get; set; }
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
        /// Умение
        /// </summary>
        public int ConsumerTypeId { get; set; }
    }
}
