using Util.Infrastructure;

namespace Util.Generators.Razor.Infrastructure {
    /// <summary>
    /// Razor生成服务注册器配置扩展
    /// </summary>
    public static class ServiceRegistrarConfigExtensions {
        /// <summary>
        /// 启用Razor生成服务注册器
        /// </summary>
        /// <param name="config">服务注册器配置</param>
        public static ServiceRegistrarConfig EnableRazorGeneratorServiceRegistrar( this ServiceRegistrarConfig config ) {
            config.Enable( RazorGeneratorServiceRegistrar.GetId() );
            return config;
        }

        /// <summary>
        ///禁用Razor生成服务注册器
        /// </summary>
        /// <param name="config">服务注册器配置</param>
        public static ServiceRegistrarConfig DisableRazorGeneratorServiceRegistrar( this ServiceRegistrarConfig config ) {
            config.Disable( RazorGeneratorServiceRegistrar.GetId() );
            return config;
        }
    }
}
