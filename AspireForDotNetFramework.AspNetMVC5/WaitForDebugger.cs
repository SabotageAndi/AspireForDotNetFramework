using System;
using System.Diagnostics;
using System.Threading;

namespace AspireForDotNetFramework.AspNetMVC5
{
    public class WaitForDebugger
    {
        public static void WaitIfNeeded()
        {
            var waitForDebuggerEnvVariable =
                Environment.GetEnvironmentVariable("AspireForDotNetFramework_WaitForDebugger");

            var currentProcess = Process.GetCurrentProcess();

            if (waitForDebuggerEnvVariable != null)
            {
                if (waitForDebuggerEnvVariable == "1")
                {
                    while (true)
                    {
                        Console.WriteLine($"Waiting for Debugger to be attached to process {currentProcess.ProcessName}/{currentProcess.Id}");
                        Thread.Sleep(TimeSpan.FromSeconds(5));

                        if (Debugger.IsAttached)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}