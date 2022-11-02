using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Util;
using Util.Generators;
using Util.Logging.Serilog;

//启动应用
Host.CreateDefaultBuilder( args )
    .ConfigureServices( services => services.AddHostedService<HostService>() )
    .AddUtil( options => options.UseSerilog() )
    .Build()
    .Run();
