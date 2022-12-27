using System;
using Util.Generators.Resources;
using Util.Infrastructure;

namespace Util.Generators.Infrastructure {
    /// <summary>
    /// 生成器NgZorro模板服务注册器
    /// </summary>
    public class NgZorroTemplateServiceRegistrar : IServiceRegistrar {
        /// <summary>
        /// 获取标识
        /// </summary>
        public static int GetId() => 10110;

        /// <summary>
        /// 标识
        /// </summary>
        public int Id => GetId();

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enabled => ServiceRegistrarConfig.Instance.IsEnabled( GetId() );

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
            ResourceManager.AddResource( @"src\Presentation\ClientApp\_mock", @"src\{Project}.Ui\ClientApp\_mock" );
            ResourceManager.AddResource( @"src\Presentation\ClientApp\src\app\routes\permission", @"src\{Project}.Ui\ClientApp\src\app\routes\permission" );
        }
    }
}
