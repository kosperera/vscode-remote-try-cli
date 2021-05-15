using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace HelloWorld.Cli.Commands
{
    public class Echo : Command
    {
        private readonly ILogger<Echo> logger;

        public Echo(ILogger<Echo> log) : base(name: "echo", "$ hwld echo -m 'Something' -t 20")
        {
            logger = log;
            Initialize();
        }

        private void Initialize()
        {
            AddOption(new Option<string>(new[] { "--message", "-m" })
            {
                Name = "message",
                Description = "message to echo",
                IsRequired = true,
            });
            AddOption(new Option<int>(new[] { "--times", "-t" })
            {
                Name = "times",
                Description = "how many times to echo",
                IsRequired = false,
            });

            Handler = CommandHandler.Create<EchoOptions>(ExecuteAsync);
        }

        private async Task<int> ExecuteAsync(EchoOptions options)
        {
            int times = options.Times;
            string message = options.Message;

            using (logger.BeginScope("Operator: {operator}, Length: {times}", nameof(ExecuteAsync), times))
            {
                logger.LogInformation("Starting to {message} {times} time ...", message, times);
                for (int i = 0; i < times; i++)
                {
                    await Task.Delay(1400);
                    logger.LogInformation("{message} for the {times} time ...", message, i + 1);
                }
            }

            return await Task.FromResult<int>(0);
        }
    }
}