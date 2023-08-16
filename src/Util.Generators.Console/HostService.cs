using Microsoft.Extensions.Hosting;

namespace Util.Generators; 

/// <summary>
/// 主机服务
/// </summary>
public class HostService : IHostedService {
    /// <summary>
    /// 代码生成器
    /// </summary>
    private readonly IGenerator _generator;

    /// <summary>
    /// 初始化主机服务
    /// </summary>
    /// <param name="generator">代码生成器</param>
    public HostService( IGenerator generator ) {
        _generator = generator;
    }

    /// <summary>
    /// 启动服务
    /// </summary>
    public async Task StartAsync( CancellationToken cancellationToken ) {
        var version = await Util.Generators.Helpers.Version.GetVersionAsync();
        var message = $"============================ 欢迎使用 Util应用框架 代码生成器 {version} =================================";
        try {
            Console.WriteLine( Figgle.FiggleFonts.Standard.Render( "Util Generator" ) );
            Console.WriteLine( message );
            Console.WriteLine( "" );
            Console.WriteLine( "" );
            await _generator.GenerateAsync();
            Console.WriteLine( message );
        }
        finally {
            System.Console.ReadLine();
        }
    }

    /// <summary>
    /// 停止服务
    /// </summary>
    public Task StopAsync( CancellationToken cancellationToken ) {
        return Task.CompletedTask;
    }
}