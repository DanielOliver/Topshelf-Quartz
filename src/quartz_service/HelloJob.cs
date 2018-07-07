using System;
using System.Timers;
using Quartz;
using System.Collections.Specialized;
using Quartz.Impl;
using System.Threading.Tasks;
using Serilog;

namespace quartz_service
{
    public class HelloJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            var lastRun = context.PreviousFireTimeUtc?.DateTime.ToString() ?? string.Empty;
            Log.Warning("Greetings from HelloJob!   Previous run: {lastRun}", lastRun);
            return Task.CompletedTask;
        }
    }
}