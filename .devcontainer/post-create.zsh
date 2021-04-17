#!/bin/zsh

# If there's a Solution file, then run `dotnet restore`
# It's assumed that the Solution file has all the projects added.
if [ -f .sln ]; then
    dotnet restore && .devcontainer/mssql/postCreateCommand.sh 'P@ssw0rd' './bin/Debug/' './.devcontainer/mssql/'
else
    .devcontainer/mssql/postCreateCommand.sh 'P@ssw0rd' './bin/Debug/' './.devcontainer/mssql/'
fi