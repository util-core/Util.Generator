namespace Util.Generators.Helpers;

/// <summary>
/// 生成服务 - 测试相关方法
/// </summary>
public partial class GenerateService {

    #region GetDomainTestProjectId(获取领域层测试项目标识)

    /// <summary>
    /// 获取领域层测试项目标识
    /// </summary>
    public string GetDomainTestProjectId() {
        var key = "domain.test";
        return GetProjectId( key );
    }

    #endregion

    #region GetDataTestProjectId(获取数据访问层测试项目标识)

    /// <summary>
    /// 获取数据访问层测试项目标识
    /// </summary>
    /// <param name="database">数据库类型</param>
    public string GetDataTestProjectId( DatabaseType database ) {
        var key = $"data.{database}.test";
        return GetProjectId( key );
    }

    #endregion

    #region GetApplicationTestProjectId(获取应用层测试项目标识)

    /// <summary>
    /// 获取应用层测试项目标识
    /// </summary>
    public string GetApplicationTestProjectId() {
        var key = "application.test";
        return GetProjectId( key );
    }

    #endregion

    #region GetWebApiTestProjectId(获取应用层Web Api测试项目标识)

    /// <summary>
    /// 获取应用层Web Api测试项目标识
    /// </summary>
    public string GetWebApiTestProjectId() {
        var key = "api.test";
        return GetProjectId( key );
    }

    #endregion

    #region GetDomainTestProjectName(获取领域层测试项目名称)

    /// <summary>
    /// 获取领域层测试项目名称
    /// </summary>
    public string GetDomainTestProjectName() {
        return $"{_context.ProjectContext.Name}.Domain.Tests";
    }

    #endregion

    #region GetDataTestProjectName(获取数据访问层测试项目名称)

    /// <summary>
    /// 获取数据访问层测试项目名称
    /// </summary>
    /// <param name="database">数据库类型</param>
    public string GetDataTestProjectName( DatabaseType database ) {
        return $"{GetDataProjectName( database )}.Tests";
    }

    #endregion

    #region GetApplicationTestProjectName(获取应用层测试项目名称)

    /// <summary>
    /// 获取应用层测试项目名称
    /// </summary>
    public string GetApplicationTestProjectName() {
        return $"{GetApplicationProjectName()}.Tests";
    }

    #endregion

    #region GetWebApiTestProjectName(获取应用层Web Api测试项目名称)

    /// <summary>
    /// 获取应用层Web Api测试项目名称
    /// </summary>
    public string GetWebApiTestProjectName() {
        return $"{GetWebApiProjectName()}.Tests";
    }

    #endregion

    #region GetDomainTestProjectPath(获取领域层测试项目路径)

    /// <summary>
    /// 获取领域层测试项目路径
    /// </summary>
    /// <param name="module">模块</param>
    /// <param name="isAddSchema">是否添加架构</param>
    public string GetDomainTestProjectPath( string module, bool isAddSchema = true ) {
        if ( isAddSchema && IsSupportSchema() )
            return $"{GetDomainTestProjectName()}/{module}/{Schema}";
        return $"{GetDomainTestProjectName()}/{module}";
    }

    #endregion

    #region GetDataTestProjectPath(获取数据访问层测试项目路径)

    /// <summary>
    /// 获取数据访问层测试项目路径
    /// </summary>
    /// <param name="database">数据库类型</param>
    /// <param name="isAddSchema">是否添加架构</param>
    public string GetDataTestProjectPath( DatabaseType database, bool isAddSchema = false ) {
        if ( isAddSchema && IsSupportSchema() )
            return $"{GetDataTestProjectName( database )}/{Schema}";
        return GetDataTestProjectName( database );
    }

    /// <summary>
    /// 获取数据访问层测试项目路径
    /// </summary>
    /// <param name="database">数据库类型</param>
    /// <param name="module">模块</param>
    /// <param name="isAddSchema">是否添加架构</param>
    public string GetDataTestProjectPath( DatabaseType database, string module, bool isAddSchema = false ) {
        if ( isAddSchema && IsSupportSchema() )
            return $"{GetDataTestProjectName( database )}/{module}/{Schema}";
        return $"{GetDataTestProjectName( database )}/{module}";
    }

    #endregion

    #region GetApplicationTestProjectPath(获取应用层测试项目路径)

    /// <summary>
    /// 获取应用层测试项目路径
    /// </summary>
    /// <param name="module">模块</param>
    /// <param name="isAddSchema">是否添加架构</param>
    public string GetApplicationTestProjectPath( string module, bool isAddSchema = false ) {
        if ( isAddSchema && IsSupportSchema() )
            return $"{GetApplicationTestProjectName()}/{module}/{Schema}";
        return $"{GetApplicationTestProjectName()}/{module}";
    }

    #endregion

    #region GetWebApiTestProjectPath(获取应用层Web Api测试项目路径)

    /// <summary>
    /// 获取应用层Web Api测试项目路径
    /// </summary>
    /// <param name="module">模块</param>
    /// <param name="isAddSchema">是否添加架构</param>
    public string GetWebApiTestProjectPath( string module, bool isAddSchema = false ) {
        if ( isAddSchema && IsSupportSchema() )
            return $"{GetWebApiTestProjectName()}/{module}/{Schema}";
        return $"{GetWebApiTestProjectName()}/{module}";
    }

    #endregion

    #region GetDomainTestNamespace(获取领域层测试项目命名空间)

    /// <summary>
    /// 获取领域层测试项目命名空间
    /// </summary>
    /// <param name="module">模块</param>
    /// <param name="isAddSchema">是否添加架构</param>
    public string GetDomainTestNamespace( string module, bool isAddSchema = true ) {
        if ( isAddSchema && IsSupportSchema() )
            return $"{GetDomainTestProjectName()}.{module}.{Schema}";
        return $"{GetDomainTestProjectName()}.{module}";
    }

    #endregion

    #region GetDataTestNamespace(获取数据访问层测试项目命名空间)

    /// <summary>
    /// 获取数据访问层测试项目命名空间
    /// </summary>
    /// <param name="database">数据库类型</param>
    /// <param name="isAddSchema">是否添加架构</param>
    public string GetDataTestNamespace( DatabaseType database, bool isAddSchema = false ) {
        if ( isAddSchema && IsSupportSchema() )
            return $"{GetDataTestProjectName( database )}.{Schema}";
        return GetDataTestProjectName( database );
    }

    /// <summary>
    /// 获取数据访问层测试项目命名空间
    /// </summary>
    /// <param name="database">数据库类型</param>
    /// <param name="module">模块</param>
    /// <param name="isAddSchema">是否添加架构</param>
    public string GetDataTestNamespace( DatabaseType database, string module, bool isAddSchema = false ) {
        if ( isAddSchema && IsSupportSchema() )
            return $"{GetDataTestProjectName( database )}.{module}.{Schema}";
        return $"{GetDataTestProjectName( database )}.{module}";
    }

    #endregion

    #region GetApplicationTestNamespace(获取应用层测试项目命名空间)

    /// <summary>
    /// 获取应用层测试项目命名空间
    /// </summary>
    public string GetApplicationTestNamespace() {
        return $"{_context.ProjectContext.Name}.Applications.Tests";
    }

    /// <summary>
    /// 获取应用层测试项目命名空间
    /// </summary>
    /// <param name="module">模块</param>
    /// <param name="isAddSchema">是否添加架构</param>
    public string GetApplicationTestNamespace( string module, bool isAddSchema = false ) {
        if ( isAddSchema && IsSupportSchema() )
            return $"{GetApplicationTestNamespace()}.{module}.{Schema}";
        return $"{GetApplicationTestNamespace()}.{module}";
    }

    #endregion

    #region GetWebApiTestNamespace(获取应用层Web Api测试项目命名空间)

    /// <summary>
    /// 获取应用层Web Api测试项目命名空间
    /// </summary>
    public string GetWebApiTestNamespace() {
        return $"{_context.ProjectContext.Name}.Tests";
    }

    /// <summary>
    /// 获取应用层Web Api测试项目命名空间
    /// </summary>
    /// <param name="module">模块</param>
    /// <param name="isAddSchema">是否添加架构</param>
    public string GetWebApiTestNamespace( string module, bool isAddSchema = false ) {
        if ( isAddSchema && IsSupportSchema() )
            return $"{GetWebApiTestNamespace()}.{module}.{Schema}";
        return $"{GetWebApiTestNamespace()}.{module}";
    }

    #endregion

    #region GetDtoFakeService(获取数据传输对象模拟数据服务)

    /// <summary>
    /// 获取数据传输对象模拟数据服务
    /// </summary>
    public string GetDtoFakeService() {
        return $"{GetDto()}FakeService";
        ;
    }

    #endregion

    #region GetApiTestConnection(获取Web Api测试项目连接字符串)

    /// <summary>
    /// 获取Web Api测试项目连接字符串
    /// </summary>
    public string GetApiTestConnection() {
        if ( _context.ProjectContext.TargetDbType == DatabaseType.Sqlite )
            return GetApiTestSqliteConnection();
        if ( IsGenerateConnection() == false )
            return null;
        return _context.ProjectContext.ConnectionString.Replace( Generator, ".Api.Test" ).Replace( "\\", "\\\\" );
    }

    /// <summary>
    /// 获取Web Api测试项目Sqlite数据库连接字符串
    /// </summary>
    private string GetApiTestSqliteConnection() {
        return $"Data Source={GetWebApiTestProjectName()}.db";
    }

    #endregion

    #region GetApplicationTestConnection(获取应用层测试项目连接字符串)

    /// <summary>
    /// 获取应用层测试项目连接字符串
    /// </summary>
    public string GetApplicationTestConnection() {
        if ( _context.ProjectContext.TargetDbType == DatabaseType.Sqlite )
            return GetApplicationTestSqliteConnection();
        if ( IsGenerateConnection() == false )
            return null;
        return _context.ProjectContext.ConnectionString.Replace( Generator, ".Application.Test" ).Replace( "\\", "\\\\" );
    }

    /// <summary>
    /// 获取应用层测试项目Sqlite数据库连接字符串
    /// </summary>
    private string GetApplicationTestSqliteConnection() {
        return $"Data Source={GetApplicationTestProjectName()}.db";
    }

    #endregion

    #region GetDataTestConnection(获取数据访问层测试项目连接字符串)

    /// <summary>
    /// 获取数据访问层测试项目连接字符串
    /// </summary>
    public string GetDataTestConnection() {
        if ( _context.ProjectContext.TargetDbType == DatabaseType.Sqlite )
            return GetDataTestSqliteConnection();
        if ( IsGenerateConnection() == false )
            return null;
        return _context.ProjectContext.ConnectionString.Replace( Generator, ".Data.Test" ).Replace( "\\", "\\\\" );
    }

    /// <summary>
    /// 获取数据访问层测试项目Sqlite数据库连接字符串
    /// </summary>
    private string GetDataTestSqliteConnection() {
        return $"Data Source={GetDataTestProjectName( DatabaseType.Sqlite )}.db";
    }

    #endregion
}