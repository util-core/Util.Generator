using Util.Infrastructure;

namespace Util.Generators.Helpers.Infrastructure {
    /// <summary>
    /// 生成器模板服务注册器配置扩展
    /// </summary>
    public static class ServiceRegistrarConfigExtensions {
        /// <summary>
        /// 启用生成器模板服务注册器
        /// </summary>
        /// <param name="config">服务注册器配置</param>
        public static ServiceRegistrarConfig EnableGeneratorTemplateServiceRegistrar( this ServiceRegistrarConfig config ) {
            config.Enable( GeneratorTemplateServiceRegistrar.GetId() );
            return config;
        }

        /// <summary>
        ///禁用生成器模板服务注册器
        /// </summary>
        /// <param name="config">服务注册器配置</param>
        public static ServiceRegistrarConfig DisableGeneratorTemplateServiceRegistrar( this ServiceRegistrarConfig config ) {
            config.Disable( GeneratorTemplateServiceRegistrar.GetId() );
            return config;
        }
    }
}
