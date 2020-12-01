namespace HelloWorld.Cli.Commands
{
    using System;
    using System.CommandLine;
    using System.CommandLine.Builder;
    using System.CommandLine.Parsing;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    internal static class DependencyExtensions
    {
        public static IServiceCollection AddCommandLineBuilder(this IServiceCollection services) => services.AddSingleton<CommandLineBuilder>(new CommandLineBuilder());

        public static IServiceCollection AddCommandsFromAssembly(this IServiceCollection services, Assembly assembly)
        {
            Type openType = typeof(Command);

            assembly.GetExportedTypes()
                    .Where((type) => !type.IsAbstract && !type.IsGenericTypeDefinition && type.BaseType == openType && openType.IsAssignableFrom(type))
                    .ToList()
                    .ForEach((type) => services.AddTransient(openType, type));

            return services;
        }

        public static async Task<int> RunConsoleAsync(this IHost host, string[] args)
        {
            CommandLineBuilder cli = host.Services.GetRequiredService<CommandLineBuilder>();
            foreach (Command cmd in host.Services.GetServices<Command>())
            {
                cli.AddCommand(cmd);
            }

            return await cli.UseDefaults().Build().InvokeAsync(args);
        }
    }
}