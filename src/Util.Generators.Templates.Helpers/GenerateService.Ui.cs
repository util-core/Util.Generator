using Humanizer;
using Util.Generators.Contexts;

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

        #region GetClientAppTitleName(获取应用名称驼峰)

        /// <summary>
        /// 获取应用名称驼峰
        /// </summary>
        public string GetClientAppTitleName()
        {
            var result = _context.ProjectContext.ClientAppName;
            result = result.IsEmpty() ? ProjectName.ToLower() : result;
            return result.Pluralize().Titleize();
        }

        #endregion

        #region GetClientModuleFileName(获取前端模块文件名)

        /// <summary>
        /// 获取前端模块文件名
        /// </summary>
        public string GetClientModuleFileName() {
            return $"{ClientAppName.Singularize().Kebaberize()}.module";
        }

        #endregion

        #region GetClientModuleFolderName(获取前端模块目录名)

        /// <summary>
        /// 获取前端模块目录名
        /// </summary>
        public string GetClientModuleFolderName() {
            return $"{ClientAppName.Pluralize().Kebaberize()}";
        }

        #endregion

        #region GetClientModuleClassName(获取前端模块类名)

        /// <summary>
        /// 获取前端模块类名
        /// </summary>
        public string GetClientModuleClassName() {
            return $"{ClientAppName.Singularize().Pascalize()}Module";
        }

        #endregion

        #region GetClientRoutingModuleFileName(获取前端路由模块文件名)

        /// <summary>
        /// 获取前端路由模块文件名
        /// </summary>
        public string GetClientRoutingModuleFileName() {
            return $"{ClientAppName.Singularize().Kebaberize()}-routing.module";
        }

        #endregion

        #region GetClientRoutingModuleClassName(获取前端路由模块类名)

        /// <summary>
        /// 获取前端路由模块类名
        /// </summary>
        public string GetClientRoutingModuleClassName() {
            return $"{ClientAppName.Singularize().Pascalize()}RoutingModule";
        }

        #endregion

        #region GetClientEntityName(获取前端实体名)

        /// <summary>
        /// 获取前端实体名
        /// </summary>
        public string GetClientEntityName() {
            return _context.Name.Singularize().Kebaberize();
        }

        #endregion

        #region GetClientEntityName(获取前端实体名)

        /// <summary>
        /// 获取前端实体名
        /// </summary>
        public string GetClientEntityName(EntityContext entityContext)
        {
            return entityContext.Name.Singularize().Kebaberize();
        }

        #endregion

        #region GetClientViewModelFileName(获取前端视图模型文件名)

        /// <summary>
        /// 获取前端视图模型文件名
        /// </summary>
        public string GetClientViewModelFileName() {
            return $"{GetClientEntityName()}-view-model";
        }

        #endregion

        #region GetClientListFileName(获取前端视图列表页面)

        /// <summary>
        /// 获取前端视图列表页面
        /// </summary>
        public string GetClientListFileName()
        {
            return $"{GetClientEntityName()}-list.component";
        }

        #endregion

        #region GetClientEditFileName(获取前端视图编辑页面)

        /// <summary>
        /// 获取前端视图编辑页面
        /// </summary>
        public string GetClientEditFileName()
        {
            return $"{GetClientEntityName()}-edit.component";
        }

        #endregion

        #region GetClientDetailFileName(获取前端视图详情页面)

        /// <summary>
        /// 获取前端视图详情页面
        /// </summary>
        public string GetClientDetailFileName()
        {
            return $"{GetClientEntityName()}-detail.component";
        }

        #endregion

        #region GetClientViewModelClassName(获取前端视图模型类名)

        /// <summary>
        /// 获取前端视图模型类名
        /// </summary>
        public string GetClientViewModelClassName() {
            return $"{_context.Name.Singularize().Pascalize()}ViewModel";
        }

        #endregion

        #region GetClientQueryFileName(获取前端查询参数文件名)

        /// <summary>
        /// 获取前端查询参数文件名
        /// </summary>
        public string GetClientQueryFileName() {
            return $"{GetClientEntityName()}-query";
        }

        #endregion

        #region GetClientQueryClassName(获取前端查询参数类名)

        /// <summary>
        /// 获取前端查询参数类名
        /// </summary>
        public string GetClientQueryClassName() {
            return $"{_context.Name.Singularize().Pascalize()}Query";
        }

        #endregion
    }
}
