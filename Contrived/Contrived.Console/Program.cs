using System;
using System.Threading;
using Contrived.Data.Services;
using StackExchange.Profiling;

namespace Contrived.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var profiler = MiniProfiler.StartNew("Contrived Console Main");

            using (profiler.Step("Doing Stuff"))
            {
                System.Console.Write("Hello ");
                var program = new Program();
                program.Run();
                System.Console.WriteLine("World!");
            }

            profiler.Stop();
            System.Console.WriteLine(profiler.RenderPlainText());
        }

        public void Run()
        {
            var count = new MathService().RandomNumbo();
            Thread.Sleep(500);
        }
    }
}