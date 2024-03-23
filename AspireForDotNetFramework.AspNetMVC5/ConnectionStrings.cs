using System;
using System.Collections;
using System.Linq;

namespace AspireForDotNetFramework.AspNetMVC5
{
    public class ConnectionStrings
    {
        public static string Get(string name)
        {
            var connectionEnvironmentName = Environment.GetEnvironmentVariable("ConnectionStrings__" + name);

            if (string.IsNullOrEmpty(connectionEnvironmentName))
            {
                throw new Exception($"Connectionstring {name} not found");
            }

            return connectionEnvironmentName;
        }
    }
}