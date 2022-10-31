using Enterprise.Web3.ProjectManager.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.Web3.ProjectManager.Api.Core.Abstractions
{
    /// <summary>
    /// Интерфейс по работе с репозиторием итерации проектов
    /// </summary>
    public interface IProjectIterationRepository
    {
        /// <summary>
        /// Получение ввех итераций проекта из репозитория
        /// </summary>
        /// <returns>Список итераций проекта</returns>
        List<ProjectIteration> Get();

        /// <summary>
        /// Добавление итерации проекта в репозиторий
        /// </summary>
        /// <param name="projectIteration">Сущность итерации проекта</param>
        void Add(ProjectIteration projectIteration);

        /// <summary>
        /// Изменение итерации проекта
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="projectIteration">Сущность итерации проекта</param>
        void Update(int id, ProjectIteration projectIteration);

        /// <summary>
        /// Удалении итерации проекта по айди
        /// </summary>
        /// <param name="id">id</param>
        void Delete(int id);
    }
}
