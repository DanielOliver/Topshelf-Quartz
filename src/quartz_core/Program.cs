using Serilog;
using System;
using System.Runtime.Loader;
using quartz_service;

namespace quartz_core
{
    class Program
    {
        private static ScheduleService _service;

        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.File($"logs/myapp.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            _service = new ScheduleService();
            _service.Start();
            
            AssemblyLoadContext.Default.Unloading += SigTermEventHandler;
            Console.CancelKeyPress += CancelHandler;

            while (true) {
                System.Console.ReadKey();                
            };
        }

        private static void SigTermEventHandler(AssemblyLoadContext obj)
        {
            Log.Information("Unloading...");
            _service.Stop();
        }

        private static void CancelHandler(object sender, ConsoleCancelEventArgs e)
        {	     
            Log.Information("Exiting...");
            _service.Stop();
        }
    }
}
