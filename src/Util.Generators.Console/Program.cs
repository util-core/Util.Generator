using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Util.Generators {
    /// <summary>
    /// 生成器
    /// </summary>
    class Program {
        /// <summary>
        /// 入口程序
        /// </summary>
        static void Main( string[] args ) {
            Host.CreateDefaultBuilder( args )
                .ConfigureServices( services => services.AddHostedService<HostService>() )
                .AddUtil()
                .Build()
                .Run();
        }
    }
}
