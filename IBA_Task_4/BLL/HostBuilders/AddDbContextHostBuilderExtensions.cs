using DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace BLL.HostBuilders
{
    public static class AddDbContextHostBuilderExtensions
    {
        public static string CString { get; set; }

        public static IHostBuilder AddDbContext(this IHostBuilder host)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                        .AddJsonFile("appsettings.json")
                        .Build();

            var dbConnection = configuration.GetConnectionString("DbConnection");

            host.ConfigureServices((context, services) =>
            {
                services.AddDbContext<AppDbContext>(options => options.UseSqlServer(dbConnection));
            });

            return host;
        }
    }
}
