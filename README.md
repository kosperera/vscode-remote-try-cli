# Try out CLI-based console app (C#)

This repository demonstrates developing a CLI-based hello world console app with .NET 5.0 using VS  Code and Development Containers.

With Temninal:
```zsh
#!/bin/zsh
# Greet someone
hwld greet -n "Angry Haslett"
# > Hello Angry Haslett!
```
```zsh
#!/bin/zsh
# Say something to echo
hwld echo -m "Sad Lamarr" -t 2
# > Starting to Sad Lamarr 2 times ...
# > Sad Lamarr for the 1 time ...
# > Sad Lamarr for the 2 time ...
```

### What's included:
- Uses .NET 5.0 development container found in [@kosalanuwan/devcontainers][devcontainers-repo]
- Uses [Microsoft.Extensions.Hosting][ms-hosting-ext-repo] package for [Generic Hosting][generic-hosting-docs] and Dependency Injection
- Uses [System.CommandLine][command-line-api-repo] package for CLI options, args, and commands
- Configured to [build and run][vscode-tasks] from the VS Code tasks

## Quick Start
If you want to understand how development containers work or want to build your own development container, you want to have a look at [the dev container page][ms-devcontainers-create-docs] for full-blown instructions.

### Build and run from source
First, you want to fork or clone the repo locally, then open up the source code in VS Code.

```zsh
#!/bin/zsh
gh repo clone kosalanuwan/vscode-remote-try-cli
cd vscode-remote-try-cli && code .
```
Then, re-open the source in the development container to install minimal runtime tools, plugins, extensions et al.

With VS  Code:
- Run task: `Reopen in Container`
- Run task: `build` to clean, restore, and build the project
- Run task: `watch` to run project in watch mode

```zsh
#!/bin/zsh
# Greet someone
dotnet watch --project Cli/HelloWorld.Cli.csproj run greet -n "Angry Haslett"
# Say something to echo
dotnet watch --project Cli/HelloWorld.Cli.csproj run echo -m "Sad Lamarr" -t 2
```

## Useful Commands
Occasionally, you will want to repeat below steps to create a console project, add dependencies, and write your own CLI tool.

With VS Code:
```zsh
#!/bin/zsh
# Create a new console project
dotnet new console -n Weather.Cli -o Cli
```
```zsh
#!/bin/zsh
# Create a new solution to add the project
dotnet new sln -n Cli
dotnet sln add Cli/
```
```zsh
#!/bin/zsh
# Add useful dependencies
dotnet add Cli/ package Microsoft.Extensions.Hosting  --prerelease
dotnet add Cli/ package System.CommandLine --prerelease
```

## Related Projects
- [@dotnet/command-line-api][command-line-api-repo] for implemnting commands and args
- [A flavor of Carmel Eve's DI approach][carmeleve-cli-demo-repo] using the [Genric Host][generic-hosting-docs].

## Feedback
If you have any technical problems with VS Code or Development Containers, you are better off [asking VS Code Support directly][vscode-support], since you'll end up getting a much faster response back that way.

## Contributing
The official repo to contribute would be [@microsoft/vscode-dev-containers][ms-devcontainers-repo].

Have a suggestion or a bug fix? Just open a pull request or an issue. Include the development container with a clear folder name and the simplest instructions possible.

## License
The source code is license under the [MIT][lic]

[devcontainers-repo]: https://github.com/kosalanuwan/devcontainers/#readme
[ms-hosting-ext-repo]: https://github.com/dotnet/runtime/tree/master/src/libraries/Microsoft.Extensions.Hosting/src
[generic-hosting-docs]: https://docs.microsoft.com/en-us/dotnet/core/extensions/generic-host
[command-line-api-repo]: https://github.com/dotnet/command-line-api
[vscode-tasks]: .vscode/tasks.json
[ms-devcontainers-create-docs]: https://code.visualstudio.com/docs/remote/create-dev-container

[carmeleve-cli-demo-repo]: https://github.com/carmeleve/SystemCommandLine.Demo/blob/master/SystemCommandLine.Demo/Program.cs

[vscode-support]: https://github.com/microsoft/vscode-dev-containers#contributing-and-feedback
[ms-devcontainers-repo]: https://github.com/microsoft/vscode-dev-containers#readme

[lic]: LICENSE
