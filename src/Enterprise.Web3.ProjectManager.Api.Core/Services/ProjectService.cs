using Enterprise.Web3.ProjectManager.Api.Core.Abstractions;
using Enterprise.Web3.ProjectManager.Api.Core.Entities;
using System;
using System.Collections.Generic;

namespace Enterprise.Web3.ProjectManager.Api.Core.Core
{
    /// <summary>
    /// Сервис с логикой рабты с данными
    /// </summary>
    public class ProjectService : IProjectService
    {
        private IProjectRepository _projectRepository { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="projectRepository">объект проекта</param>
        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        /// <summary>
        /// Добавление проекта в бд по условиям
        /// </summary>
        /// <param name="project">Сущность проекта</param>
        public void Add(Project project)
        {
            if (project is null)
            {
                throw new System.ArgumentNullException(nameof(project));
            }

            if (string.IsNullOrWhiteSpace(project.Name))
            {
                throw new System.Exception("не заполнено поле Название");
            }

            if (string.IsNullOrWhiteSpace(project.Description))
            {
                throw new System.Exception("Не заполнено поле Описание");
            }

            _projectRepository.Add(project);
        }

        /// <summary>
        /// Обновление записи проекта
        /// </summary>
        /// <param name="id">id проекта</param>
        /// <param name="entity">Сущность проекта</param>
        public void Update(Project project)
        {
            if (project is null)
            {
                throw new ArgumentNullException(nameof(project));
            }

            if (string.IsNullOrWhiteSpace(project.Name))
            {
                throw new System.Exception("не заполнено поле Название");
            }

            if (string.IsNullOrWhiteSpace(project.Description))
            {
                throw new System.Exception("Не заполнено поле Описание");
            }

            _projectRepository.Update(project);
        }

        /// <summary>
        /// Удаление записи проекта
        /// </summary>
        /// <param name="id">id проекта</param>
        public void Delete(int id)
        {
            _projectRepository.Delete(id);
        }

        /// <summary>
        /// Получиь названия проектов в группе по типу
        /// </summary>
        /// <returns>Названия проектов</returns>
        public Dictionary<string, List<Project>> GetProjectName()
        {
            var projects = _projectRepository.Get();
            if (projects == null)
            {
                return null;
            }

            var result = new Dictionary<string, List<Project>>();

            foreach (var project in projects)
            {
                if (result.ContainsKey(project.Name))
                {
                    result[project.Name].Add(project);
                }
                else
                {
                    result[project.Name] = new List<Project> { project };
                }
            }

            return result;
        }

        /// <summary>
        /// Cоздание таблицы
        /// </summary>
        public void CreateTable()
        {
            throw new NotImplementedException();
        }
    }
}
