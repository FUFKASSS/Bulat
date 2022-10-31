using Dapper;
using Enterprise.Web3.ProjectManager.Api.Core.Abstractions;
using Enterprise.Web3.ProjectManager.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Enterprise.Web3.ProjectManager.Api.Data.PostgreSql.Repositories
{
    /// <summary>
    /// Репозиторий заказчика
    /// </summary>
    public class ConsumerRepository : IConsumerRepository
    {
        /// <summary>
        /// Адрес подключения к базе данных
        /// </summary>
        private readonly IDbConnection _dbConnection;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbConnection">Подключение к БД</param>
        public ConsumerRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        /// <summary>
        /// Создает готовый элемент в таблице
        /// </summary>
        /// <param name="entity">Элемент</param>
        /// <returns>количество заданных ячеек</returns>
        public int Add(Consumer entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            var command = _dbConnection.Execute(@"
INSERT INTO public.consumer
(name, description, inn, address, email)
VALUES(@Name, @Description, @Inn, @Address, @Email);",
                    entity);
            return command;
        }

        /// <summary>
        /// Редактирует сущности
        /// </summary>
        /// <param name="entity">сущность</param>
        public void Update(Consumer entity)
        {
            _dbConnection.Execute(@"
UPDATE public.consumer
SET name=@Name, description=@Description, inn=@Inn, address=@Address, email=@Email
WHERE id = @Id;"
              , entity);
            System.Console.WriteLine($"changed {entity.Id}");
        }

        /// <summary>
        /// Удаляет элемент в таблице
        /// </summary>
        /// <param name="Id">Ид</param>
        public void Delete(int Id)
        {
            _dbConnection.Execute(
@"DELETE FROM public.consumer
WHERE id=@Id;",
             new { Id });

            System.Console.WriteLine($"Id={Id} Delete");
        }

        /// <summary>
        /// Показывает элементы в таблице
        /// </summary>
        /// <returns>Список</returns>
        public List<Consumer> Get()
        {
            var consumers = _dbConnection.Query<Consumer>(
"SELECT * FROM public.consumer;").ToList();
            return consumers;
        }

        /// <summary>
        /// Создает таблицу
        /// </summary>
        public void CreateTable()
        {
            _dbConnection.Execute(@"
CREATE TABLE IF NOT EXISTS public.consumer (
id int4 NOT NULL GENERATED ALWAYS AS IDENTITY,
name text NOT NULL,
description text NULL,
inn text NULL,
address text NULL,
email text NOT NULL,
CONSTRAINT consumer_pk PRIMARY KEY(id)
            );");
        }

        public List<Consumer> Get(int Id)
        {
            var consumers = _dbConnection.Query<Consumer>(
@"SELECT * FROM public.consumer
WHERE id=@id;",
             new { Id }).ToList();
            return consumers;
            System.Console.Write("Заказчик найден");
        }
    }
}
