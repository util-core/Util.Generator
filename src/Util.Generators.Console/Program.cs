using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Util;
using Util.Generators;
using Util.Generators.Helpers.Logs;
using Util.Logging.Serilog;

//启动应用
Host.CreateDefaultBuilder( args )
    .ConfigureServices( services => {
        services.AddHostedService<HostService>();
        services.AddLogging( builder => {
            builder.AddConsole( options => options.FormatterName = "default" )
                .AddConsoleFormatter<LogFormatter,SimpleConsoleFormatterOptions>();
        } );
    } )
    .AsBuild()
    .AddSerilog()
    .AddUtil()
    .Build()
    .Run();
