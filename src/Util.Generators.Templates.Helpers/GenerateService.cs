using System;
using System.Collections.Generic;
using System.Linq;
using Humanizer;
using Util.Data;
using Util.Generators.Contexts;
using Util.Generators.Properties;

namespace Util.Generators.Helpers {
    /// <summary>
    /// 生成服务
    /// </summary>
    public partial class GenerateService {

        #region 字段

        /// <summary>
        /// 实体上下文
        /// </summary>
        private readonly EntityContext _context;
        /// <summary>
        /// 项目标识字典
        /// </summary>
        private readonly Dictionary<string, string> _projectIds = new();

        #endregion

        #region 构造方法

        /// <summary>
        /// 初始化生成服务
        /// </summary>
        /// <param name="context">实体上下文</param>
        public GenerateService( EntityContext context ) {
            _context = context ?? throw new ArgumentNullException( nameof( context ) );
        }

        #endregion

        #region 属性

        /// <summary>
        /// 实体名称
        /// </summary>
        public string EntityName => _context.PascalName;
        /// <summary>
        /// 实体描述
        /// </summary>
        public string EntityDescription => _context.Description;
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName => _context.ProjectName;
        /// <summary>
        /// 架构
        /// </summary>
        public string Schema => GetSchema(_context.Schema );
        /// <summary>
        /// 前端应用名称
        /// </summary>
        public string ClientAppName => _context.ProjectContext.ClientAppName;
        /// <summary>
        /// Util框架版本号
        /// </summary>
        public string UtilVersion => Version.Util;

        #endregion

        #region 辅助方法

        /// <summary>
        /// 获取项目标识
        /// </summary>
        /// <param name="key">键</param>
        private string GetProjectId( string key ) {
            if( _projectIds.ContainsKey( key ) == false )
                _projectIds.Add( key, Guid.NewGuid().ToString().ToUpperInvariant() );
            return _projectIds[key];
        }

        /// <summary>
        /// 是否存在指定属性
        /// </summary>
        /// <param name="condition">条件</param>
        public bool Exists( Func<Property,bool> condition ) {
            return _context.Properties.Any( condition );
        }

        #endregion

        #region IsSupportSchema(是否支持架构)

        /// <summary>
        /// 是否支持架构
        /// </summary>
        public bool IsSupportSchema() {
            return IsSupportSchema( _context.Schema );
        }

        /// <summary>
        /// 是否支持架构
        /// </summary>
        public bool IsSupportSchema( string schema ) {
            if( schema.IsEmpty() )
                return false;
            if( schema == "dbo" )
                return false;
            return true;
        }

        #endregion

        #region GetSchema(获取架构)

        /// <summary>
        /// 获取架构
        /// </summary>
        /// <param name="schema">架构名</param>
        public string GetSchema( string schema ) {
            return schema.Pluralize().Pascalize();
        }

        #endregion

        #region GetSchemas(获取架构列表)

        /// <summary>
        /// 获取架构列表
        /// </summary>
        public List<string> GetSchemas() {
            if( _context.ProjectContext.Schemas.Count == 0 )
                return new List<string> { "dbo" };
            return _context.ProjectContext.Schemas;
        }

        #endregion

        #region GetEntities(获取实体上下文列表)

        /// <summary>
        /// 获取实体上下文列表
        /// </summary>
        public List<EntityContext> GetEntities() {
            return _context.ProjectContext.Entities.Where( t => t.IsRelationTable == false ).ToList();
        }

        /// <summary>
        /// 获取实体上下文列表
        /// </summary>
        /// <param name="schema">架构名称</param>
        public List<EntityContext> GetEntities( string schema ) {
            return GetEntities().Where( t => t.Schema == schema ).ToList();
        }

        #endregion

        #region GetKeyDefault(获取标识属性默认值)

        /// <summary>
        /// 获取标识属性默认值
        /// </summary>
        public string GetKeyDefault() {
            switch( _context.Key.SystemType ) {
                case SystemType.String:
                    return "string.Empty";
                case SystemType.Guid:
                    return "Guid.Empty";
                default:
                    return "0";
            }
        }

        #endregion

        #region GetKeyType(获取标识类型)

        /// <summary>
        /// 获取标识类型
        /// </summary>
        public string GetKeyType() {
            return _context.Key.TypeName;
        }

        #endregion

        #region GetRequiredMessage(获取必填项消息)

        /// <summary>
        /// 获取必填项消息
        /// </summary>
        public string GetRequiredMessage() {
            return _context.ProjectContext.GeneratorContext.Message.RequiredMessage ?? GeneratorResource.RequiredMessage;
        }

        #endregion

        #region Utc(是否使用Utc)

        /// <summary>
        /// 是否使用Utc
        /// </summary>
        public bool Utc() {
            return _context.ProjectContext.Utc;
        }

        #endregion

        #region GetCurrentDbType(获取当前数据库类型)

        /// <summary>
        /// 获取当前数据库类型
        /// </summary>
        public DatabaseType GetCurrentDbType() {
            return _context.ProjectContext.TargetDbType;
        }

        #endregion
    }
}
