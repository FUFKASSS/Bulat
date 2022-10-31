using Enterprise.Web3.ProjectManager.Api.Core.Abstractions;
using Enterprise.Web3.ProjectManager.Api.Core.Entities;
using Enterprise.Web3.ProjectManager.Api.Core.Requests.SkillRequests;
using Enterprise.Web3.ProjectManager.Api.Core.Services;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Enterprise.Web3.ProjectManager.Api.UnitTest
{
    /// <summary>
    /// Тесты <see cref="SkillService"/>
    /// </summary>
    public class SkillServiceTest : UnitTestBase
    {
        private readonly Skill _skill1 = new Skill
        {
            Id = 1,
            SkillTypeId = 1,
            MaxPoints = 100,
            Name = "1",
            SkillType = new SkillType()
        };
        private readonly SkillType _skillType1 = new SkillType();
        private readonly IDbContext _dbContext;

        public SkillServiceTest()
        {
            _dbContext = CreateInMemoryContext(x => x.AddRange(
                _skill1,
                _skillType1,
                new Skill
                {
                    Id = 2,
                    SkillTypeId = 2,
                    Name = "2"
                },
                new Skill
                {
                    Id = 3,
                    SkillTypeId = 2,
                    Name = "4"
                }));
        }

        /// <summary>
        /// 24енуеокол
        /// </summary>
        [Fact]
        public async Task Get_Null_ReturnsRowDataAsync()
        {
            var service = new SkillService(_dbContext);
            var skills = await service.GetSkillsAsync(_skill1.Name);

            var found = Assert.Single(skills.Keys);
        }

        [Fact]
        public void Add_ValidEntity_AddsToStorage()
        {
            var service = new SkillService(_dbContext);
            var entity = new SaveSkillRequest
            {
                Name = "Test",
                MaxPoints = 43,
                SkillTypeId = _skillType1.Id
            };

            // Act
            var response = service.Add(entity);
            Assert.NotNull(response);

            // Assert
            var found = _dbContext.Skills.FirstOrDefault(x => x.Id == response.Id);
            Assert.NotNull(found);
            Assert.Equal(entity.Name, found.Name);
            Assert.Equal(entity.MaxPoints, found.MaxPoints);
            Assert.Equal(entity.SkillTypeId, found.SkillTypeId);
        }
    }
}
