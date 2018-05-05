using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using StackExchange.Profiling;

namespace Contrived.Data.Services
{
    public class MathService
    {
        public int RandomNumbo()
        {
            using (MiniProfiler.Current.Step("Random Number"))
            {
                Thread.Sleep(1000);
                var randomizer = new Random();
                return randomizer.Next(10);
            }
        }
    }
}
