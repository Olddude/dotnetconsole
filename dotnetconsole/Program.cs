using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace dotnetconsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile
                (
                    path: "appsettings.json",
                    optional: false,
                    reloadOnChange: true
                )
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();

            var serviceCollection = new ServiceCollection()
                .RegisterComponents(configuration);

            using (var serviceProvider = serviceCollection.BuildServiceProvider())
            {
                var service = serviceProvider.GetService<IMessageReadService>();
                service.Read();
            }
        }
    }
}
