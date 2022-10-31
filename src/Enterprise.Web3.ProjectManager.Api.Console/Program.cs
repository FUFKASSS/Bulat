using Enterprise.Web3.ProjectManager.Api.Core.Abstractions;
using Enterprise.Web3.ProjectManager.Api.Core.Entities;
using Enterprise.Web3.ProjectManager.Api.Core.Exceptions;
using Enterprise.Web3.ProjectManager.Api.Core.Requests.SkillRequests;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Entry = Enterprise.Web3.ProjectManager.Api.Core.Entry;

namespace Enterprise.Web3.ProjectManager.Api.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            Provider = Setup();
            Skills();
            DeveloperSkills();
            try
            {
                Provider = Setup();
                DeveloperRequrement();
            }
            catch (ApplicationExceptionBase ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Что-то пошло не так");
            }
        }

        private static IServiceProvider Provider;

        /// <summary>
        /// Регистрация зависимостей
        /// </summary>
        /// <returns>Контейнер зависимостей</returns>
        private static IServiceProvider Setup()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false)
                .AddUserSecrets(typeof(Program).Assembly)
                .AddEnvironmentVariables()
                .Build();

            var services = new ServiceCollection();
            Entry.AddCore(services);
            Data.PostgreSql.Entry.AddPostgreSql(services, configuration["DbConnection"]);
            return services.BuildServiceProvider();
        }

        private static void Skills()
        {
            using (var scope = Provider.CreateScope())
            {
                var service = scope.ServiceProvider.GetRequiredService<ISkillService>();
                service.Add(new SaveSkillRequest
                {
                    Description = "test"
                });
                var result = service.GetSkills();
            }
        }

        private static void DeveloperSkills()
        {
            using (var scope = Provider.CreateScope())
            {
                var service = Provider.GetRequiredService<IDeveloperSkillService>();
                service.Add(new DeveloperSkill
                {
                    DeveloperId = 12,
                    SkillId = 15,
                    Points = 10,
                    Comment = "Новичок"
                });
                service.Delete(4);
                service.Update(new DeveloperSkill
                {
                    Id = 3,
                    DeveloperId = 1,
                    SkillId = 34,
                    Points = 21,
                    Comment = "Начинающий"
                });
                var result = service.GetDeveloperSkills();
            }
        }

        /// <summary>
        /// Cоздания объекта, который представляет тип service
        /// </summary>
        private static void DeveloperRequrement()
        {
            using (var scope = Provider.CreateScope())
            {
                var service = scope.ServiceProvider.GetRequiredService<IDeveloperRequirementService>();
                service.Add(new DeveloperRequirement
                {
                    Description = "Test345678",
                    SkillId = 36,
                    Hours = 100,
                    ProjectFeatureId = 5,
                    ProjectId = 10,
                    Points = 100
                });
                service.Delete(37);
                service.Update(new DeveloperRequirement
                {
                    Id = 6,
                    Description = "Test365",
                    SkillId = 36,
                    Hours = 100,
                    ProjectFeatureId = 50,
                    ProjectId = 10,
                    Points = 10
                });
                var result = service.GetDeveloperRequirement();
            }
        }
    }
}