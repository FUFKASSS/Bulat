using Enterprise.Web3.ProjectManager.Api.Core.Abstractions;
using Enterprise.Web3.ProjectManager.Api.Core.Entities;
using Enterprise.Web3.ProjectManager.Api.Core.Services;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Enterprise.Web3.ProjectManager.Api.UnitTest
{
    public class ProjectIterationServiceTest
    {
        /// <summary>
        /// Проверка Get метода 
        /// </summary>
        [Fact]
        public void Get_Null_ReturnsRowData()
        {
            var repository = new Mock<IProjectIterationRepository>();
            repository.Setup(x => x.Get())
                .Returns(new List<ProjectIteration>
                {
                    new ProjectIteration
                    {
                        Id = 1,
                        StartedOn = DateTime.Now,
                        FinishedOn = DateTime.Now,
                        ProjectId = 4,
                        Name = "1"
                    },
                    new ProjectIteration
                    {
                        Id = 2,
                        StartedOn = DateTime.Now,
                        FinishedOn = DateTime.Now,
                        ProjectId = 4,
                        Name = "2"
                    },
                    new ProjectIteration
                    {
                        Id = 3,
                        StartedOn = DateTime.Now,
                        FinishedOn = DateTime.Now,
                        ProjectId = 3,
                        Name = "4"
                    }
                });
            var service = new ProjectIterationService(repository.Object);
            var projectIterations = service.GetProjectIterations();
            Assert.Equal(3, projectIterations.Count);
        }

        /// <summary>
        /// Проверка Add метода
        /// </summary>
        [Fact]
        public void Add_ValidEntity_AddsToStorage()
        {
            // Arrange
            var entity = new ProjectIteration
            {
                Id = 1,
                Name = "Test",
                ProjectId = 5
            };
            ProjectIteration addedEntity = null;
            var repository = new Mock<IProjectIterationRepository>();
            repository.Setup(x => x.Add(It.IsAny<ProjectIteration>()))
                .Callback<ProjectIteration>(x => addedEntity = x);
            var service = new ProjectIterationService(repository.Object);

            // Act
            service.Add(entity);

            // Assert
            Assert.NotNull(addedEntity);
            Assert.Equal(entity.Name, addedEntity.Name);
            Assert.Equal(entity.ProjectId, addedEntity.ProjectId);
        }
    }
}
