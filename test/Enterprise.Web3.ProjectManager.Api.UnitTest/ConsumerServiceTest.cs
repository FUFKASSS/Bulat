using Enterprise.Web3.ProjectManager.Api.Core.Abstractions;
using Enterprise.Web3.ProjectManager.Api.Core.Entities;
using Enterprise.Web3.ProjectManager.Api.Core.Requests.ConsumerRequests;
using Enterprise.Web3.ProjectManager.Api.Core.Services;
using System.Linq;
using Xunit;

namespace Enterprise.Web3.ProjectManager.Api.UnitTest
{
    /// <summary>
    /// Тесты <see cref="ConsumerService"/>
    /// </summary>
    public class ConsumerServiceTest : UnitTestBase
    {
        private readonly Consumer _consumer1 = new Consumer
        {
            Id = 1,
            ConsumerTypeId = 1,
            Name = "1",
            Description = "bbbbbb",
            Inn = 123123,
            Email = "asdasd",
            Address = "asdasdsa",
            ConsumerType = new ConsumerType()
        };
        private readonly ConsumerType _consumerType1 = new ConsumerType();
        private readonly IDbContext _dbContext;
        public ConsumerServiceTest()
        {
            _dbContext = CreateInMemoryContext(x => x.AddRange(
                _consumer1,
                _consumerType1,
                new Consumer
                {
                    Id = 2,
                    ConsumerTypeId = 2,
                    Name = "2",
                    Description = "aaaaaaa",
                    Inn = 111111,
                    Address = "aaaaaaa",
                    Email = "aaaaa",
                },
                new Consumer
                {
                    Id = 3,
                    ConsumerTypeId = 2,
                    Name = "3",
                    Description = "sadasd",
                    Inn = 123123,
                    Address = "asdasd",
                    Email = "asdasd",
                }));
        }

        /// <summary>
        /// Проверка на Ноль
        /// </summary>
        [Fact]
        public void Get_Null_Data()
        {
            var service = new ConsumerService(_dbContext);
            var consumers = service.GetTable(_consumer1.Id);
            Assert.NotNull(consumers);
        }

        /// <summary>
        /// Тестирование Сервисов
        /// </summary>
        [Fact]
        public void Add_ValidEntity_ToExport()
        {
            var service = new ConsumerService(_dbContext);
            var entity = new SaveConsumerRequest
            {
                Name = "Test",
                Inn = 43,
                ConsumerTypeId = _consumerType1.Id
            };

            // Act
            var response = service.Add(entity);
            Assert.NotNull(response);

            // Assert
            var found = _dbContext.Consumers.FirstOrDefault(x => x.Id == response.Id);
            Assert.NotNull(found);
            Assert.NotEqual(entity.Name, found.Name);
            Assert.NotEqual(entity.Inn, found.Inn);
            Assert.NotEqual(entity.ConsumerTypeId, found.ConsumerTypeId);
        }
    }
}

