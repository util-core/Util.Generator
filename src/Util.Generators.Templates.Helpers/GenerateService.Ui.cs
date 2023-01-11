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

        #region GetUiPagesPath(获取Ui层Pages页面路径)

        /// <summary>
        /// 获取Ui层Pages页面路径
        /// </summary>
        public string GetUiPagesPath() {
            return $"{GetUiProjectName()}/Pages/Routes/{ClientAppName.Pluralize().Pascalize()}/{EntityName}";
        }

        #endregion

        #region GetClientModulePath(获取前端模块路径)

        /// <summary>
        /// 获取前端模块路径
        /// </summary>
        public string GetClientModulePath() {
            return $"{GetUiProjectName()}/ClientApp/src/app/routes/{GetClientModuleFolderName()}";
        }

        #endregion

        #region GetClientComponentPath(获取前端组件路径)

        /// <summary>
        /// 获取前端组件路径
        /// </summary>
        public string GetClientComponentPath() {
            return $"{GetClientModulePath()}/{GetClientEntityFileName()}";
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
            var result = _context.ProjectContext.ClientAppName.Camelize();
            return result.IsEmpty() ? ProjectName.Camelize() : result;
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

        #region GetClientEntityFileName(获取前端实体文件名)

        /// <summary>
        /// 获取前端实体文件名
        /// </summary>
        /// <param name="entity">实体上下文</param>
        public string GetClientEntityFileName( EntityContext entity ) {
            return entity.Name.Singularize().Kebaberize();
        }

        /// <summary>
        /// 获取前端实体文件名
        /// </summary>
        public string GetClientEntityFileName() {
            return GetClientEntityFileName( _context );
        }

        #endregion

        #region GetClientEntityName(获取前端实体名)

        /// <summary>
        /// 获取前端实体名
        /// </summary>
        public string GetClientEntityName() {
            return _context.Name.Singularize().Camelize();
        }

        #endregion

        #region GetClientViewModelFileName(获取前端视图模型文件名)

        /// <summary>
        /// 获取前端视图模型文件名
        /// </summary>
        public string GetClientViewModelFileName() {
            return $"{GetClientEntityFileName()}-view-model";
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
            return $"{GetClientEntityFileName()}-query";
        }

        #endregion

        #region GetClientListFileName(获取前端列表页文件名)

        /// <summary>
        /// 获取前端列表页文件名
        /// </summary>
        /// <param name="entity">实体上下文</param>
        public string GetClientListFileName( EntityContext entity ) {
            return $"{GetClientEntityFileName( entity )}-list.component";
        }

        /// <summary>
        /// 获取前端列表页文件名
        /// </summary>
        public string GetClientListFileName() {
            return GetClientListFileName( _context );
        }

        #endregion

        #region GetClientEditFileName(获取前端编辑页文件名)

        /// <summary>
        /// 获取前端编辑页文件名
        /// </summary>
        /// <param name="entity">实体上下文</param>
        public string GetClientEditFileName( EntityContext entity ) {
            return $"{GetClientEntityFileName( entity )}-edit.component";
        }

        /// <summary>
        /// 获取前端编辑页文件名
        /// </summary>
        public string GetClientEditFileName() {
            return GetClientEditFileName( _context );
        }

        #endregion

        #region GetClientDetailFileName(获取前端详情页文件名)

        /// <summary>
        /// 获取前端详情页文件名
        /// </summary>
        /// <param name="entity">实体上下文</param>
        public string GetClientDetailFileName( EntityContext entity ) {
            return $"{GetClientEntityFileName( entity )}-detail.component";
        }

        /// <summary>
        /// 获取前端详情页文件名
        /// </summary>
        public string GetClientDetailFileName() {
            return GetClientDetailFileName( _context );
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

        #region GetClientListClassName(获取前端列表组件类名)

        /// <summary>
        /// 获取前端列表组件类名
        /// </summary>
        /// <param name="entity">实体上下文</param>
        public string GetClientListClassName( EntityContext entity ) {
            return $"{entity.Name.Singularize().Pascalize()}ListComponent";
        }

        /// <summary>
        /// 获取前端列表组件类名
        /// </summary>
        public string GetClientListClassName() {
            return GetClientListClassName( _context );
        }

        #endregion

        #region GetClientEditClassName(获取前端编辑组件类名)

        /// <summary>
        /// 获取前端编辑组件类名
        /// </summary>
        /// <param name="entity">实体上下文</param>
        public string GetClientEditClassName( EntityContext entity ) {
            return $"{entity.Name.Singularize().Pascalize()}EditComponent";
        }

        /// <summary>
        /// 获取前端编辑组件类名
        /// </summary>
        public string GetClientEditClassName() {
            return GetClientEditClassName( _context );
        }

        #endregion

        #region GetClientDetailClassName(获取前端详情组件类名)

        /// <summary>
        /// 获取前端详情组件类名
        /// </summary>
        /// <param name="entity">实体上下文</param>
        public string GetClientDetailClassName( EntityContext entity ) {
            return $"{entity.Name.Singularize().Pascalize()}DetailComponent";
        }

        /// <summary>
        /// 获取前端详情组件类名
        /// </summary>
        public string GetClientDetailClassName() {
            return GetClientDetailClassName( _context );
        }

        #endregion

        #region GetClientTableId(获取前端表格标识)

        /// <summary>
        /// 获取前端表格标识
        /// </summary>
        public string GetClientTableId() {
            return $"tb_{GetClientEntityName()}";
        }

        #endregion

        #region GetClientSort(获取前端排序属性)

        /// <summary>
        /// 获取前端排序属性
        /// </summary>
        public string GetClientSort() {
            if ( _context.HasSortId )
                return "sort=\"SortId\"";
            if ( _context.HasCreationTime )
                return "sort=\"CreationTime desc\"";
            return null;
        }

        #endregion

        #region GetClientViewTemplateUrl(获取前端视图模板地址)

        /// <summary>
        /// 获取前端视图模板地址
        /// </summary>
        public string GetClientViewTemplateUrl() {
            return $"/view/routes/{ClientAppName.Pluralize().Camelize()}/{GetClientEntityName()}";
        }

        #endregion

        #region GetClientRoutesName(获取前端路由变量名)

        /// <summary>
        /// 获取前端路由变量名
        /// </summary>
        public string GetClientRoutesName() {
            return $"{GetClientAppName()}Routes";
        }

        #endregion

        #region GetClientModuleRoutePath(获取前端模块路由路径)

        /// <summary>
        /// 获取前端模块路由路径
        /// </summary>
        public string GetClientModuleRoutePath() {
            return GetClientAppName().Kebaberize();
        }

        #endregion
    }
}
