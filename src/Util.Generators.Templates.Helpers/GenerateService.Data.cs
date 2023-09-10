using System;

namespace Util.Generators.Helpers; 

/// <summary>
/// 生成服务 - 数据访问层相关方法
/// </summary>
public partial class GenerateService {

    #region GetDataProjectId(获取数据访问层项目标识)

    /// <summary>
    /// 获取数据访问层项目标识
    /// </summary>
    public string GetDataProjectId() {
        return GetProjectId( "data" );
    }

    /// <summary>
    /// 获取数据访问层项目标识
    /// </summary>
    /// <param name="database">数据库类型</param>
    public string GetDataProjectId( DatabaseType database ) {
        return GetProjectId( $"data.{database}" );
    }

    #endregion

    #region GetDataProjectName(获取数据访问层项目名称)

    /// <summary>
    /// 获取数据访问层项目名称
    /// </summary>
    /// <param name="database">数据库类型</param>
    public string GetDataProjectName( DatabaseType? database = null ) {
        if( database == null )
            return $"{_context.ProjectContext.Name}.Data";
        return $"{_context.ProjectContext.Name}.Data.{database}";
    }

    #endregion

    #region GetDataProjectPath(获取数据访问层项目路径)

    /// <summary>
    /// 获取数据访问层项目路径
    /// </summary>
    /// <param name="module">模块</param>
    /// <param name="isAddSchema">是否添加架构</param>
    public string GetDataProjectPath( string module, bool isAddSchema = false ) {
        return GetDataProjectPath( null, module, isAddSchema );
    }

    /// <summary>
    /// 获取数据访问层项目路径
    /// </summary>
    /// <param name="database">数据库类型</param>
    /// <param name="module">模块</param>
    /// <param name="isAddSchema">是否添加架构</param>
    public string GetDataProjectPath( DatabaseType? database,string module, bool isAddSchema = false ) {
        if( isAddSchema && IsSupportSchema() )
            return $"{GetDataProjectName( database )}/{module}/{Schema}";
        return $"{GetDataProjectName( database )}/{module}";
    }

    #endregion

    #region GetIUnitOfWork(获取工作单元接口名称)

    /// <summary>
    /// 获取工作单元接口名称
    /// </summary>
    public string GetIUnitOfWork() {
        return $"I{GetUnitOfWork()}";
    }

    #endregion

    #region GetUnitOfWork(获取工作单元实现类名称)

    /// <summary>
    /// 获取工作单元实现类名称
    /// </summary>
    public string GetUnitOfWork() {
        var result = _context.ProjectContext.UnitOfWorkName;
        if ( result.IsEmpty() == false )
            return result;
        return $"{GetSafeProjectName()}UnitOfWork";
    }

    /// <summary>
    /// 获取安全项目名称,如果项目名称包含.,则取最后一个.后面的内容
    /// </summary>
    private string GetSafeProjectName() {
        var name = ProjectName.RemoveEnd( "." );
        var lastIndex = name.LastIndexOf( ".", StringComparison.OrdinalIgnoreCase );
        return lastIndex > 0 ? name.Substring( lastIndex + 1, name.Length - lastIndex -1 ) : name;
    }

    #endregion

    #region GetDesignTimeDbContextFactory(获取设计时数据上下文工厂)

    /// <summary>
    /// 获取设计时数据上下文工厂
    /// </summary>
    public string GetDesignTimeDbContextFactory() {
        return $"{GetSafeProjectName().Singularize()}DesignTimeDbContextFactory";
    }

    #endregion

    #region GetDataNamespace(获取数据访问层命名空间)

    /// <summary>
    /// 获取数据访问层命名空间
    /// </summary>
    public string GetDataNamespace() {
        return GetDataNamespace( null );
    }

    /// <summary>
    /// 获取数据访问层命名空间
    /// </summary>
    /// <param name="module">模块</param>
    /// <param name="isAddSchema">是否添加架构</param>
    public string GetDataNamespace( string module, bool isAddSchema = false ) {
        return GetDataNamespaceImpl( null, module, isAddSchema );
    }

    /// <summary>
    /// 获取数据访问层命名空间
    /// </summary>
    /// <param name="database">数据库类型</param>
    /// <param name="isAddSchema">是否添加架构</param>
    public string GetDataNamespace( DatabaseType database, bool isAddSchema = false ) {
        return GetDataNamespace( database, null, isAddSchema );
    }

    /// <summary>
    /// 获取数据访问层命名空间
    /// </summary>
    /// <param name="database">数据库类型</param>
    /// <param name="module">模块</param>
    /// <param name="isAddSchema">是否添加架构</param>
    public string GetDataNamespace( DatabaseType database, string module,bool isAddSchema = false ) {
        return GetDataNamespaceImpl( database, module, isAddSchema );
    }

    /// <summary>
    /// 获取数据访问层命名空间
    /// </summary>
    /// <param name="database">数据库类型</param>
    /// <param name="module">模块</param>
    /// <param name="isAddSchema">是否添加架构</param>
    private string GetDataNamespaceImpl( DatabaseType? database, string module, bool isAddSchema ) {
        string result;
        if( module.IsEmpty() )
            result = GetDataProjectName( database );
        else
            result = $"{GetDataProjectName( database )}.{module}";
        if( isAddSchema && IsSupportSchema() )
            result += $".{Schema}";
        return result;
    }

    #endregion

    #region GetQueryNamespaces(获取查询参数命名空间集合)

    /// <summary>
    /// 获取查询参数命名空间集合
    /// </summary>
    public List<string> GetQueryNamespaces() {
        var result = new List<string>();
        var queryNamespace = $"{_context.ProjectContext.Name}.Data.Queries";
        if ( IsSupportSchema() == false ) {
            result.Add( queryNamespace );
            return result;
        }
        foreach ( var schema in GetSchemas() ) {
            result.Add( $"{queryNamespace}.{schema}" );
        }
        return result;
    }

    #endregion

    #region GetIdConfiguration(获取实体类型标识配置)

    /// <summary>
    /// 获取实体类型标识配置
    /// </summary>
    public string GetIdConfiguration() {
        var builder = new PropertyConfigurationBuilder( _context.Key );
        return builder.Property( "Id" )
            .Line( 3 ).HasColumnName()
            .Line( 3 ).HasComment()
            .Line( 3,_context.Key.SystemType == SystemType.String ).HasMaxLength()
            .Line( 3, _context.Key.IsInteger && _context.Key.IsAutoIncrement ).IsAutoIncrement()
            .Semicolon()
            .Build();
    }

    #endregion

    #region GetVersionConfiguration(获取实体类型版本配置)

    /// <summary>
    /// 获取实体类型版本配置
    /// </summary>
    /// <param name="type">数据库类型</param>
    public string GetVersionConfiguration( DatabaseType type ) {
        if( _context.Version == null )
            return null;
        var builder = new PropertyConfigurationBuilder( _context.Version );
        return builder
            .Property()
            .Line( 4 ).HasColumnName()
            .Line( 4 ).Version( type )
            .Line( 4 ).HasComment()
            .Semicolon()
            .Build();
    }

    #endregion

    #region GetConfiguration(获取实体类型属性配置)

    /// <summary>
    /// 获取实体类型属性配置
    /// </summary>
    public string GetConfiguration( Property property,DatabaseType? dbType = null ) {
        var builder = new PropertyConfigurationBuilder( property );
        return builder
            .Indent( 2 ).Property()
            .Line(3).HasColumnName()
            .Line( 3 ).HasComment()
            .Line( 3, property.IsFloat && property.Precision > 0 ).HasPrecision()
            .Line( 3, IsPgSqlDate(property,dbType) ).HasColumnTypeIf( "timestamp", IsPgSqlDate( property, dbType ) )
            .Semicolon()
            .Line()
            .Build();
    }

    /// <summary>
    /// 是否pgsql非utc日期
    /// </summary>
    private bool IsPgSqlDate( Property property, DatabaseType? dbType ) {
        return property.IsDateTime && dbType == DatabaseType.PgSql && Utc() == false;
    }

    #endregion

    #region AddUnitOfWork(配置工作单元)

    /// <summary>
    /// 配置工作单元
    /// </summary>
    public string AddUnitOfWork() {
        return $"Add{_context.ProjectContext.TargetDbType}UnitOfWork";
    }

    #endregion

    #region GetBeginPropertyName(获取起始属性名)

    /// <summary>
    /// 获取起始属性名
    /// </summary>
    /// <param name="property">属性</param>
    public string GetBeginPropertyName( Property property ) {
        return $"Begin{property.Name.Pascalize()}";
    }

    #endregion

    #region GetEndPropertyName(获取结束属性名)

    /// <summary>
    /// 获取结束属性名
    /// </summary>
    /// <param name="property">属性</param>
    public string GetEndPropertyName( Property property ) {
        return $"End{property.Name.Pascalize()}";
    }

    #endregion
}