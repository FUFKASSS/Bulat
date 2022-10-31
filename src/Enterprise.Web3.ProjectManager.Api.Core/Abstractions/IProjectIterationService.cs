using Enterprise.Web3.ProjectManager.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.Web3.ProjectManager.Api.Core.Abstractions
{
    /// <summary>
    /// Интерфейс по работе с сервисом итераций проектов
    /// </summary>
    interface IProjectIterationService
    {
        /// <summary>
        /// Получить список итераций проектов
        /// </summary>
        /// <returns>Список итераций проектов</returns>
        List<ProjectIteration> GetProjectIterations();

        /// <summary>
        /// Добавить терацию проекта
        /// </summary>
        /// <param name="entity">сущность</param>
        void Add(ProjectIteration entity);
    }
}
