using Dapper;
using Enterprise.Web3.ProjectManager.Api.Core.Abstractions;
using Enterprise.Web3.ProjectManager.Api.Console;
using Enterprise.Web3.ProjectManager.Api.Core.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Enterprise.Web3.ProjectManager.Api.Data.PostgreSql.Repositories
{
    /// <summary>
    /// Хранилище навыков
    /// </summary>
    public class SkillRepository : ISkillRepository
    {
        private readonly IDbConnection _dbConnection;

        /// <summary>
        /// Создает подключение к базе данных
        /// </summary>
        /// <param name="dbConnection">Параметр подключения к БД</param>
        public SkillRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        /// <summary>
        /// Отправляет данные новой записи в базу данных
        /// </summary>
        /// <param name="entity">Сущность</param>
        /// <returns>Количество заданных ячеек</returns>
        public int Add(Skill entity)
        {
            var command = _dbConnection.Execute(@"
INSERT INTO public.skill(
name,description,skill_type,max_points)
VALUES(@Name,@Description,@SkillType,@MaxPoints);"
                , entity);

            return command;
        }

        /// <summary>
        /// Обновляет запись строки по Id
        /// </summary>
        /// <param name="entity">Данные строк</param>
        public void Update(Skill entity)
        {
            _dbConnection.Execute(@"
UPDATE public.skill
SET name=@Name, description=@Description, skill_type=@SkillType, max_points=@MaxPoints
WHERE id=@Id;"
               , entity);

            System.Console.WriteLine($"Строка с Id: {entity.Id} Обнавлена");
        }

        /// <summary>
        /// Удаляет запись по Id
        /// </summary>
        /// <param name="Id">ИД</param>
        public void Delete(int Id)
        {
            _dbConnection.Execute(@"
DELETE FROM public.skill
WHERE id=@Id;"
                , new { Id });

            System.Console.WriteLine($"Строка с Id: {Id} удалена");
        }

        /// <summary>
        /// Получает из базы данных все записи таблицы
        /// </summary>
        /// <returns>Список умений</returns>
        public virtual List<Skill> Get()
        {
            var skills = _dbConnection.Query<Skill>("SELECT * FROM public.skill;").ToList();
            return skills;
        }

        /// <summary>
        /// Создает таблицу
        /// </summary>
        public void CreateTable()
        {
            _dbConnection.Execute(@"
CREATE TABLE IF NOT EXISTS public.skill(
id int4 NOT NULL GENERATED ALWAYS AS IDENTITY,
name text NOT NULL,
description text NULL,
skill_type text NULL,
max_points int4 NOT NULL,
CONSTRAINT skill_pk PRIMARY KEY (id));"
                );
        }
    }
}