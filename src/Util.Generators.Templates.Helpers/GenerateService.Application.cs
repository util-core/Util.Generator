namespace Util.Generators.Helpers {
    /// <summary>
    /// 生成服务 - 应用层相关方法
    /// </summary>
    public partial class GenerateService {

        #region GetApplicationProjectId(获取应用层项目标识)

        /// <summary>
        /// 获取应用层项目标识
        /// </summary>
        public string GetApplicationProjectId() {
            return GetProjectId( "application" );
        }

        #endregion

        #region GetWebApiProjectId(获取应用层WebApi项目标识)

        /// <summary>
        /// 获取应用层WebApi项目标识
        /// </summary>
        public string GetWebApiProjectId() {
            return GetProjectId( "application.api" );
        }

        #endregion

        #region GetApplicationProjectName(获取应用层项目名称)

        /// <summary>
        /// 获取应用层项目名称
        /// </summary>
        public string GetApplicationProjectName() {
            return $"{_context.ProjectContext.Name}.Application";
        }

        #endregion

        #region GetWebApiProjectName(获取应用层WebApi项目名称)

        /// <summary>
        /// 获取应用层WebApi项目名称
        /// </summary>
        public string GetWebApiProjectName() {
            return $"{_context.ProjectContext.Name}.Api";
        }

        #endregion

        #region GetApplicationProjectPath(获取应用层项目路径)

        /// <summary>
        /// 获取应用层项目路径
        /// </summary>
        /// <param name="module">模块</param>
        /// <param name="isAddSchema">是否添加架构</param>
        public string GetApplicationProjectPath( string module, bool isAddSchema = false ) {
            if( isAddSchema && IsSupportSchema() )
                return $"{GetApplicationProjectName()}/{module}/{Schema}";
            return $"{GetApplicationProjectName()}/{module}";
        }

        #endregion

        #region GetWebApiProjectPath(获取应用层WebApi项目路径)

        /// <summary>
        /// 获取应用层WebApi项目路径
        /// </summary>
        /// <param name="module">模块</param>
        /// <param name="isAddSchema">是否添加架构</param>
        public string GetWebApiProjectPath( string module, bool isAddSchema = false ) {
            if( isAddSchema && IsSupportSchema() )
                return $"{GetWebApiProjectName()}/{module}/{Schema}";
            return $"{GetWebApiProjectName()}/{module}";
        }

        #endregion

        #region GetApplicationNamespace(获取应用层命名空间)

        /// <summary>
        /// 获取应用层命名空间
        /// </summary>
        /// <param name="module">模块</param>
        /// <param name="isAddSchema">是否添加架构</param>
        public string GetApplicationNamespace( string module = null, bool isAddSchema = false ) {
            var projectName = $"{_context.ProjectContext.Name}.Applications";
            if ( module.IsEmpty() )
                return projectName;
            if( isAddSchema && IsSupportSchema() )
                return $"{projectName}.{module}.{Schema}";
            return $"{projectName}.{module}";
        }

        #endregion

        #region GetWebApiNamespace(获取应用层WebApi命名空间)

        /// <summary>
        /// 获取应用层WebApi命名空间
        /// </summary>
        /// <param name="module">模块</param>
        /// <param name="isAddSchema">是否添加架构</param>
        public string GetWebApiNamespace( string module = null, bool isAddSchema = false ) {
            var projectName = $"{_context.ProjectContext.Name}";
            if( module.IsEmpty() )
                return projectName;
            if( isAddSchema && IsSupportSchema() )
                return $"{projectName}.{module}.{Schema}";
            return $"{projectName}.{module}";
        }

        #endregion

        #region GetDto(获取数据传输对象)

        /// <summary>
        /// 获取数据传输对象
        /// </summary>
        public string GetDto() {
            return $"{EntityName}Dto";
        }

        #endregion

        #region GetDtos(获取数据传输对象列表)

        /// <summary>
        /// 获取数据传输对象列表
        /// </summary>
        public string GetDtos() {
            return $"{EntityName}Dtos";
        }

        #endregion

        #region GetQuery(获取查询对象)

        /// <summary>
        /// 获取查询对象
        /// </summary>
        public string GetQuery() {
            return $"{EntityName}Query";
        }

        #endregion

        #region GetIApplicationService(获取应用服务接口)

        /// <summary>
        /// 获取应用服务接口
        /// </summary>
        public string GetIApplicationService() {
            return $"I{EntityName}Service";
        }

        #endregion

        #region GetApplicationService(获取应用服务)

        /// <summary>
        /// 获取应用服务
        /// </summary>
        public string GetApplicationService() {
            return $"{EntityName}Service";
        }

        #endregion

        #region GetCrudServiceBase(获取Crud服务基类)

        /// <summary>
        /// 获取Crud服务基类
        /// </summary>
        public string GetCrudServiceBase() {
            if( _context.Key.SystemType == SystemType.Guid )
                return $"CrudServiceBase<{EntityName},{EntityName}Dto,{EntityName}Query>";
            return $"CrudServiceBase<{EntityName},{EntityName}Dto,{EntityName}Query,{GetKeyType()}>";
        }

        #endregion
    }
}
