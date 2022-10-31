using System.Collections.Generic;

namespace Enterprise.Web3.ProjectManager.Api.Core.Entities
{
    /// <summary>
    /// Тип Заказчика
    /// </summary>
    public class ConsumerType
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
        /// Заказчики
        /// </summary>
        public List<Consumer> Consumers { get; set; }
    }
}
