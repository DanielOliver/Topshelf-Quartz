using System;
using System.Timers;
using Topshelf;
using Quartz;
using System.Collections.Specialized;
using Quartz.Impl;
using System.Threading.Tasks;

namespace quartz_topshelf
{
    public class HelloJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            return Console.Out.WriteLineAsync($"Greetings from HelloJob!   Previous run: {context.PreviousFireTimeUtc?.DateTime.ToString() ?? string.Empty}");
        }
    }
}