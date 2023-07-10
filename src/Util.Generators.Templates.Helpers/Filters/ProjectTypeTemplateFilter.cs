using System;
using Util.Generators.Configuration;
using Util.Generators.Contexts;
using Util.Generators.Templates;

namespace Util.Generators.Helpers.Filters {
    /// <summary>
    /// 项目类型模板过滤器
    /// </summary>
    public class ProjectTypeTemplateFilter : ITemplateFilter {
        /// <inheritdoc />
        public bool IsFilter( string path, ProjectContext projectContext ) {
            if ( path.IsEmpty() )
                return true;
            if( path.Contains( "Presentation", StringComparison.OrdinalIgnoreCase ) == false )
                return false;
            if ( projectContext.ProjectType == ProjectType.Ui )
                return false;
            return true;
        }
    }
}
