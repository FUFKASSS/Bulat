using Enterprise.Web3.ProjectManager.Api.Core.Abstractions;
using Enterprise.Web3.ProjectManager.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.Web3.ProjectManager.Api.Core.Services
{
    /// <summary>
    /// Сервис с логикой по работе с итерациями проекта
    /// </summary>
    public class ProjectIterationService : IProjectIterationService
    {
        private IProjectIterationRepository _projectIterationRepository { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="projectIterationRepository">объект репозитория итерации проекта</param>
        public ProjectIterationService(IProjectIterationRepository projectIterationRepository)
        {
            _projectIterationRepository = projectIterationRepository;
        }

        /// <summary>
        /// Получить список итераций проектов
        /// </summary>
        /// <returns></returns>
        public List<ProjectIteration> GetProjectIterations()
        {
            return _projectIterationRepository.Get();
        }

        /// <summary>
        /// Добавить итерацию проекта 
        /// </summary>
        /// <param name="entity">Сущность итерации проекта</param>
        public void Add(ProjectIteration entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            if (string.IsNullOrWhiteSpace(entity.Name))
                throw new Exception("не заполнено поле Название");
            _projectIterationRepository.Add(entity);
        }

        /// <summary>
        /// Изменение существующей итерации проекта
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="entity">сущность итерации проекта</param>
        public void Update(int id, ProjectIteration entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            if (string.IsNullOrWhiteSpace(entity.Name))
                throw new Exception("не заполнено поле Название");
            _projectIterationRepository.Update(id, entity);
        }

        /// <summary>
        /// Удаление итерации проекта
        /// </summary>
        /// <param name="id">ID итерации проекта</param>
        public void Delete(int id)
        {
            _projectIterationRepository.Delete(id);
        }
    }
}
