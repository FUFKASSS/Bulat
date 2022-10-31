using Enterprise.Web3.ProjectManager.Api.Console;
using Enterprise.Web3.ProjectManager.Api.Console.Abstractions;
using Enterprise.Web3.ProjectManager.Api.Core;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Enterprise.Web3.ProjectManager.Api.UnitTest
{
    /// <summary>
    /// Тесты для класса DeveloperRequirementService
    /// </summary>
    public class DeveloperRequirementServiceTest
    {
        /// <summary>
        /// Тест метода Add
        /// </summary>
        [Fact]
        public void Add_Entity_SholdAddEntity()
        {
            // Arrange
            DeveloperRequirement addedEntity = null;
            var repository = new Mock<IDeveloperRequirementRepository>();
            repository.Setup(x => x.Add(It.IsAny<DeveloperRequirement>()))
                .Callback<DeveloperRequirement>(x => addedEntity = x)
                .Returns(36);
            var service = new DeveloperRequirementService(repository.Object);
            var entity = new DeveloperRequirement
            {
                Id = 1,
                SkillId = 10,
                ProjectId = 10,
                ProjectFeatureId = 20,
                Description = "Test1",
                Points = 56,
                Hours = 24
            };

            // Act
            service.Add(entity);

            // Assert
            Assert.NotNull(addedEntity);
            Assert.Equal(entity.Points, addedEntity.Points);
            Assert.Equal(entity.ProjectFeatureId, addedEntity.ProjectFeatureId);
            Assert.Equal(entity.Description, addedEntity.Description);
        }


        /// <summary>
        /// Тест метода Get
        /// </summary>
        [Fact]
        public void Get_Entity_SholdGetEntity()
        {
            // Arrange
            var repository = new Mock<IDeveloperRequirementRepository>();
            repository.Setup(x => x.Get())
                .Returns(new List<DeveloperRequirement>
            {
                new DeveloperRequirement
                {
                    Id = 1,
                    SkillId = 10,
                    ProjectId = 10,
                    ProjectFeatureId = 20,
                    Description = "Test1",
                    Points = 56,
                    Hours = 24
                },
                new DeveloperRequirement
                {
                        Id = 2,
                        SkillId = 100,
                        ProjectId = 150,
                        ProjectFeatureId = 26,
                        Description = "Test2",
                        Points = 46,
                        Hours = 29
                },
                new DeveloperRequirement
                {
                            Id = 3,
                            SkillId = 30,
                            ProjectId = 25,
                            ProjectFeatureId = 28,
                            Description = "Test3",
                            Points = 100,
                            Hours = 36
                }
            });

            //Act
            var service = new DeveloperRequirementService(repository.Object);
            var developerRquirement = service.GetDeveloperRequirement();

            //Assert
            Assert.NotNull(developerRquirement);
            Assert.Equal(3, developerRquirement.Keys.Count);
        }

        /// <summary>
        /// Проверка метода Delete
        /// </summary>
        [Fact]
        public void Delete_Entity_ShouldDeleteEntity()
        {
            // Arrange
            var newEntity = new DeveloperRequirement
            {
                ProjectFeatureId = 1,
                ProjectId = 2,
                Points = 3,
                Description = "Test123",
                Hours = 10
            };
            var repository = new Mock<IDeveloperRequirementRepository>();
            repository.Setup(x => x.Delete(It.IsAny<int>()))
                .Callback<int>(x => newEntity = null);

            var service = new DeveloperRequirementService(repository.Object);
            var id = 1;

            // Act
            service.Delete(id);

            // Assert
            Assert.Null(newEntity);
        }

        /// <summary>
        /// Проверка метода Update
        /// </summary>
        [Fact]
        public void Update_Entity_ShouldUpdateEntity()
        {
            // Arrange
            var addedEntity = new DeveloperRequirement
            {
                Id = 1,
                ProjectFeatureId = 1,
                ProjectId = 2,
                Points = 3,
                Description = "Test123",
                Hours = 10
            };

            var repository = new Mock<IDeveloperRequirementRepository>();
            repository.Setup(x => x.Update(It.IsAny<DeveloperRequirement>()))
                .Callback<DeveloperRequirement>(x => addedEntity = x);

            var service = new DeveloperRequirementService(repository.Object);
            var entity = new DeveloperRequirement
            {
                Id = 1,
                ProjectFeatureId = 1,
                ProjectId = 2,
                Points = 3,
                Description = "Test123",
                Hours = 10
            };

            // Act
            service.Update(entity);

            // Assert
            Assert.NotNull(addedEntity);
            Assert.Equal(entity.Points, addedEntity.Points);
            Assert.Equal(entity.ProjectFeatureId, addedEntity.ProjectFeatureId);
            Assert.Equal(entity.Description, addedEntity.Description);
            Assert.Equal(entity.Hours, addedEntity.Hours);
            Assert.Equal(entity.Id, addedEntity.Id);
        }
    }
}

