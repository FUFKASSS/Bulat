using Dapper;
using Enterprise.Web3.ProjectManager.Api.Core.Abstractions;
using Enterprise.Web3.ProjectManager.Api.Core.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Enterprise.Web3.ProjectManager.Api.Data.PostgreSql.Repositories
{
    /// <summary>
    /// Репозиторий проектов
    /// </summary>
    public class ProjectRepository : IProjectRepository
    {

        /// <summary>
        /// Адрес подключения к базе данных
        /// </summary>
        private readonly IDbConnection _dbConnection;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbConnection">Подключение к БД</param>
        public ProjectRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        /// <summary>
        /// Добавление записи о новом проекте
        /// </summary>
        /// <param name="entity">Элемент</param>
        /// <returns>ИД элемента</returns>
        public int Add(Project entity)
        {
            var prow = _dbConnection.Execute($"INSERT INTO public.project (name, description, started_on, finished_on) VALUES(@Name, @Description, @StartedOn, @FinishedOn);", entity);
            return prow;
        }

        /// <summary>
        /// Получение списка всех записей
        /// </summary>
        /// <returns>Список проектов</returns>
        public List<Project> Get()
        {
            var projects = _dbConnection.Query<Project>("SELECT * FROM public.project").ToList();
            return projects;
        }

        /// <summary>
        /// Удаление записи из бд по определённому ИД
        /// </summary>
        /// <param name="id">ИД объекта</param>
        public void Delete(int id)
        {
            _dbConnection.Execute($"DELETE FROM public.project WHERE id=@Id;", new { id });
        }

        /// <summary>
        /// Создание таблицы
        /// </summary>
        public void CreateTable()
        {
            _dbConnection.Execute(@"CREATE TABLE public.project (
    id int4 NOT NULL GENERATED ALWAYS AS IDENTITY,
    name text NOT NULL,
    description text NULL,
    started_on date NULL,
    finished_on date NULL,
    CONSTRAINT project_pk PRIMARY KEY(id)
);
            ");
        }

        /// <summary>
        /// Обновить запись проекта
        /// </summary>
        /// <param name="entity"></param>
        public void Update(Project entity)
        {
            _dbConnection.Execute(@"
UPDATE public.project
SET name=@Name, description=@Description, started_on=@StartedOn, finished_on=@FinishedOn
WHERE id = @Id;"
              , entity);
            System.Console.WriteLine($"Строка с Id: {entity.Id} Обновлена");
        }
    }
}
