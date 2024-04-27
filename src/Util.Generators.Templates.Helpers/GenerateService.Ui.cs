using Util.Helpers;

namespace Util.Generators.Helpers;

/// <summary>
/// 生成服务 - Ui层相关方法
/// </summary>
public partial class GenerateService {

    #region IsMicrofrontend(是否微前端应用)

    /// <summary>
    /// 是否微前端应用
    /// </summary>
    public bool IsMicrofrontend() {
        return _context.ProjectContext.Client.Microfrontend;
    }

    #endregion

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
        if ( isAddSchema && IsSupportSchema() )
            return $"{GetUiProjectName()}/{module}/{Schema}";
        return $"{GetUiProjectName()}/{module}";
    }

    #endregion            

    #region GetClientRootPath(获取前端根路径)

    /// <summary>
    /// 获取前端根路径
    /// </summary>
    public string GetClientRootPath() {
        return $"src/{GetUiProjectName()}/ClientApp";
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
        if ( isAddSchema && IsSupportSchema() )
            return $"{projectName}.{module}.{Schema}";
        return $"{projectName}.{module}";
    }

    #endregion

    #region GetClientAppName(获取前端应用名称)

    /// <summary>
    /// 获取前端应用名称
    /// </summary>
    public string GetClientAppName() {
        var result = _context.ProjectContext.Client.AppName.Camelize();
        return result.IsEmpty() ? ProjectName.Camelize() : result;
    }

    #endregion

    #region GetUiPort(获取UI项目端口)

    /// <summary>
    /// 获取UI项目端口
    /// </summary>
    public string GetUiPort() {
        var result = _context.ProjectContext.UiPort;
        if ( result.IsEmpty() == false )
            return result;
        var clientPort = Convert.ToInt( GetClientPort() );
        if ( clientPort != 0 )
            return ( clientPort + 10000 ).ToString();
        var apiPort = Convert.ToInt( GetApiPort() );
        return ( apiPort - 10 ).ToString();
    }

    #endregion

    #region GetClientPort(获取前端应用端口)

    /// <summary>
    /// 获取前端应用端口
    /// </summary>
    public string GetClientPort() {
        return _context.ProjectContext.Client.Port;
    }

    #endregion

    #region GetClientModuleFileName(获取前端模块文件名)

    /// <summary>
    /// 获取前端模块文件名
    /// </summary>
    public string GetClientModuleFileName() {
        return $"{ClientAppName.Kebaberize()}.module";
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
        return $"{ClientAppName.Pascalize()}Module";
    }

    #endregion

    #region GetClientRoutingModuleFileName(获取前端路由模块文件名)

    /// <summary>
    /// 获取前端路由模块文件名
    /// </summary>
    public string GetClientRoutingModuleFileName() {
        return $"{ClientAppName.Kebaberize()}-routing.module";
    }

    #endregion

    #region GetClientRoutingModuleClassName(获取前端路由模块类名)

    /// <summary>
    /// 获取前端路由模块类名
    /// </summary>
    public string GetClientRoutingModuleClassName() {
        return $"{ClientAppName.Pascalize()}RoutingModule";
    }

    #endregion

    #region GetClientEntityFileName(获取前端实体文件名)

    /// <summary>
    /// 获取前端实体文件名
    /// </summary>
    /// <param name="entity">实体上下文</param>
    public string GetClientEntityFileName( EntityContext entity ) {
        return entity.Name.Kebaberize();
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
        return GetClientEntityName( _context );
    }

    /// <summary>
    /// 获取前端实体名
    /// </summary>
    public string GetClientEntityName( EntityContext entity ) {
        return entity.Name.Camelize();
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
        return $"{_context.Name.Pascalize()}ViewModel";
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

    #region GetClientListPartFileName(获取前端列表页查询分部视图文件名)

    /// <summary>
    /// 获取前端列表页查询分部视图文件名
    /// </summary>
    /// <param name="entity">实体上下文</param>
    public string GetClientListPartFileName( EntityContext entity ) {
        return $"{GetClientEntityFileName( entity )}-list-query";
    }

    /// <summary>
    /// 获取前端列表页查询分部视图文件名
    /// </summary>
    public string GetClientListPartFileName() {
        return GetClientListPartFileName( _context );
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
        return $"{_context.Name.Pascalize()}Query";
    }

    #endregion

    #region GetClientListClassName(获取前端列表组件类名)

    /// <summary>
    /// 获取前端列表组件类名
    /// </summary>
    /// <param name="entity">实体上下文</param>
    public string GetClientListClassName( EntityContext entity ) {
        return $"{entity.Name.Pascalize()}ListComponent";
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
        return $"{entity.Name.Pascalize()}EditComponent";
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
        return $"{entity.Name.Pascalize()}DetailComponent";
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

    #region GetClientSchemas(获取前端架构列表)

    /// <summary>
    /// 获取前端架构列表
    /// </summary>
    public List<string> GetClientSchemas() {
        var result = new List<string> { _context.ProjectContext.Client.AppName };
        if ( _context.ProjectContext.Schemas.Count > 0 )
            result = _context.ProjectContext.Schemas;
        return result.ToList();
    }

    #endregion

    #region GetTableKey(获取表格存储名称)

    /// <summary>
    /// 获取表格存储名称
    /// </summary>
    public string GetTableKey() {
        return GetTableKey( _context );
    }

    /// <summary>
    /// 获取表格存储名称
    /// </summary>
    public string GetTableKey( EntityContext entity ) {
        var prefix = _context.Schema.IsEmpty() ? _context.ProjectContext.Client.AppName : _context.Schema;
        return $"{FormatKebaberize( prefix )}_{FormatKebaberize( entity.Name )}";
    }

    /// <summary>
    /// 使用小写加下划线方式格式化名称
    /// </summary>
    private string FormatKebaberize( string name ) {
        return name.SafeString().Kebaberize().Replace( "-", "_" );
    }

    #endregion
}