# ✨ namechk-cli [dotnet-namechk]

.NET Core global CLI tool to check for the availability of NuGet package names

## Install

The `dotnet-namechk` nuget package is [published to nuget.org](https://www.nuget.org/packages/dotnet-namechk/)

You can get the tool by running this command

`$ dotnet tool install -g dotnet-namechk`

## Usage

    Usage: namecheck [options]
    Usage: namecheck [names...]

    Options:
        -h   Display help
        -v   Display version

    names:
        list of names to check for the availability

    Ex:
        namecheck miniature-fiesta reimagined-engine scaling-adventure

        miniature-fiesta is available
        reimagined-engine is unavailable
        scaling-adventure is unavailable
