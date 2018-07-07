# Quartz + Topshelf + Serilog

A simple example of using Quartz inside Topshelf with Serilog.

## Quickstart Windows

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

### Notes

* Logs are saved to "%TEMP%/logs/myapp.txt"

## Quickstart Linux

```powershell
vagrant up
vagrant plugin install vagrant-vbguest
vagrant reload
vagrant ssh
```
