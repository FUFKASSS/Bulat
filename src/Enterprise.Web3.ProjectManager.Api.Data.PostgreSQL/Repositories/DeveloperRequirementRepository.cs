using Dapper;
using Enterprise.Web3.ProjectManager.Api.Console;
using Enterprise.Web3.ProjectManager.Api.Console.Abstractions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace Enterprise.Web3.ProjectManager.Api.Data.PostgreSql.Repositories
{
    /// <summary>
    /// Репозиторий требований к разработчику
    /// </summary>
    public class DeveloperRequirementRepository : IDeveloperRequirementRepository
    {

        private readonly IDbConnection _dbConnection;

        /// <summary>
        /// Конструткор требований к разработчику
        /// </summary>
        /// <param name="developerRequirementRepository">БД требований к разработчику</param>
        public DeveloperRequirementRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        /// <summary>
        /// Создает строку в таблице
        /// </summary>
        /// <param name="entity">айди проекта, айди фичи и т.д.</param>
        /// <returns>Количество изменненых ячеек</returns>
        public int Add(DeveloperRequirement entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            var rows = _dbConnection.Execute(@"
INSERT INTO public.developer_requirement
(project_id, project_feature_id, description, skill_id, points, hours)
VALUES(@ProjectId, @ProjectFeatureId, @Description, @SkillId, @Points, @Hours)", entity);

            return rows;
        }

        /// <summary>
        /// Изменяет строку в таблице
        /// </summary>
        /// <param name="entity">айди проекта, айди фичи и т.д.</param>
        public void Update(DeveloperRequirement entity)
        {
            if (entity is null)
            {
                throw new ArgumentException(nameof(entity));
            }
            _dbConnection.Execute(@"
UPDATE public.developer_requirement
SET project_id =@ProjectId, project_feature_id =@ProjectFeatureId, description =@Description, skill_id =@SkillId, points=@Points, hours =@Hours
WHERE id =@Id", entity);
            System.Console.WriteLine($"Строка с Id: {entity.Id} изменена");
        }

        /// <summary>
        /// Удалить запись с данным ИД
        /// </summary>
        /// <param name="id">ИД, строка с которым будет удалена</param>
        public void Delete(int id)
        {
            _dbConnection.Execute(@"
DELETE 
FROM public.developer_requirement
WHERE id =@Id", new DeveloperRequirement { Id = id });
            System.Console.WriteLine($"Строка с Id: {id} удалена");
        }

        /// <summary>
        /// Получить все записи таблицы
        /// </summary>
        /// <returns>Список</returns>
        public List<DeveloperRequirement> Get()
        {
            var list = _dbConnection
                    .Query<DeveloperRequirement>(@"
SELECT *
FROM public.developer_requirement;").ToList();
            foreach (var x in list)
                System.Console.WriteLine(
                    $"id={x.Id}, project_id={x.ProjectId}, project_feature_id={x.ProjectFeatureId}, description={x.Description}, skill_id={x.SkillId}, points={x.Points}, hours={x.Hours} ");
            return list;

        }

        /// <summary>
        /// Создать таблицу, если её еще нет
        /// </summary>
        public void CreateTable()
        {
            _dbConnection.Execute(@"CREATE TABLE IF NOT EXISTS public.developer_requirement (
    id int4 NOT NULL GENERATED ALWAYS AS IDENTITY,
    project_id int4 NOT NULL,
    project_feature_id int4 NULL,
    description text NULL,
    skill_id int4 NOT NULL,
    points int4 NULL,
    hours int4 NULL,
    CONSTRAINT developer_requirement_pk PRIMARY KEY (id));");
        }

        /// <summary>
        /// Получить таблицу с записью проекта по ИД
        /// </summary>
        /// <param name="id">ИД</param>
        /// <returns>проект</returns>
        public List<DeveloperRequirement> GetById(int id)
        {
            var developerRequirements = _dbConnection.Query<DeveloperRequirement>(
@"SELECT * FROM public.developer_requirement
WHERE id=@id;",
             new { id }).ToList();
            return developerRequirements;
        }
    }
}
