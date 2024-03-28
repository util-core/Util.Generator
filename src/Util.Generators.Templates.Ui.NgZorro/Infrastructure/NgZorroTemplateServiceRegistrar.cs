using System;
using Util.Generators.Resources;
using Util.Infrastructure;

namespace Util.Generators.Infrastructure {
    /// <summary>
    /// 生成器NgZorro模板服务注册器
    /// </summary>
    public class NgZorroTemplateServiceRegistrar : IServiceRegistrar {
        /// <summary>
        /// 获取服务名
        /// </summary>
        public static string ServiceName => "Util.Generators.Infrastructure.NgZorroTemplateServiceRegistrar";

        /// <summary>
        /// 排序号
        /// </summary>
        public int OrderId => 10110;

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enabled => ServiceRegistrarConfig.IsEnabled( ServiceName );

        /// <summary>
        /// 注册服务
        /// </summary>
        /// <param name="serviceContext">服务上下文</param>
        public Action Register( ServiceContext serviceContext ) {
            AddResources();
            return null;
        }

        /// <summary>
        /// 添加静态资源
        /// </summary>
        private void AddResources() {
            ResourceManager.AddResource( @"src\Presentation\ClientApp\src\assets", @"src\{Project}.Ui\ClientApp\src\assets" );
            ResourceManager.AddResource( @"src\Presentation\ClientApp\src\favicon.ico", @"src\{Project}.Ui\ClientApp\src\favicon.ico" );
            ResourceManager.AddResource( @"src\Presentation\ClientApp\src\favicon.ico", @"src\{Project}.Ui\wwwroot\favicon.ico" );
            ResourceManager.AddResource( @"src\Presentation\ClientApp\src\app\routes\dashboard", @"src\{Project}.Ui\ClientApp\src\app\routes\dashboard" );
            ResourceManager.AddResource( @"src\Presentation\ClientApp\src\app\routes\exception", @"src\{Project}.Ui\ClientApp\src\app\routes\exception" );
            ResourceManager.AddResource( @"src\Presentation\ClientApp\src\app\layout", @"src\{Project}.Ui\ClientApp\src\app\layout" );
        }
    }
}
