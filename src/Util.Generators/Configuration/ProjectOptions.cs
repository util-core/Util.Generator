using Util.Data;

namespace Util.Generators.Configuration {
    /// <summary>
    /// 项目配置项
    /// </summary>
    public class ProjectOptions {
        /// <summary>
        /// 项目名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 数据库类型
        /// </summary>
        public DatabaseType DbType { get; set; }
        /// <summary>
        /// 目标数据库类型
        /// </summary>
        public DatabaseType? TargetDbType { get; set; }
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string ConnectionString { get; set; }
        /// <summary>
        /// 工作单元名称
        /// </summary>
        public string UnitOfWorkName { get; set; }
        /// <summary>
        /// 前端应用名称
        /// </summary>
        public string ClientAppName { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enabled { get; set; }
        /// <summary>
        /// 是否使用Utc
        /// </summary>
        public bool Utc { get; set; }
    }
}
