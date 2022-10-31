using Enterprise.Web3.ProjectManager.Api.Core.Abstractions;
using Enterprise.Web3.ProjectManager.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Enterprise.Web3.ProjectManager.Api.UnitTest
{
    /// <summary>
    /// Тестовый репозиторий итерации проекта
    /// </summary>
    public class TestProjectIterationRepository : IProjectIterationRepository
    {
        /// <summary>
        /// Сущности
        /// </summary>
        public List<ProjectIteration> projectIterations { get; set; } = new List<ProjectIteration>();

        /// <inheritdoc/>
        public void Add(ProjectIteration entity)
        {
            projectIterations.Add(entity);
        }

        /// <inheritdoc/>
        public void Update(int id, ProjectIteration entity)
        {
            ProjectIteration pr = projectIterations.Find(x => x.Id == id);
            pr.Name = entity.Name;
            pr.ProjectId = entity.ProjectId;
            pr.StartedOn = entity.StartedOn;
            pr.FinishedOn = entity.FinishedOn;
        }

        /// <inheritdoc/>
        public void Delete(int id)
        {
            var itemToRemove = projectIterations.Single(r => r.Id == 2);
            projectIterations.Remove(itemToRemove);
        }

        /// <inheritdoc/>
        public List<ProjectIteration> Get()
        {
            return new List<ProjectIteration>
            {
                new ProjectIteration
                {
                    Id = 1,
                    Name = "1",
                    ProjectId = 1,
                    FinishedOn = DateTime.Now,
                    StartedOn = DateTime.Now

                },
                new ProjectIteration
                {
                    Id = 2,
                    ProjectId = 5,
                    Name = "2",
                    FinishedOn = DateTime.Now,
                    StartedOn = DateTime.Now
                },
                new ProjectIteration
                {
                    Id = 3,
                    ProjectId = 7,
                    Name = "4",
                    FinishedOn = DateTime.Now,
                    StartedOn = DateTime.Now
                }
            };
        }
    }
}
