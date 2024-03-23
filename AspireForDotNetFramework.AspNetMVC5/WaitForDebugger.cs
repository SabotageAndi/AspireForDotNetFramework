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

            if (waitForDebuggerEnvVariable != null)
            {
                if (waitForDebuggerEnvVariable == "1")
                {
                    while (true)
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(10));

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