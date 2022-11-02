using System;
using Util.Generators.Helpers.Filters;
using Util.Generators.Templates;
using Util.Infrastructure;

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
        /// <param name="serviceContext">服务上下文</param>
        public Action Register( ServiceContext serviceContext ) {
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
