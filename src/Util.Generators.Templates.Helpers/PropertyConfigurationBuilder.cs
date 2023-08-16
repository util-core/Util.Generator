namespace Util.Generators.Helpers; 

/// <summary>
/// 实体类型属性配置生成器
/// </summary>
public class PropertyConfigurationBuilder {
    /// <summary>
    /// 属性
    /// </summary>
    private readonly Property _property;
    /// <summary>
    /// 结果
    /// </summary>
    private readonly StringBuilder _result;

    /// <summary>
    /// 初始化实体类型属性配置生成器
    /// </summary>
    /// <param name="property">属性</param>
    public PropertyConfigurationBuilder( Property property ) {
        _property = property;
        _result = new StringBuilder();
    }

    /// <summary>
    /// 缩进
    /// </summary>
    /// <param name="indentCount">缩进倍数</param>
    public PropertyConfigurationBuilder Indent( int indentCount = 4 ) {
        if ( indentCount == 0 )
            return this;
        _result.Append( ' ', indentCount * 4 );
        return this;
    }

    /// <summary>
    /// 换行
    /// </summary>
    /// <param name="indentCount">换行后缩进倍数</param>
    /// <param name="condition">条件,为false则直接跳过</param>
    public PropertyConfigurationBuilder Line( int indentCount = 0, bool condition = true ) {
        if ( condition == false )
            return this;
        _result.AppendLine();
        Indent( indentCount );
        return this;
    }

    /// <summary>
    /// 添加分号
    /// </summary>
    public PropertyConfigurationBuilder Semicolon() {
        _result.Append( ";" );
        return this;
    }

    /// <summary>
    /// 添加属性名
    /// </summary>
    /// <param name="name">属性名</param>
    public PropertyConfigurationBuilder Property( string name = null ) {
        if ( name.IsEmpty() )
            name = _property.Name;
        _result.Append( $"builder.Property( t => t.{name} )" );
        return this;
    }

    /// <summary>
    /// 添加列名
    /// </summary>
    public PropertyConfigurationBuilder HasColumnName() {
        _result.Append( $".HasColumnName( \"{ _property.Name}\" )" );
        return this;
    }

    /// <summary>
    /// 添加列类型
    /// </summary>
    public PropertyConfigurationBuilder HasColumnType( string columnType ) {
        _result.Append( $".HasColumnType( \"{columnType}\" )" );
        return this;
    }

    /// <summary>
    /// 添加列类型
    /// </summary>
    public PropertyConfigurationBuilder HasColumnTypeIf( string columnType,bool condition ) {
        if ( condition == false )
            return this;
        HasColumnType( columnType );
        return this;
    }

    /// <summary>
    /// 添加注释
    /// </summary>
    public PropertyConfigurationBuilder HasComment() {
        _result.Append( $".HasComment( \"{ _property.Description }\" )" );
        return this;
    }

    /// <summary>
    /// 添加最大长度
    /// </summary>
    public PropertyConfigurationBuilder HasMaxLength() {
        if ( _property.SystemType != SystemType.String )
            return this;
        _result.Append( $".HasMaxLength( { _property.GetSafeMaxLength() } )" );
        return this;
    }

    /// <summary>
    /// 添加自增
    /// </summary>
    public PropertyConfigurationBuilder IsAutoIncrement() {
        if ( _property.IsInteger == false )
            return this;
        if ( _property.IsAutoIncrement ) {
            _result.Append( ".ValueGeneratedOnAdd()" );
            return this;
        }
        _result.Append( ".ValueGeneratedNever()" );
        return this;
    }

    /// <summary>
    /// 添加精度和小数位数
    /// </summary>
    public PropertyConfigurationBuilder HasPrecision() {
        if ( _property.IsFloat == false )
            return this;
        if ( _property.Precision.SafeValue() == 0 )
            return this;
        if ( _property.Scale.SafeValue() == 0 ) {
            _result.Append( $".HasPrecision({_property.Precision})" );
            return this;
        }
        _result.Append( $".HasPrecision({_property.Precision},{_property.Scale})" );
        return this;
    }

    /// <summary>
    /// 添加版本号
    /// </summary>
    /// <param name="type">数据库类型</param>
    public PropertyConfigurationBuilder Version( DatabaseType type ) {
        switch ( type ) {
            case DatabaseType.SqlServer:
                _result.Append( ".IsRowVersion()" );
                break;
        }
        return this;
    }

    /// <summary>
    /// 生成配置
    /// </summary>
    public string Build() {
        return _result.ToString();
    }
}