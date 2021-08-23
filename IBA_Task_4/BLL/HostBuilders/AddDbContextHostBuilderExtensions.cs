using DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace BLL.HostBuilders
{
    public static class AddDbContextHostBuilderExtensions
    {
        public static string CString { get; set; }

        public static IHostBuilder AddDbContext(this IHostBuilder host)
        {
            var rootPath = Directory.GetParent(
                Directory.GetParent(
                    Directory.GetParent(
                        Directory.GetParent(
                            Directory.GetParent(
                                AppDomain.CurrentDomain.BaseDirectory).ToString()).ToString()).ToString()).ToString()).ToString();
            var path = Path.Combine(rootPath,"BLL");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                        .SetBasePath(path)
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
