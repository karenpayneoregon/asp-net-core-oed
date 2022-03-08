using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace Basic1
{
    /// <summary>
    /// https://medium.com/@therealjordanlee/securing-web-applications-with-mtls-asp-net-core-2-x-e93660b6b9ea
    /// https://www.ryadel.com/en/asp-net-client-server-cannot-comunicate-because-they-possess-common-algorithm-how-to-fix-c-sharp/
    /// https://docs.microsoft.com/en-us/windows-server/security/tls/tls-registry-settings
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        // https://docs.microsoft.com/en-us/mem/configmgr/core/plan-design/security/enable-tls-1-2
        // https://docs.microsoft.com/en-us/dotnet/core/compatibility/aspnet-core/5.0/kestrel-default-supported-tls-protocol-versions-changed
        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)

        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseKestrel(kestrelOptions =>
        //            {
        //                kestrelOptions.ConfigureHttpsDefaults(httpsOptions =>
        //                {
        //                    httpsOptions.SslProtocols =  SslProtocols.Tls13;
        //                });
        //            });

        //            webBuilder.UseStartup<Startup>();
        //        });
    }
}
