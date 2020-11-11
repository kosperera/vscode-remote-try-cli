using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Invocation;
using Microsoft.Extensions.Hosting;
using System.CommandLine.Parsing;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Linq;

namespace Weather.Cli
{

    public class Program
    {
        static async Task<int> Main(string[] args) => await CreateHostBuilder().BuildConsole().RunConsoleAsync(args);

        private static IHostBuilder CreateHostBuilder() => Host.CreateDefaultBuilder().ConfigureServices(RegisterCommands);

        private static void RegisterCommands(IServiceCollection services)
        {
            services.AddCommandsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddCommandLineBuilder();
        }
    }

    public class Greeter : Command
    {
        public Greeter() : base(name: "greet", "$ dotnet run greet --name 'John Doe'")
        {
            Initialize();
        }

        private void Initialize()
        {
            AddOption(new Option<string>("--name")
            {
                Name = "name",
                Description = "person to greet",
                IsRequired = true
            });

            Handler = CommandHandler.Create<GreeterOptions>(Execute);
        }

        private int Execute(GreeterOptions options)
        {
            Console.WriteLine($"Greetings, {options.Name}");

            return 0;
        }
    }

    public class GreeterOptions
    {
        public string Name { get; }

        public GreeterOptions(string name)
        {
            Name = name;
        }
    }

    internal static class DependencyExtensions
    {
        public static IServiceCollection AddCommandLineBuilder(this IServiceCollection services) => services.AddSingleton<CommandLineBuilder>(new CommandLineBuilder());

        public static IServiceCollection AddCommandsFromAssembly(this IServiceCollection services, Assembly assembly)
        {
            Type openType = typeof(Command);

            assembly.GetExportedTypes()
                    .Where((type) => !type.IsAbstract && !type.IsGenericTypeDefinition && type.BaseType == openType && openType.IsAssignableFrom(type))
                    .ToList()
                    .ForEach((type) => services.AddSingleton(openType, Activator.CreateInstance(type)));

            return services;
        }
    }

    internal static class HostingExtensions
    {
        public static IHost BuildConsole(this IHostBuilder hostBuilder) => hostBuilder.UseConsoleLifetime().Build();

        public static Task<int> RunConsoleAsync(this IHost host, string[] args)
        {
            CommandLineBuilder cli = host.Services.GetRequiredService<CommandLineBuilder>();
            foreach (Command cmd in host.Services.GetServices<Command>())
            {
                cli.AddCommand(cmd);
            }
            
            return cli.UseDefaults().Build().InvokeAsync(args);
        }
    }

}
