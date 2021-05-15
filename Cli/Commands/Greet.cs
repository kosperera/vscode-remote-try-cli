using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace HelloWorld.Cli.Commands
{
    public class Greet : Command
    {
        private readonly ILogger<Greet> logger;

        public Greet(ILogger<Greet> log) : base(name: "greet", "$ hwld greet --name 'John Doe'")
        {
            logger = log;
            Initialize();
        }

        private void Initialize()
        {
            AddOption(new Option<string>(new[] { "--name", "-n" })
            {
                Name = "name",
                Description = "name of the person to greet",
                IsRequired = true
            });

            Handler = CommandHandler.Create<GreetOptions>(ExecuteAsync);
        }

        private async Task<int> ExecuteAsync(GreetOptions options)
        {
            string nameOrDefault = options.Name ?? "World";

            using (logger.BeginScope("Operator: {operator}, Name: {name}", nameof(ExecuteAsync), nameOrDefault))
            {
                logger.LogInformation("Hello {name}!", nameOrDefault);
            }

            return await Task.FromResult<int>(0);
        }
    }
}