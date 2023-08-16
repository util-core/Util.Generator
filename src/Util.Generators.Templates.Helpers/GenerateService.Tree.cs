namespace Util.Generators.Helpers; 

/// <summary>
/// 生成服务 - 树形相关方法
/// </summary>
public partial class GenerateService {

    #region IsTreeEntity(是否树形实体)

    /// <summary>
    /// 是否树形实体
    /// </summary>
    public bool IsTreeEntity() {
        return _context.Properties.Exists( t => t.Name == "ParentId" )
               && _context.Properties.Exists( t => t.Name == "Path" )
               && _context.Properties.Exists( t => t.Name == "Level" );
    }

    #endregion

    #region GetTreeEntityAndInterfaces(获取树形实体和需要实现的接口)

    /// <summary>
    /// 获取树形实体和需要实现的接口
    /// </summary>
    public string GetTreeEntityAndInterfaces() {
        var result = new StringBuilder();
        result.Append( GetTreeEntity() );
        result.Append( GetEntityInterfaces() );
        return result.ToString();
    }

    /// <summary>
    /// 获取树形实体
    /// </summary>
    private string GetTreeEntity() {
        switch( _context.Key.SystemType ) {
            case SystemType.String:
                return $"TreeEntityBase<{EntityName},string,string>";
            case SystemType.Int:
                return $"TreeEntityBase<{EntityName},int,int?>";
            case SystemType.Long:
                return $"TreeEntityBase<{EntityName},long,long?>";
            default:
                return $"TreeEntityBase<{EntityName}>";
        }
    }

    #endregion

    #region IsTreeEntityProperty(是否树形实体属性)

    /// <summary>
    /// 是否树形实体属性
    /// </summary>
    public bool IsTreeEntityProperty( Property property ) {
        switch ( property.Name ) {
            case "ParentId":
                return true;
            case "Path":
                return true;
            case "Level":
                return true;
            case "Enabled":
                return true;
            case "SortId":
                return true;
        }
        return false;
    }

    #endregion

    #region GetITreeRepository(获取树形仓储接口)

    /// <summary>
    /// 获取树形仓储接口
    /// </summary>
    public string GetITreeRepository() {
        if( _context.Key.SystemType == SystemType.Guid )
            return $"ITreeRepository<{EntityName}>";
        return $"ITreeRepository<{EntityName},{GetKeyType()},{GetParentKeyType()}>";
    }

    /// <summary>
    /// 获取父标识类型
    /// </summary>
    private string GetParentKeyType() {
        return _context.Key.NullableTypeName;
    }

    #endregion

    #region GetTreeRepositoryBase(获取树形仓储基类)

    /// <summary>
    /// 获取树形仓储基类
    /// </summary>
    public string GetTreeRepositoryBase() {
        if( _context.Key.SystemType == SystemType.Guid )
            return $"TreeRepositoryBase<{EntityName}>";
        return $"TreeRepositoryBase<{EntityName},{GetKeyType()},{GetParentKeyType()}>";
    }

    #endregion

    #region GetTreeQueryParameter(获取树形查询参数)

    /// <summary>
    /// 获取树形查询参数
    /// </summary>
    public string GetTreeQueryParameter() {
        return "TreeQueryParameter";
    }

    #endregion

    #region GetITreeService(获取树形服务接口)

    /// <summary>
    /// 获取树形服务接口
    /// </summary>
    public string GetITreeService() {
        return $"ITreeService<{GetDto()},{GetQuery()}>";
    }

    #endregion

    #region GetTreeServiceBase(获取树形服务基类)

    /// <summary>
    /// 获取树形服务基类
    /// </summary>
    public string GetTreeServiceBase() {
        if( _context.Key.SystemType == SystemType.Guid )
            return $"TreeServiceBase<{EntityName},{GetDto()},{GetQuery()}>";
        return $"TreeServiceBase<{EntityName},{GetDto()},{GetQuery()},{GetKeyType()},{GetParentKeyType()}>";
    }

    #endregion
}