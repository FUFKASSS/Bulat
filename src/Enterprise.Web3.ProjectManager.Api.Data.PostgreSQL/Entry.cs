using Enterprise.Web3.ProjectManager.Api.Console.Abstractions;
using Enterprise.Web3.ProjectManager.Api.Core.Abstractions;
using Enterprise.Web3.ProjectManager.Api.Data.PostgreSql.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Npgsql;
using System.Data;

namespace Enterprise.Web3.ProjectManager.Api.Data.PostgreSql
{
    /// <summary>
    /// Регистрация зависимостей проекта
    /// </summary>
    static public class Entry
    {
        /// <summary>
        ///Регистрация зависимостей проекта
        /// </summary>
        /// <param name="services">Сервис</param>
        /// <param name="ConnectionString">строка подключения к БД</param>
        /// <returns>контейнер зависимосте</returns>
        static public IServiceCollection AddPostgreSql(
            this IServiceCollection services,
            string connectionString,
            ILoggerFactory sqlLoggerFactory)
        {
            if (services is null)
            {
                throw new System.ArgumentNullException(nameof(services));
            }

            if (connectionString is null)
            {
                throw new System.ArgumentNullException(nameof(connectionString));
            }

            services.AddDbContext<EfContext>(opt =>
            {
                if (sqlLoggerFactory != null)
                {
                    opt.UseLoggerFactory(sqlLoggerFactory);
                }

                opt.UseNpgsql(connectionString);
                opt.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
            });
            services.AddScoped<IDbContext>(sp => sp.GetRequiredService<EfContext>());

           // services.BuildServiceProvider().GetRequiredService<EfContext>().Database.Migrate();

            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IDeveloperRequirementRepository, DeveloperRequirementRepository>();
            services.AddTransient<ISkillRepository, SkillRepository>();
            services.AddTransient<IConsumerRepository, ConsumerRepository>();
            services.AddTransient<IProjectIterationRepository, ProjectIterationRepository>();
            services.AddTransient<IDeveloperSkillRepository, DeveloperSkillRepository>();
            return services.AddScoped<IDbConnection, NpgsqlConnection>(sp =>
            {
                var connection = new NpgsqlConnection(connectionString);
                connection.Open();
                return connection;
            });
        }
    }
}
