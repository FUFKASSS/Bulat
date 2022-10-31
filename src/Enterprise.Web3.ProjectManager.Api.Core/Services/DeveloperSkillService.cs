using Enterprise.Web3.ProjectManager.Api.Core.Abstractions;
using Enterprise.Web3.ProjectManager.Api.Core.Entities;
using System;
using System.Collections.Generic;

namespace Enterprise.Web3.ProjectManager.Api.Core.Services
{
    /// <inheritdoc/>
    public class DeveloperSkillService : IDeveloperSkillService
    {
        private IDeveloperSkillRepository _developerSkillRepository;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="developerSkillRepository">Репозиторий скилов разработчика</param>
        public DeveloperSkillService(IDeveloperSkillRepository developerSkillRepository)
        {
            _developerSkillRepository = developerSkillRepository;
        }

        /// <summary>
        /// Обновить сущность
        /// </summary>
        /// <param name="entity">Сущность скила разработчика</param>
        public void Update(DeveloperSkill entity)
        {
            if (entity.Id is 0)
                throw new ArgumentNullException(nameof(entity));

            if (string.IsNullOrWhiteSpace(entity.DeveloperId.ToString()))
                throw new Exception("Заполнить поле ИД разработчика");

            if (string.IsNullOrWhiteSpace(entity.SkillId.ToString()))
                throw new Exception("Заполнить поле ИД скила");

            if (entity.Points < 0)
                throw new Exception("Количество баллов не может быть отрицательным");

            if (entity.Comment.Length > 140)
                throw new Exception("Длина комментария не должна превышать 140 символов");

            _developerSkillRepository.Update(entity);
        }

        /// <summary>
        /// Удалить сущность из таблицы
        /// </summary>
        /// <param name="id">ИД сущности скила разработчика</param>
        public void Delete(int id)
        {
            if (id is 0)
                throw new ArgumentNullException(nameof(id));

            _developerSkillRepository.Delete(id);
        }


        /// <summary>
        /// Добавить сущность
        /// </summary>
        /// <param name="entity">Сущность скила разработчика</param>
        public void Add(DeveloperSkill entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            if (string.IsNullOrWhiteSpace(entity.DeveloperId.ToString()))
                throw new Exception("Заполнить поле ИД разработчика");

            if (string.IsNullOrWhiteSpace(entity.SkillId.ToString()))
                throw new Exception("Заполнить поле ИД скила");

            if (entity.Points < 0)
                throw new Exception("Количество баллов не может быть отрицательным");

            if (entity.Comment.Length > 140)
                throw new Exception("Длина комментария не должна превышать 140 символов");

            _developerSkillRepository.Add(entity);
        }

        /// <summary>
        /// Получить сущности в группировке по баллам
        /// </summary>
        /// <returns>Скилы разработчика</returns>
        public Dictionary<string, List<DeveloperSkill>> GetDeveloperSkills()
        {
            var developerSkills = _developerSkillRepository.Get();

            var result = new Dictionary<string, List<DeveloperSkill>>();

            foreach (var developerSkill in developerSkills)
            {
                if (result.ContainsKey(developerSkill.Points.ToString()))
                {
                    result[developerSkill.Points.ToString()].Add(developerSkill);
                }
                else
                {
                    result[developerSkill.Points.ToString()] = new List<DeveloperSkill> { developerSkill };
                }
            }
            return result;
        }
    }
}
