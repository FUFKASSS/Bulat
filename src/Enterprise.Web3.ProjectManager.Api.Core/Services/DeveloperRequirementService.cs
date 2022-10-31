using Enterprise.Web3.ProjectManager.Api.Console;
using Enterprise.Web3.ProjectManager.Api.Console.Abstractions;
using Enterprise.Web3.ProjectManager.Api.Core.Abstractions;
using Enterprise.Web3.ProjectManager.Api.Core.Requests.DeveloperRequirementRequests;
using System.Collections.Generic;

namespace Enterprise.Web3.ProjectManager.Api.Core
{
    /// <summary>
    /// Класс с логикой требований к разработчкику
    /// </summary>
    public class DeveloperRequirementService : IDeveloperRequirementService
    {
        private IDeveloperRequirementRepository _developerRequirementRepository;

        /// <summary>
        /// Конструткор требований к разработчику
        /// </summary>
        /// <param name="developerRequirementRepository">БД требований к разработчику</param>
        public DeveloperRequirementService(IDeveloperRequirementRepository developerRequirementRepository)
        {
            _developerRequirementRepository = developerRequirementRepository;
        }

        /// <summary>
        /// Создает строку в таблице
        /// </summary>
        /// <param name="entity">айди проекта, айди фичи и т.д.</param>
        public void Add(DeveloperRequirement entity)
        {
            if (entity is null)
                throw new System.ArgumentNullException(nameof(entity));

            if (string.IsNullOrWhiteSpace(entity.Description))
                throw new System.Exception("не заполнено поле описание");

            if (entity.Points < 0)
                throw new System.Exception("Количество баллов должно быть положительным");

            if (entity.Hours < 0)
                throw new System.Exception("Количество часов должно быть положительным");

            if (entity.ProjectFeatureId < 0)
                throw new System.Exception("Айди фичи должен быть положительным");

            if (entity.SkillId < 0)
                throw new System.Exception("Айди скила должен быть положительным");

            _developerRequirementRepository.Add(entity);
        }

        /// <summary>
        /// Возвращает всю таблицу
        /// </summary>
        /// <returns>Все данные таблицы</returns>
        public List<DeveloperRequirement> Get()
        {
            return _developerRequirementRepository.Get();
        }


        /// <summary>
        /// Получить требования разработчика в группировке по описанию.
        /// </summary>
        /// <returns>требования разработчика</returns>
        public Dictionary<string, List<DeveloperRequirement>> GetDeveloperRequirement()
        {
            var developerRequirements = _developerRequirementRepository.Get();
            if (developerRequirements == null)
                return null;

            var result = new Dictionary<string, List<DeveloperRequirement>>();

            foreach (var developerRequirement in developerRequirements)
            {
                if (result.ContainsKey(developerRequirement.Description))
                {
                    result[developerRequirement.Description].Add(developerRequirement);
                }
                else
                {
                    result[developerRequirement.Description] = new List<DeveloperRequirement> { developerRequirement };
                }
            }

            return result;
        }

        /// <summary>
        /// Удалить строку с заданным айди
        /// </summary>
        /// <param name="id">айди</param>
        public void Delete(int Id)
        {
            if (Id < 0)
                throw new System.Exception("Айди должно быть положительным");
            _developerRequirementRepository.Delete(Id);
        }

        /// <summary>
        /// Изменяет строку в таблице
        /// </summary>
        /// <param name="entity">айди проекта, айди фичи и т.д.</param>
        public void Update(DeveloperRequirement entity)
        {
            if (entity is null)
                throw new System.ArgumentNullException(nameof(entity));

            if (string.IsNullOrWhiteSpace(entity.Description))
                throw new System.Exception("не заполнено поле описание");

            if (entity.Points < 0)
                throw new System.Exception("Количество баллов должно быть положительным");

            if (entity.Hours < 0)
                throw new System.Exception("Количество часов должно быть положительным");

            if (entity.ProjectFeatureId < 0)
                throw new System.Exception("Айди фичи должен быть положительным");

            if (entity.ProjectId < 0)
                throw new System.Exception("Айди проекта должен быть положительным");

            if (entity.SkillId < 0)
                throw new System.Exception("Айди скила должен быть положительным");

            if (entity.Id < 0)
                throw new System.Exception("Айди должен быть положительным");

            _developerRequirementRepository.Update(entity);
        }

        /// <summary>
        /// Проверка запроса Add на исключения
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public SaveDeveloperRequirementResponse Add(SaveDeveloperRequirementRequest entity)
        {
            if (entity is null)
                throw new System.ArgumentNullException(nameof(entity));

            if (entity.Points < 0)
                throw new System.Exception("Количество баллов должно быть положительным");

            if (entity.Hours < 0)
                throw new System.Exception("Количество часов должно быть положительным");

            if (entity.ProjectFeatureId < 0)
                throw new System.Exception("Айди фичи должен быть положительным");

            if (entity.ProjectId < 0)
                throw new System.Exception("Айди проекта должен быть положительным");

            if (entity.SkillId < 0)
                throw new System.Exception("Айди скила должен быть положительным");

            if (string.IsNullOrWhiteSpace(entity.Description))
                throw new System.Exception("Не заполнено поле Описание");

            var developerRequirement = new DeveloperRequirement
            {
                Description = entity.Description,
                Points = entity.Points,
                Hours = entity.Hours,
                ProjectFeatureId = entity.ProjectFeatureId,
                ProjectId = entity.ProjectId,
                SkillId = entity.SkillId,
            };
            _developerRequirementRepository.Add(developerRequirement);

            return new SaveDeveloperRequirementResponse
            {
                Id = developerRequirement.Id
            };
        }

        /// <summary>
        /// Получить список проектов по ИД 
        /// </summary>
        /// <returns>проект</returns>
        public List<DeveloperRequirement> GetById(int id)
        {
            return _developerRequirementRepository.GetById(id);
        }

    }
}
