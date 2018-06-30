using System;
using System.Timers;
using Topshelf;
using Quartz;
using System.Collections.Specialized;
using Quartz.Impl;
using System.Threading.Tasks;
using Serilog;

namespace quartz_topshelf
{
    public class HelloJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            var nextRun = context.PreviousFireTimeUtc?.DateTime.ToString() ?? string.Empty;
            Log.Warning("Greetings from HelloJob!   Previous run: {nextRun}", nextRun);
            return Task.CompletedTask;
        }
    }
}