using System;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Util.Generators.Configuration;
using Util.Generators.Contexts;
using Util.Generators.Resources;
using Util.Generators.Templates;
using Util.Infrastructure;
using Util.Reflections;

namespace Util.Generators.Razor.Infrastructure {
    /// <summary>
    /// Razor生成服务注册器
    /// </summary>
    public class RazorGeneratorServiceRegistrar : IServiceRegistrar {
        /// <summary>
        /// 获取标识
        /// </summary>
        public static int GetId() => 10010;

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
        /// <param name="hostBuilder">主机生成器</param>
        /// <param name="finder">类型查找器</param>
        public Action Register( IHostBuilder hostBuilder, ITypeFinder finder ) {
            hostBuilder.ConfigureServices( ( context, services ) => {
                services.TryAddSingleton<IGenerator, Generators.Generator>();
                services.TryAddSingleton<IGeneratorContextBuilder, GeneratorContextBuilder>();
                services.TryAddSingleton<IGeneratorOptionsBuilder, GeneratorOptionsBuilder>();
                services.TryAddSingleton<ITemplateFinder, RazorTemplateFinder>();
                services.TryAddSingleton<ITemplateFilterManager, TemplateFilterManager>();
                services.TryAddSingleton<IResourceManager, ResourceManager>();
            } );
            AddFilters();
            return null;
        }

        /// <summary>
        /// 添加模板过滤器
        /// </summary>
        private void AddFilters() {
            TemplateFilterManager.AddFilter( new PartTemplateFilter() );
        }
    }
}
