using System.Reflection;
using System.Threading.Tasks;
using HelloWorld.Cli.Commands;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HelloWorld.Cli
{
    public static class Program
    {
        static async Task<int> Main(string[] args) => await CreateHostBuilder().BuildConsole().RunConsoleAsync(args);

        private static IHostBuilder CreateHostBuilder() => Host.CreateDefaultBuilder().ConfigureServices(RegisterCommands);

        private static void RegisterCommands(IServiceCollection services)
        {
            services.AddCommandsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddCommandLineBuilder();
        }

        private static IHost BuildConsole(this IHostBuilder hostBuilder) => hostBuilder.UseConsoleLifetime().Build();
    }
}
