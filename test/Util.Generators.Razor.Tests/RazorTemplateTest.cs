using System.IO;
using Util.Generators.Contexts;
using Util.Helpers;
using Util.Templates;
using Xunit;

namespace Util.Generators.Razor.Tests {
    /// <summary>
    /// Razor模板测试
    /// </summary>
    public class RazorTemplateTest {
        /// <summary>
        /// 模板引擎
        /// </summary>
        private readonly ITemplateEngine _templateEngine;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public RazorTemplateTest( ITemplateEngine templateEngine ) {
            _templateEngine = templateEngine;
        }

        /// <summary>
        /// 测试渲染模板
        /// </summary>
        [Fact]
        public void TestRender() {
            var path = Platform.GetPhysicalPath( "Templates/Test1/Template.cshtml" );
            var template = new RazorTemplate( _templateEngine, new FileInfo( path ) );
            var generatorContext = new GeneratorContext {
                TemplateRootPath = Platform.GetPhysicalPath( "~/Templates" ),
                OutputRootPath = Platform.GetPhysicalPath( "~/Output" )
            };
            var projectContext = new ProjectContext( generatorContext ) { Name = "test" };
            var entityContext = new EntityContext( projectContext, "Hello" );
            var result = template.Render( entityContext );
            Assert.Equal( "Hello,World", result );
            Assert.Equal( "Test1", entityContext.Output.RelativeRootPath );
        }
    }
}
