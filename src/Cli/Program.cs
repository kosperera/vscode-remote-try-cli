using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;

namespace Weather.Cli
{
    class Program
    {
        static int Main(string[] args)
        {
            Console.WriteLine("Using CommandLine");

            RootCommand rootCmd = new RootCommand
            {
                new Option<int>
                (
                    "--int-option", getDefaultValue: () => 42, description: "An option whose argument is parsed as an int"
                ),
                new Option<bool>
                (
                    "--bool-option", "An option whose argument is parsed as a bool"
                ),
                new Option<FileInfo>
                (
                    "--file-option", "An option whose argument is parsed as a FileInfo"
                )
            };
            rootCmd.Description = "Weather CLI";
            // NOTE: The parameters of the handler method are matched according to the names of the options.
            rootCmd.Handler = CommandHandler.Create<int, bool, FileInfo>
            (
                (intOption, boolOption, fileOption) => 
                {
                    Console.WriteLine($"The value for --int-option is: {intOption}");
                    Console.WriteLine($"The value for --bool-option is: {boolOption}");
                    Console.WriteLine($"The value for --file-option is: {fileOption?.FullName ?? "null"}");
                }
            );

            // HINT: Parse the incoming args and invoke the handler.
            return rootCmd.InvokeAsync(args).Result;
        }
    }
}
