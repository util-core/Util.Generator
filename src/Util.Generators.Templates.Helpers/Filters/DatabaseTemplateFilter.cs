using System;
using System.Linq;
using Util.Data;
using Util.Generators.Contexts;
using Util.Generators.Templates;

namespace Util.Generators.Helpers.Filters {
    /// <summary>
    /// 数据库模板过滤器
    /// </summary>
    public class DatabaseTemplateFilter : ITemplateFilter {
        /// <inheritdoc />
        public bool IsFilter( string path, ProjectContext projectContext ) {
            if ( path.IsEmpty() )
                return true;
            if( path.Contains( "Data.EntityFrameworkCore", StringComparison.OrdinalIgnoreCase ) == false )
                return false;
            var targetDatabase = Util.Helpers.Enum.GetName<DatabaseType>( projectContext.TargetDbType );
            var databases = Util.Helpers.Enum.GetItems<DatabaseType>().Select( t => t.Text ).ToList();
            foreach ( var database in databases ) {
                if ( path.Contains( database, StringComparison.OrdinalIgnoreCase ) && database != targetDatabase )
                    return true;
            }
            return false;
        }
    }
}
