using Dapper;
using Enterprise.Web3.ProjectManager.Api.Core.Abstractions;
using Enterprise.Web3.ProjectManager.Api.Core.Entities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.Web3.ProjectManager.Api.Data.PostgreSql.Repositories
{
    /// <summary>
    /// Репозиторий итерации проектов
    /// </summary>
    public class ProjectIterationRepository : IProjectIterationRepository
    {
        /// <summary>
        /// Строка подключения к базе данных
        /// </summary>
        readonly IDbConnection _dbconnection;

        /// <summary>
        /// Конструктор, зависящий от интерфейса подключения к дб
        /// </summary>
        /// <param name="dbConnection">Объект IDbconnection</param>
        public ProjectIterationRepository(IDbConnection dbConnection)
        {
            _dbconnection = dbConnection;
        }

        /// <summary>
        ///  Возвращение итерации проекта по id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Сущность итерации проекта</returns>
        public virtual List<ProjectIteration> GetById(int id)
        {
            var projects = _dbconnection
                .Query<ProjectIteration>(@$"
                        SELECT id, name, project_id, started_on
                        FROM public.project_iteration
                        WHERE id = {id}")
                .ToList();
            return projects;
        }

        /// <summary>
        /// Получение списка всех итераций проекта
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Список итераций проекта</returns>
        public virtual List<ProjectIteration> Get()
        {
            var projects = _dbconnection
                .Query<ProjectIteration>(@$"
                        SELECT id, name, project_id, started_on
                        FROM public.project_iteration")
                        .ToList();
            return projects;
        }

        /// <summary>
        /// Добавить итерацию проекта
        /// </summary>
        public virtual void Add(ProjectIteration project)
        {
            if (project is null)
            {
                throw new ArgumentNullException(nameof(project));
            }

            _dbconnection.Execute(@"
                INSERT INTO public.project_iteration
                (name, project_id, started_on, finished_on)
                VALUES(@name, @projectid, @startedon, @finishedon)", project);
        }

        /// <summary>
        /// Удаляет итерацию проекта
        /// </summary>
        /// <param name="id">Id удаляемого проекта</param>
        public void Delete(int id)
        {
            _dbconnection.Execute($"DELETE FROM public.project_iteration WHERE id = {id}");
        }

        /// <summary>
        /// Изменение итерации проекта
        /// </summary>
        /// <param name="id">id </param>
        /// <param name="project">Сущность итерации проекта</param>
        public void Update(int id, ProjectIteration project)
        {
            if (project is null)
            {
                throw new ArgumentNullException(nameof(project));
            }

            _dbconnection.Execute(@"UPDATE public.project_iteration
                SET ""name""=@name, project_id=@projectid, started_on=@startedon, finished_on=@finishedon
                WHERE id = 0;
                ", project);
        }

        /// <summary>
        /// Создание таблицыы
        /// </summary>
        public void CreateTable()
        {
            _dbconnection.Execute(@"CREATE TABLE public.project_iteration (
                id int4 NOT NULL GENERATED ALWAYS AS IDENTITY,
                ""name"" text NOT NULL,
                project_id int4 NOT NULL,
                started_on date NOT NULL,
                finished_on date NOT NULL,
                CONSTRAINT project_iteration_pk PRIMARY KEY(id)
                );
                IF NOT EXIST");
        }
    }

}
