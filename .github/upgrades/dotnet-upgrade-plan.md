# .NET 10.0 Upgrade Plan

## Execution Steps

Execute steps below sequentially one by one in the order they are listed.

1. Validate that an .NET 10.0 SDK required for this upgrade is installed on the machine and if not, help to get it installed.
2. Ensure that the SDK version specified in global.json files is compatible with the .NET 10.0 upgrade.
3. Upgrade src\ArchiDesignPatterns.Mobile\ArchiDesignPatterns.Mobile.csproj

## Settings

This section contains settings and data used by execution steps.

### Excluded projects

| Project name                                   | Description                 |
|:-----------------------------------------------|:---------------------------:|

### Aggregate NuGet packages modifications across all projects

NuGet packages used across all selected projects or their dependencies that need version update in projects that reference them.

| Package Name                        | Current Version | New Version | Description                                   |
|:------------------------------------|:---------------:|:-----------:|:----------------------------------------------|
| Microsoft.Extensions.Configuration.UserSecrets |   6.0.1         |  10.0.0      | Recommended for .NET 10.0                     |
| Microsoft.Extensions.Http           |   9.0.0         |  10.0.0      | Recommended for .NET 10.0                     |
| Microsoft.Extensions.Logging.Debug  |   9.0.8         |  10.0.0      | Recommended for .NET 10.0                     |

### Project upgrade details

#### src\ArchiDesignPatterns.Mobile\ArchiDesignPatterns.Mobile.csproj modifications

Project properties changes:
  - Target framework should be changed from `net9.0-android` to `net10.0-android`

NuGet packages changes:
  - Microsoft.Extensions.Configuration.UserSecrets should be updated from `6.0.1` to `10.0.0`
  - Microsoft.Extensions.Http should be updated from `9.0.0` to `10.0.0`
  - Microsoft.Extensions.Logging.Debug should be updated from `9.0.8` to `10.0.0`

Feature upgrades:
  - None identified.

Other changes:
  - None identified.
