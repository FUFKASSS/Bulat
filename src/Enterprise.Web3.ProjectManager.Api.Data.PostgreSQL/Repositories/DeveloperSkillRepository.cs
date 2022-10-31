using Dapper;
using Enterprise.Web3.ProjectManager.Api.Core.Abstractions;
using Enterprise.Web3.ProjectManager.Api.Core.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Enterprise.Web3.ProjectManager.Api.Data.PostgreSql.Repositories
{
    /// <summary>
    /// Репозиторий скилла разработчика
    /// </summary>
    public class DeveloperSkillRepository : IDeveloperSkillRepository
    {
        private readonly IDbConnection _dbConnection;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbConnection">Подключение к БД</param>
        public DeveloperSkillRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        /// <summary>
        /// Добавляет запись в таблицу
        /// </summary>
        /// <param name="entity">Элемент</param>
        /// <returns>Количество заполненных ячеек</returns>
        public int Add(DeveloperSkill entity)
        {
            var action = _dbConnection.Execute(@"
                    INSERT INTO public.developer_skill
                    (developer_id, skill_id, points, comment)
                    VALUES(@DeveloperId, @SkillId, @Points, @Comment);",
                entity);
            return action;
        }
        /// <summary>
        /// Удаляет запись из таблицы
        /// </summary>
        /// <param name="id">ИД записи</param>
        public void Delete(int id)
        {
            var action = _dbConnection.Execute(@"
                    DELETE FROM public.developer_skill
                    WHERE id = @id;",
                 new { id });
        }
        /// <summary>
        /// Получить список навыков разработчиков
        /// </summary>
        /// <returns>Список навыков</returns>
        public List<DeveloperSkill> Get()
        {
            var skills = _dbConnection.Query<DeveloperSkill>(@"
                    SELECT * FROM public.developer_skill;")
                .ToList();
            return skills;
        }

        /// <summary>
        /// Создать таблицу с навыками разработчиков
        /// </summary>
        public void CreateTable()
        {
            _dbConnection.Execute(@"
                    CREATE TABLE IF NOT EXISTS public.developer_skill (
                        id int4 NOT NULL GENERATED ALWAYS AS IDENTITY,
                        developer_id int4 NOT NULL,
                        skill_id int4 NOT NULL,
                        points int4 NOT NULL,
                        comment text NULL,
                        CONSTRAINT developer_skill_pk PRIMARY KEY(id));"
                    );
        }

        /// <summary>
        /// Обновить поля
        /// </summary>
        public void Update(DeveloperSkill entity)
        {
            _dbConnection.Execute(@"
                    UPDATE public.developer_skill
                    SET developer_id=@DeveloperId, 
                        skill_id=@SkillId, 
                        points=@Points, 
                        comment=@Comment
                    WHERE id = @Id;",
                    entity);
        }
    }
}