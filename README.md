# Try out Comman-Line Applications (C#)

This repository demonstrates developing a CLI-based console app with .NET 5.0 using developer containers.

### What's included:
- Uses .NET 5.0 developer container found in @kosalanuwan/devcontainer
- Uses `Hosting` extension for dependency injection
- Uses `CommandLine` for CLI options, args, and commands
- Configured to build and run from the VS Code tasks

## Quick Start
If you want to understand how devcontainers work or want to build your own devcontainer, you want to have a look at the dev container page for full-blown instructions.

### Build and run from source
First, you want to clone the repo locally, then open up the source code in remote container.

```bash
gh repo clone kosalanuwan/vscode-remote-try-cli
cd vscode-remote-try-cli && code .
```

With VS  Code:

```bash
# Greet someone
dotnet run -p Cli/ greet -n "Angry Haslett"
# > Hello Angry Haslett!
```
```bash
# Say something to echo
dotnet run -p Cli/ echo -m "Sad Lamarr" -t 2
# > Starting to Sad lamarr 2 time ...
# > Sad lamarr for the 1 time ...
# > Sad lamarr for the 2 time ...
```

## Useful Commands
Occationally, you will want to repeat the steps to create a console project, add dependencies, and write your own CLI tool.

With VS Code:

```bash
# Create a new console project
dotnet new console -n Weather.Cli -o Cli
```
```bash
# Create a new solution to add the project
dotnet new sln -n Cli
dotnet sln add Cli/
```
```bash
# Add useful dependencies
dotnet add Cli/ package Microsoft.Extensions.Hosting  --prerelease
dotnet add Cli/ package System.CommandLine --prerelease
```

## Feedback

## Related Projects

## License

[devcontainers-repo]: https://github.com/microsoft/vscode-dev-containers
[dotnet-sdk-docker-image]: https://hub.docker.com/_/microsoft-dotnet-sdk/
[azure-cli-docs]: https://docs.microsoft.com/en-us/cli/azure/get-started-with-azure-cli
[node-js-docs]: https://nodejs.dev/learn
[vscode-remote-docs]: https://code.visualstudio.com/docs/remote/containers
[dotnet-core-cli-docs]: https://docs.microsoft.com/en-us/dotnet/core/tools/
