using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace hotchocolate_issue_1120
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel(options =>
                    options.Limits.MaxRequestBodySize = null
                )
                // the following makes the built-in log-stack pass everything to NLog
                .ConfigureLogging(builder => builder.SetMinimumLevel(LogLevel.Trace))
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .UseUrls("http://*:5000")
                .Build();
            host.Run();
        }
    }
}
