using System.IO;
using Util.Generators.Contexts;
using Util.Generators.Templates;
using Util.Templates;

namespace Util.Generators.Razor {
    /// <summary>
    /// Razor模板
    /// </summary>
    public class RazorTemplate : ITemplate {
        /// <summary>
        /// Razor模板引擎
        /// </summary>
        protected readonly ITemplateEngine TemplateEngine;
        /// <summary>
        /// 模板文件
        /// </summary>
        protected readonly FileInfo TemplateFile;

        /// <summary>
        /// 初始化Razor模板
        /// </summary>
        /// <param name="templateEngine">Razor模板引擎</param>
        /// <param name="file">模板文件</param>
        public RazorTemplate( ITemplateEngine templateEngine, FileInfo file ) {
            TemplateEngine = templateEngine;
            TemplateFile = file;
        }

        /// <summary>
        /// 模板路径
        /// </summary>
        public string Path => TemplateFile.FullName;

        /// <summary>
        /// 渲染
        /// </summary>
        /// <param name="context">实体上下文</param>
        public string Render( EntityContext context ) {
            ValidateEntityContext( context );
            InitRelativeRootPath( context );
            var result = RenderResult( context );
            WriteFile( context, result );
            return result;
        }

        /// <summary>
        /// 验证实体上下文
        /// </summary>
        /// <param name="context">实体上下文</param>
        protected virtual void ValidateEntityContext( EntityContext context ) {
            context.CheckNull( nameof( context ) );
        }

        /// <summary>
        /// 初始化相对根路径
        /// </summary>
        /// <param name="context">实体上下文</param>
        protected virtual void InitRelativeRootPath( EntityContext context ) {
            var relativeRootPath = GetRelativeRootPath( context );
            context.Output.RelativeRootPath = relativeRootPath;
        }

        /// <summary>
        /// 获取模板相对根路径
        /// </summary>
        /// <param name="context">实体上下文</param>
        protected string GetRelativeRootPath( EntityContext context ) {
            return TemplateFile.DirectoryName.RemoveStart( context.ProjectContext.GeneratorContext.TemplateRootPath ).RemoveStart( "\\" );
        }

        /// <summary>
        /// 渲染结果
        /// </summary>
        /// <param name="context">实体上下文</param>
        protected virtual string RenderResult( EntityContext context ) {
            return TemplateEngine.RenderByPath( TemplateFile.FullName, context );
        }

        /// <summary>
        /// 写入文件
        /// </summary>
        /// <param name="context">实体上下文</param>
        /// <param name="result">渲染结果</param>
        protected virtual void WriteFile( EntityContext context,string result ) {
            if( context.Output.Path.IsEmpty() )
                return;
            Util.Helpers.File.Write( context.Output.Path, result );
        }
    }
}
