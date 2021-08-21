using BLL.Contracts;
using BLL.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BLL.HostBuilders
{
    public static class AddServicesHostBuilderExtensions
    {
        public static IHostBuilder AddServices(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddScoped(typeof(ICrudService<>), typeof(CrudService<>));

                services.AddSingleton<IProjectService, ProjectService>();
                services.AddSingleton<ITaskService, TaskService>();
                services.AddSingleton<IUserService, UserService>();
            });

            return host;
        }
    }
}
