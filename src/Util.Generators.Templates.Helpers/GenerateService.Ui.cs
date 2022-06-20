namespace Util.Generators.Helpers {
    /// <summary>
    /// 生成服务 - Ui层相关方法
    /// </summary>
    public partial class GenerateService {

        #region GetUiProjectId(获取Ui层项目标识)

        /// <summary>
        /// 获取Ui层项目标识
        /// </summary>
        public string GetUiProjectId() {
            return GetProjectId( "ui" );
        }

        #endregion        

        #region GetUiProjectName(获取Ui层项目名称)

        /// <summary>
        /// 获取Ui层项目名称
        /// </summary>
        public string GetUiProjectName() {
            return $"{_context.ProjectContext.Name}.Ui";
        }

        #endregion        

        #region GetUiProjectPath(获取Ui层项目路径)

        /// <summary>
        /// 获取Ui层项目路径
        /// </summary>
        /// <param name="module">模块</param>
        /// <param name="isAddSchema">是否添加架构</param>
        public string GetUiProjectPath( string module, bool isAddSchema = false ) {
            if( isAddSchema && IsSupportSchema() )
                return $"{GetUiProjectName()}/{module}/{Schema}";
            return $"{GetUiProjectName()}/{module}";
        }

        #endregion        

        #region GetUiNamespace(获取Ui层命名空间)

        /// <summary>
        /// 获取Ui层命名空间
        /// </summary>
        /// <param name="module">模块</param>
        /// <param name="isAddSchema">是否添加架构</param>
        public string GetUiNamespace( string module = null, bool isAddSchema = false ) {
            var projectName = $"{_context.ProjectContext.Name}";
            if ( module.IsEmpty() )
                return projectName;
            if( isAddSchema && IsSupportSchema() )
                return $"{projectName}.{module}.{Schema}";
            return $"{projectName}.{module}";
        }

        #endregion

        #region GetClientAppName(获取前端应用名称)

        /// <summary>
        /// 获取前端应用名称
        /// </summary>
        public string GetClientAppName() {
            var result = _context.ProjectContext.ClientAppName;
            return result.IsEmpty() ? ProjectName.ToLower() : result;
        }

        #endregion
    }
}
