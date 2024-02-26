using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspire.Hosting;

namespace AspireForDotNetFramework.AppHost
{
    public static class BuilderExtensions
    {
        public static void AddAspNetMVC<T>(this IDistributedApplicationBuilder builder, string name) where T : Aspire.Hosting.IProjectMetadata, new()
        {
            var projectMetadata = new T();

            var projectDirectory = Path.GetDirectoryName(projectMetadata.ProjectPath);

            var projectName = Path.GetFileNameWithoutExtension(projectMetadata.ProjectPath);

            var iisExpressPath = Path.Combine(Environment.GetEnvironmentVariable("ProgramFiles(x86)"), "IIS Express", "iisexpress.exe");


            var vsDirectory = FindVsDirectory(projectDirectory);

            builder.AddExecutable(name, iisExpressPath, projectDirectory, new[] { $"/config:{Path.Combine(vsDirectory, "AspireForDotNetFramework", "config","applicationhost.config")}", $"/site:{projectName}" });
        }

        private static string FindVsDirectory(string directory)
        {
            var currentVsDirectoryPath = Path.Combine(directory, ".vs");

            if (Directory.Exists(currentVsDirectoryPath))
            {
                var applicationHostConfigPath = Path.Combine(currentVsDirectoryPath, "AspireForDotNetFramework", "config", "applicationhost.config");

                if (File.Exists(applicationHostConfigPath))
                {
                    return currentVsDirectoryPath;
                }
            }

            var parentDirectory = Path.GetDirectoryName(directory);

            return FindVsDirectory(parentDirectory);
        }
    }
}
