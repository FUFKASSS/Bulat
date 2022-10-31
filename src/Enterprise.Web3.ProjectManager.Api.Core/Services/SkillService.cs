using Enterprise.Web3.ProjectManager.Api.Core.Abstractions;
using Enterprise.Web3.ProjectManager.Api.Core.Entities;
using Enterprise.Web3.ProjectManager.Api.Core.Exceptions;
using Enterprise.Web3.ProjectManager.Api.Core.Requests.SkillRequests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enterprise.Web3.ProjectManager.Api.Core.Services
{
    /// <summary>
    /// Класс с логикой скилов
    /// </summary>
    public class SkillService : ISkillService
    {
        readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">Контекст БД</param>
        public SkillService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// ыапкцп
        /// </summary>
        /// <param name="entity">укп</param>
        /// <returns>ИД</returns>
        public SaveSkillResponse Add(SaveSkillRequest entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (string.IsNullOrWhiteSpace(entity.Name))
            {
                throw new ApplicationExceptionBase("не заполнено поле Название");
            }

            if (entity.MaxPoints < 0)
            {
                throw new Exception("Количество баллов должно быть положительным");
            }

            if (entity.MaxPoints > 100)
            {
                throw new Exception("Количество баллов не должно быть больше 100");
            }

            var skillType = _dbContext.SkillTypes.FirstOrDefault(x => x.Id == entity.SkillTypeId);
            var skill = new Skill
            {
                Name = entity.Name,
                MaxPoints = entity.MaxPoints,
                SkillType = skillType
            };
            _dbContext.Skills.Add(skill);

            _dbContext.SaveChanges();

            return new SaveSkillResponse
            {
                Id = skill.Id
            };
        }

        /// <summary>
        /// Получить скилы в группировке по типу
        /// </summary>
        /// <returns>Скилы</returns>
        public async Task<Dictionary<string, List<Skill>>> GetSkillsAsync(string name)
        {
            var query = _dbContext.Skills
                .Where(x => name == null || x.Name == name);

            query = query
                .Where(x => x.MaxPoints > 25);

            var selected = query
                .Select(x => new GetSkillResponseItem
                {
                    SkillName = x.Name,
                    SkillTypeName = x.SkillType.Name,
                    SkillTypeId = x.SkillType.Id
                });

            var result = await query
                .ToListAsync();

            return null;
        }

        public class GetSkillResponseItem
        {
            public string SkillName { get; set; }
            public int SkillTypeId { get; set; }
            public string SkillTypeName { get; set; }
        }
    }
}