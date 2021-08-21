using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PL.Views;

namespace BLL.HostBuilders
{
    public static class AddViewsHostBuilderExtensions
    {
        public static IHostBuilder AddViews(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<MainWindow>();
            });

            return host;
        }
    }
}
