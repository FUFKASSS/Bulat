using Enterprise.Web3.ProjectManager.Api.Core.Abstractions;
using Enterprise.Web3.ProjectManager.Api.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Enterprise.Web3.ProjectManager.Api.Core
{
    /// <summary>
    /// Регистрация зависимостей проекта
    /// </summary>
    static public class Entry
    {
        /// <summary>
        /// Регистрация зависимостей проекта
        /// </summary>
        /// <param name="services">сервисы</param>
        /// <returns>Контейнер зависимостей</returns>
        static public IServiceCollection AddCore(this IServiceCollection services)
        {
            if (services is null)
            {
                throw new System.ArgumentNullException(nameof(services));
            }

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ISkillService, SkillService>();
            services.AddTransient<IConsumerService, ConsumerService>();
            services.AddTransient<IProjectIterationService, ProjectIterationService>();
            services.AddTransient<IDeveloperSkillService, DeveloperSkillService>();
            services.AddTransient<IDeveloperRequirementService, DeveloperRequirementService>();

            return services;
        }
    }
}
