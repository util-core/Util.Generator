using Humanizer;
using System.Text;
using Util.Generators.Contexts;
using Util.Helpers;

namespace Util.Generators.Helpers {
    /// <summary>
    /// 生成服务 - 多语言相关方法
    /// </summary>
    public partial class GenerateService {

        #region GetClientI18nContent(获取前端i18n多语言内容)

        /// <summary>
        /// 获取前端i18n多语言内容
        /// </summary>
        /// <param name="isChinese">是否显示中文</param>
        public string GetClientI18nContent( bool isChinese = true ) {
            var result = new StringBuilder();
            foreach ( var schema in GetClientSchemas() )
                AppendI18nSchemaContent( result, schema, isChinese );
            result.RemoveEnd( $",{Common.Line}" );
            return result.ToString();
        }

        /// <summary>
        /// 添加i18n多语言单个架构内容
        /// </summary>
        private void AppendI18nSchemaContent( StringBuilder result, string schema, bool isChinese ) {
            result.Append( $"  \"{schema.Pluralize().Camelize()}\": " );
            result.AppendLine( "{" );
            foreach ( var entity in GetEntities( schema ) )
                AppendI18nEntityContent( result, entity, isChinese );
            result.RemoveEnd( $",{Common.Line}" );
            result.AppendLine();
            result.AppendLine( "  }," );
        }

        /// <summary>
        /// 添加i18n多语言单个实体内容
        /// </summary>
        private void AppendI18nEntityContent( StringBuilder result, EntityContext entity, bool isChinese ) {
            result.Append( $"    \"{entity.Name.Camelize()}\": " );
            result.AppendLine( "{" );
            AppendI18nDefaultEntityContent( result, entity, isChinese );
            foreach ( var property in entity.Properties )
                AppendI18nPropertyContent( result, property, isChinese );
            result.RemoveEnd( $",{Common.Line}" );
            result.AppendLine();
            result.AppendLine( "    }," );
        }

        /// <summary>
        /// 添加i18n多语言实体默认内容
        /// </summary>
        private void AppendI18nDefaultEntityContent( StringBuilder result, EntityContext entity, bool isChinese ) {
            var entityDescription = GetI18nValue( entity, isChinese );
            result.AppendLine( $"      \"\": \"{entityDescription}\"," );
            AppendI18nCreateEntityContent( result, entityDescription, isChinese );
            AppendI18nUpdateEntityContent( result, entityDescription, isChinese );
            AppendI18nDeleteEntityContent( result, entityDescription, isChinese );
            AppendI18nEntityDetailContent( result, entityDescription, isChinese );
            AppendI18nCreateSubEntityContent( result, entity, isChinese );
            AppendI18nParentIdContent( result, entity, isChinese );
        }

        /// <summary>
        /// 添加i18n多语言创建实体内容
        /// </summary>
        private void AppendI18nCreateEntityContent( StringBuilder result, string entityDescription, bool isChinese ) {
            result.Append( "      \"create\": " );
            result.Append( isChinese ? "\"创建" : "\"Create " );
            result.AppendLine( $"{entityDescription}\"," );
        }

        /// <summary>
        /// 添加i18n多语言修改实体内容
        /// </summary>
        private void AppendI18nUpdateEntityContent( StringBuilder result, string entityDescription, bool isChinese ) {
            result.Append( "      \"update\": " );
            result.Append( isChinese ? "\"更新" : "\"Update " );
            result.AppendLine( $"{entityDescription}\"," );
        }

        /// <summary>
        /// 添加i18n多语言删除实体内容
        /// </summary>
        private void AppendI18nDeleteEntityContent( StringBuilder result, string entityDescription, bool isChinese ) {
            result.Append( "      \"delete\": " );
            result.Append( isChinese ? "\"删除" : "\"Delete " );
            result.AppendLine( $"{entityDescription}\"," );
        }

        /// <summary>
        /// 添加i18n多语言实体详情内容
        /// </summary>
        private void AppendI18nEntityDetailContent( StringBuilder result, string entityDescription, bool isChinese ) {
            result.Append( "      \"detail\": " );
            result.Append( $"\"{entityDescription}" );
            result.Append( isChinese ? "详情" : " Detail" );
            result.AppendLine( "\"," );
        }

        /// <summary>
        /// 添加i18n多语言创建下级树形实体内容
        /// </summary>
        private void AppendI18nCreateSubEntityContent( StringBuilder result, EntityContext entity, bool isChinese ) {
            if ( entity.HasTree == false )
                return;
            result.Append( $"      \"createSub{entity.PascalName}\": " );
            result.Append( "\"" );
            result.Append( isChinese ? $"创建下级{GetI18nValue( entity, true )}" : $"Create sub {GetI18nValue( entity, false ).Camelize()}" );
            result.AppendLine( "\"," );
        }

        /// <summary>
        /// 添加i18n多语言树形实体父标识内容
        /// </summary>
        private void AppendI18nParentIdContent( StringBuilder result, EntityContext entity, bool isChinese ) {
            if ( entity.HasTree == false )
                return;
            result.Append( $"      \"parentId\": " );
            result.Append( "\"" );
            result.Append( isChinese ? $"父{GetI18nValue( entity, true )}" : $"Parent {GetI18nValue( entity, false )}" );
            result.AppendLine( "\"," );
        }

        /// <summary>
        /// 获取i18n多语言值
        /// </summary>
        private string GetI18nValue( EntityContext entity, bool isChinese ) {
            if ( isChinese )
                return entity.Description;
            return entity.Name.Pascalize();
        }

        /// <summary>
        /// 添加i18n多语言单个属性内容
        /// </summary>
        private void AppendI18nPropertyContent( StringBuilder result, Property property, bool isChinese ) {
            if ( property.IsKey )
                return;
            if ( property.IsCreatorId )
                return;
            if ( property.IsLastModifierId )
                return;
            if ( property.IsTree )
                return;
            if ( property.IsDeleted )
                return;
            if ( property.IsVersion )
                return;
            if ( property.IsExtraProperties )
                return;
            result.Append( $"      \"{property.Name.Camelize()}\": " );
            result.AppendLine( $"\"{GetI18nValue( property, isChinese )}\"," );
            if ( property.IsDateTime ) {
                AppendI18nDateTimeContent( result, property, isChinese );
                return;
            }
        }

        /// <summary>
        /// 添加i18n多语言开始和结束日期内容
        /// </summary>
        private void AppendI18nDateTimeContent( StringBuilder result, Property property, bool isChinese ) {
            result.Append( $"      \"begin{property.Name.Pascalize()}\": " );
            result.AppendLine( isChinese ? $"\"起始{GetI18nValue( property, true )}\"," : $"\"Begin{GetI18nValue( property, false )}\"," );
            result.Append( $"      \"end{property.Name.Pascalize()}\": " );
            result.AppendLine( isChinese ? $"\"结束{GetI18nValue( property, true )}\"," : $"\"End{GetI18nValue( property, false )}\"," );
        }

        /// <summary>
        /// 获取i18n多语言值
        /// </summary>
        private string GetI18nValue( Property property, bool isChinese ) {
            if ( isChinese )
                return property.Description;
            return property.Name.Pascalize();
        }

        #endregion

        #region GetPropertyI18nDisplay(获取属性Display特性)

        /// <summary>
        /// 获取属性Display特性,支持多语言
        /// </summary>
        /// <param name="property">属性</param>
        public string GetPropertyI18nDisplay( Property property ) {
            if ( property.IsCreatorId )
                return null;
            if ( property.IsLastModifierId )
                return null;
            if ( property.IsVersion )
                return null;
            var result = new StringBuilder();
            result.AppendLine();
            result.Append( "        [Display( Name = \"" );
            result.Append( GetPropertyI18nKey( property ) );
            result.Append( "\" )]" );
            return result.ToString();
        }

        #endregion

        #region GetEntityI18nKey(获取实体多语言键)

        /// <summary>
        /// 获取实体多语言键
        /// </summary>
        public string GetEntityI18nKey() {
            return GetEntityI18nKey( _context );
        }

        /// <summary>
        /// 获取实体多语言键
        /// </summary>
        public string GetEntityI18nKey( EntityContext entity ) {
            return $"{GetSchemaI18nKey( entity )}.{entity.Name.Camelize()}";
        }

        /// <summary>
        /// 获取实体架构多语言键
        /// </summary>
        private string GetSchemaI18nKey( EntityContext entity ) {
            var key = entity.Schema;
            if ( entity.Schema.IsEmpty() )
                key = entity.ProjectContext.Client.AppName;
            return key.Pluralize().Camelize();
        }

        #endregion

        #region GetPropertyI18nKey(获取属性多语言键)

        /// <summary>
        /// 获取属性多语言键
        /// </summary>
        /// <param name="property">属性</param>
        /// <param name="prefix">属性键前缀,范例:begin,生成beginDateTime</param>
        public string GetPropertyI18nKey( Property property,string prefix = null ) {
            return $"{GetEntityI18nKey( property.Entity )}.{GetPropertyI18nKey( property.Name, prefix )}";
        }

        /// <summary>
        /// 获取属性多语言键
        /// </summary>
        private string GetPropertyI18nKey( string propertyName, string prefix ) {
            if ( prefix.IsEmpty() )
                return propertyName.Camelize();
            return $"{prefix.Camelize()}{propertyName.Pascalize()}";
        }

        #endregion

        #region GetCreateEntityI18nKey(获取创建实体多语言键)

        /// <summary>
        /// 获取创建实体多语言键
        /// </summary>
        public string GetCreateEntityI18nKey() {
            return $"{GetEntityI18nKey( _context )}.create";
        }

        #endregion

        #region GetUpdateEntityI18nKey(获取修改实体多语言键)

        /// <summary>
        /// 获取修改实体多语言键
        /// </summary>
        public string GetUpdateEntityI18nKey() {
            return $"{GetEntityI18nKey( _context )}.update";
        }

        #endregion

        #region GetEntityDetailI18nKey(获取实体详情多语言键)

        /// <summary>
        /// 获取实体详情多语言键
        /// </summary>
        public string GetEntityDetailI18nKey() {
            return $"{GetEntityI18nKey( _context )}.detail";
        }

        #endregion

        #region GetCreateSubTreeEntityI18nKey(获取创建下级树形实体多语言键)

        /// <summary>
        /// 获取创建下级树形实体多语言键
        /// </summary>
        public string GetCreateSubTreeEntityI18nKey() {
            return $"{GetEntityI18nKey( _context )}.createSub{EntityName}";
        }

        #endregion

        #region GetParentIdI18nKey(获取树形实体父标识多语言键)

        /// <summary>
        /// 获取树形实体父标识多语言键
        /// </summary>
        public string GetParentIdI18nKey() {
            return $"{GetEntityI18nKey( _context )}.parentId";
        }

        #endregion
    }
}
