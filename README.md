# Quartz + Topshelf + Serilog

A simple example of using Quartz inside Topshelf with Serilog.

## Quickstart

```powershell
dotnet restore
dotnet build
dotnet build -c Release
cd bin/Release/net461
.\quartz-topshelf.exe install --autostart
```

Uninstall

```powershell
.\quartz-topshelf.exe uninstall
```

### Notes:

* Logs are saved to "%TEMP%/logs/myapp.txt"


### Original Project Creation

```powershell
dotnet new console --target-framework-override net461
dotnet add package Quartz
dotnet add package Serilog
dotnet add package Serilog.Sinks.Console
dotnet add package Serilog.Sinks.File
dotnet add package Topshelf
dotnet add package Topshelf.serilog
```
