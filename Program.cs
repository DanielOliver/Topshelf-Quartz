using System;
using System.Timers;
using Serilog;
using Topshelf;
using System.IO;

namespace quartz_topshelf
{
    public class Program
    {
        public static void Main()
        {
            var rc = HostFactory.Run(x =>
            {
                x.Service<ScheduleService>(s =>
                {
                    s.ConstructUsing(name => new ScheduleService());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();

                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Information()
                    .WriteTo.Console()
                    .WriteTo.File($"{Path.GetTempPath()}logs\\myapp.txt", rollingInterval: RollingInterval.Day)
                    .CreateLogger();
                x.UseSerilog(Log.Logger);

                x.SetDescription("Sample Topshelf Host");
                x.SetDisplayName("Stuff");
                x.SetServiceName("Stuff");
            });

            var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());
            Environment.ExitCode = exitCode;
        }
    }
}
