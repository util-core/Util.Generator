using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Util;
using Util.Generators;
using Util.Logging.Serilog;

//启动应用
Host.CreateDefaultBuilder( args )
    .ConfigureServices( services => services.AddHostedService<HostService>() )
    .AsBuild()
    .AddSerilog()
    .AddUtil()
    .Build()
    .Run();
