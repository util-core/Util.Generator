using System.Linq;
using System.Text;
using Util.Generators.Contexts;

namespace Util.Generators.Helpers {
    /// <summary>
    /// 生成服务 - 领域层相关方法
    /// </summary>
    public partial class GenerateService {

        #region GetDomainProjectId(获取领域层项目标识)

        /// <summary>
        /// 获取领域层项目标识
        /// </summary>
        /// <param name="schema">架构</param>
        public string GetDomainProjectId( string schema ) {
            var key = $"domain.{schema}";
            return GetProjectId( key );
        }

        #endregion

        #region GetDomainProjectName(获取领域层项目名称)

        /// <summary>
        /// 获取领域层项目名称
        /// </summary>
        public string GetDomainProjectName() {
            return GetDomainProjectName( _context.Schema );
        }

        /// <summary>
        /// 获取领域层项目名称
        /// </summary>
        /// <param name="schema">架构</param>
        public string GetDomainProjectName( string schema ) {
            if( IsSupportSchema( schema ) )
                return $"{_context.ProjectContext.Name}.Domain.{GetSchema( schema )}";
            return $"{_context.ProjectContext.Name}.Domain";
        }

        #endregion

        #region GetDomainProjectPath(获取领域层项目路径)

        /// <summary>
        /// 获取领域层项目路径
        /// </summary>
        /// <param name="module">模块</param>
        public string GetDomainProjectPath( string module ) {
            return $"{GetDomainProjectName()}/{module}";
        }

        #endregion

        #region GetDomainNamespace(获取领域层命名空间)

        /// <summary>
        /// 获取领域层命名空间
        /// </summary>
        /// <param name="module">模块</param>
        public string GetDomainNamespace( string module ) {
            return $"{GetDomainProjectName()}.{module}";
        }

        #endregion

        #region GetAggregateRootAndInterfaces(获取聚合根和需要实现的接口)

        /// <summary>
        /// 获取聚合根和需要实现的接口
        /// </summary>
        public string GetAggregateRootAndInterfaces() {
            var result = new StringBuilder();
            result.Append( GetAggregateRoot() );
            result.Append( GetEntityInterfaces() );
            return result.ToString();
        }

        /// <summary>
        /// 获取聚合根
        /// </summary>
        private string GetAggregateRoot() {
            switch( _context.Key.SystemType ) {
                case SystemType.String:
                    return $"AggregateRoot<{EntityName},string>";
                case SystemType.Int:
                    return $"AggregateRoot<{EntityName},int>";
                case SystemType.Long:
                    return $"AggregateRoot<{EntityName},long>";
                default:
                    return $"AggregateRoot<{EntityName}>";
            }
        }

        /// <summary>
        /// 获取实体需要实现的接口
        /// </summary>
        private string GetEntityInterfaces() {
            var result = new StringBuilder();
            result.Append( GetIDelete() );
            result.Append( GetIAudited() );
            result.Append( GetIExtraProperties() );
            return result.ToString();
        }

        /// <summary>
        /// 获取逻辑删除接口
        /// </summary>
        protected string GetIDelete() {
            if( _context.Properties.Any( t => t.Name == "IsDeleted" ) )
                return ",IDelete";
            return string.Empty;
        }

        /// <summary>
        /// 获取审计接口
        /// </summary>
        protected string GetIAudited() {
            if( HasCreationAudited() && HasModificationAudited() )
                return GetIAuditedResult();
            if( HasCreationAudited() )
                return GetICreationAuditedResult();
            if( HasModificationAudited() )
                return GetIModificationAuditedResult();
            return string.Empty;
        }

        /// <summary>
        /// 是否存在创建审计
        /// </summary>
        protected bool HasCreationAudited() {
            return Exists( t => t.Name == "CreationTime" ) && Exists( t => t.Name == "CreatorId" );
        }

        /// <summary>
        /// 是否存在修改审计
        /// </summary>
        protected bool HasModificationAudited() {
            return Exists( t => t.Name == "LastModificationTime" ) && Exists( t => t.Name == "LastModifierId" );
        }

        /// <summary>
        /// 获取IAudited接口
        /// </summary>
        private string GetIAuditedResult() {
            var property = _context.Properties.Find( t => t.Name == "CreatorId" );
            if ( property == null )
                return null;
            if( property.SystemType == SystemType.Guid )
                return ",IAudited";
            return $",IAudited<{property.TypeName}>";
        }

        /// <summary>
        /// 获取ICreationAudited接口
        /// </summary>
        private string GetICreationAuditedResult() {
            var property = _context.Properties.Find( t => t.Name == "CreatorId" );
            if ( property == null )
                return null;
            if ( property.SystemType == SystemType.Guid )
                return ",ICreationAudited";
            return $",ICreationAudited<{property.TypeName}>";
        }

        /// <summary>
        /// 获取IModificationAudited接口
        /// </summary>
        private string GetIModificationAuditedResult() {
            var property = _context.Properties.Find( t => t.Name == "CreatorId" );
            if ( property == null )
                return null;
            if ( property.SystemType == SystemType.Guid )
                return ",IModificationAudited";
            return $",IModificationAudited<{property.TypeName}>";
        }

        /// <summary>
        /// 获取扩展属性接口
        /// </summary>
        protected string GetIExtraProperties() {
            if ( _context.Properties.Any( t => t.Name == "ExtraProperties" ) )
                return ",IExtraProperties";
            return string.Empty;
        }

        #endregion

        #region HasDataAnnotations(是否存在数据注解)

        /// <summary>
        /// 是否存在数据注解
        /// </summary>
        /// <param name="property">属性</param>
        public bool HasDataAnnotations( Property property ) {
            var result = GetDataAnnotations( property );
            return result.IsEmpty() == false;
        }

        #endregion

        #region GetDataAnnotations(获取数据注解)

        /// <summary>
        /// 获取数据注解
        /// </summary>
        /// <param name="property">属性</param>
        public string GetDataAnnotations( Property property ) {
            var result = new StringBuilder();
            AddRequired( result, property );
            AddMaxLength( result, property );
            return result.ToString();
        }

        /// <summary>
        /// 添加必填项验证
        /// </summary>
        private void AddRequired( StringBuilder result, Property property ) {
            if( property.IsRequired == false )
                return;
            if( property.IsBool )
                return;
            string message = GetRequiredMessage();
            if( message.IsEmpty() == false )
                message = string.Format( message, property.Description );
            result.Append( GetRequired( message ) );
        }

        /// <summary>
        /// 获取必填项验证特性
        /// </summary>
        private string GetRequired( string message ) {
            if ( message.IsEmpty() )
                return "        [Required]\r\n";
            return $"        [Required(ErrorMessage = \"{message}\")]\r\n";
        }

        /// <summary>
        /// 添加字符串最大长度验证
        /// </summary>
        private void AddMaxLength( StringBuilder result, Property property ) {
            if( property.SystemType != SystemType.String )
                return;
            if( property.MaxLength == null )
                return;
            if( property.MaxLength <= 0 )
                return;
            string dataAnnotation = $"        [MaxLength( {property.GetSafeMaxLength()} )]\r\n";
            result.Append( dataAnnotation );
        }

        #endregion

        #region GetIRepository(获取仓储接口)

        /// <summary>
        /// 获取仓储接口
        /// </summary>
        public string GetIRepository() {
            if ( _context.Key.SystemType == SystemType.Guid )
                return $"IRepository<{EntityName}>";
            return $"IRepository<{EntityName},{GetKeyType()}>";
        }

        #endregion

        #region GetRepositoryBase(获取仓储基类)

        /// <summary>
        /// 获取仓储基类
        /// </summary>
        public string GetRepositoryBase() {
            if( _context.Key.SystemType == SystemType.Guid )
                return $"RepositoryBase<{EntityName}>";
            return $"RepositoryBase<{EntityName},{GetKeyType()}>";
        }

        #endregion
    }
}
