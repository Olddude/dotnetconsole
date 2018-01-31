using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace dotnetconsole
{
    public static class Extensions
    {
        public static IServiceCollection RegisterComponents(this IServiceCollection serviceCollection, IConfiguration configuration)
        {

            serviceCollection.AddLogging((builder) =>
            {
                builder.AddSerilog
                (
                    new LoggerConfiguration()
                       .Enrich.FromLogContext()
                       .ReadFrom.Configuration(configuration)
                       .CreateLogger()
                );
            });

            serviceCollection.AddTransient(typeof(ILogger<>), typeof(Logger<>));

            serviceCollection.AddTransient<IMessageReadService, MyMessageReadService>();

            return serviceCollection;
        }
    }
}
