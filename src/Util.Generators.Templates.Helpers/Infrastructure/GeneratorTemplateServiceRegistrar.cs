using System;
using Util.Generators.Templates;
using Util.Infrastructure;

namespace Util.Generators.Helpers.Infrastructure {
    /// <summary>
    /// 生成器模板服务注册器
    /// </summary>
    public class GeneratorTemplateServiceRegistrar : IServiceRegistrar {
        /// <summary>
        /// 获取服务名
        /// </summary>
        public static string ServiceName => "Util.Generators.Helpers.Infrastructure.GeneratorTemplateServiceRegistrar";

        /// <summary>
        /// 排序号
        /// </summary>
        public int OrderId => 10020;

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enabled => ServiceRegistrarConfig.IsEnabled( ServiceName );

        /// <summary>
        /// 注册服务
        /// </summary>
        /// <param name="serviceContext">服务上下文</param>
        public Action Register( ServiceContext serviceContext ) {
            AddFilters(serviceContext);
            return null;
        }

        /// <summary>
        /// 添加模板过滤器
        /// </summary>
        private void AddFilters( ServiceContext serviceContext ) {
            var filters = serviceContext.TypeFinder.Find<ITemplateFilter>();
            filters.ForEach( TemplateFilterManager.AddFilter );
        }
    }
}
