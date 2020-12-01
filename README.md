# Try out CLI (.NET)

This repository is serves as an example of Develop in .NET 5.0+, includes minimal required set up to get started. In case you were wondering, this `.devcontainer` is:

- Based on `dotnetcore` development container found in [@microsoft/vscode-dev-containers][devcontainers-repo]
- Ideal for [.NET 5.0+][dotnet-sdk-docker-image] with .NET Core, .NET Core CLI, and ASP.NET Core, and
- Includes with [Azure CLI][azure-cli-docs] and [Node][node-js-docs]

## Useful Commands

```bash
# Create a CLI project
dotnet new console -n Weather.Cli -o Cli
# Add a Solution file
dotnet new sln -n Cli
dotnet sln add Cli/
```

```bash
# Add useful dependencies
dotnet add Cli/ package Microsoft.Extensions.Hosting  --prerelease
dotnet add Cli/ package System.CommandLine --prerelease
```

## Build and Run
```bash
# Greet someone
dotnet run -p Cli/ greet -n "Angry Haslett"
# > Hello Angry Haslett!

# Say something to echo
dotnet run -p Cli/ echo -m "Sad Lamarr" -t 2
# > Starting to Sad lamarr 2 time ...
# > Sad lamarr for the 1 time ...
# > Sad lamarr for the 2 time ...
```

- [The VS Code Remote - Containers docs][vscode-remote-docs] is a good source to learn more about `.devcontainer.json` configuration options and its usage.
- [See .NET Core CLI page][dotnet-core-cli-docs] to learn the full-blown `dotnet` options.

[devcontainers-repo]: https://github.com/microsoft/vscode-dev-containers
[dotnet-sdk-docker-image]: https://hub.docker.com/_/microsoft-dotnet-sdk/
[azure-cli-docs]: https://docs.microsoft.com/en-us/cli/azure/get-started-with-azure-cli
[node-js-docs]: https://nodejs.dev/learn
[vscode-remote-docs]: https://code.visualstudio.com/docs/remote/containers
[dotnet-core-cli-docs]: https://docs.microsoft.com/en-us/dotnet/core/tools/
