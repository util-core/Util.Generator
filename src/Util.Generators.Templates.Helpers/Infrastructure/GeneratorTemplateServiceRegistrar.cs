using System;
using Microsoft.Extensions.Hosting;
using Util.Generators.Helpers.Filters;
using Util.Generators.Templates;
using Util.Infrastructure;
using Util.Reflections;

namespace Util.Generators.Helpers.Infrastructure {
    /// <summary>
    /// 生成器模板服务注册器
    /// </summary>
    public class GeneratorTemplateServiceRegistrar : IServiceRegistrar {
        /// <summary>
        /// 获取标识
        /// </summary>
        public static int GetId() => 10020;

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
            AddFilters();
            return null;
        }

        /// <summary>
        /// 添加模板过滤器
        /// </summary>
        private void AddFilters() {
            TemplateFilterManager.AddFilter( new DatabaseTemplateFilter() );
        }
    }
}
