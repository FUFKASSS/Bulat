using Enterprise.Web3.ProjectManager.Api.Data.PostgreSql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;

namespace Enterprise.Web3.ProjectManager.Api.UnitTest
{
    /// <summary>
    /// Базовый МТ
    /// </summary>
    public class UnitTestBase
    {
        /// <summary>
        /// Создать контекст с БД в памяти
        /// </summary>
        /// <param name="dbSeeder">Сидер БД</param>
        /// <returns>Контекст EF</returns>
        protected EfContext CreateInMemoryContext(Action<EfContext> dbSeeder = null)
        {
            var options = new DbContextOptionsBuilder<EfContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            using (var context = new EfContext(options))
            {
                dbSeeder?.Invoke(context);
                context.SaveChangesAsync().GetAwaiter().GetResult();
            }

            // возвращаем чистый контекст для тестов
            return new EfContext(options);
        }
    }
}
