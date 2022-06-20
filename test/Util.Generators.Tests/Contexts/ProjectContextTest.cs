using Util.Data;
using Util.Generators.Contexts;
using Xunit;

namespace Util.Generators.Tests.Contexts {
    /// <summary>
    /// 项目上下文测试
    /// </summary>
    public class ProjectContextTest {
        /// <summary>
        /// 测试复制
        /// </summary>
        [Fact]
        public void TestClone() {
            //创建项目上下文
            var generatorContext = new GeneratorContext {
                TemplateRootPath = "Templates",
                OutputRootPath = "Output"
            };
            var projectContext = new ProjectContext( generatorContext ) {
                Name = "Project",
                UnitOfWorkName = "UnitOfWork",
                ClientAppName = "ClientApp",
                TargetDbType = DatabaseType.PgSql,
                Enabled = true,
                Utc = true
            };

            //添加架构列表
            projectContext.Schemas.Add( "a" );
            projectContext.Schemas.Add( "b" );

            //添加实体上下文1
            var entityContext1 = new EntityContext( projectContext, "a" );
            projectContext.Entities.Add( entityContext1 );

            //添加实体上下文2
            var entityContext2 = new EntityContext( projectContext, "b" );
            projectContext.Entities.Add( entityContext2 );

            //复制副本
            var clone = projectContext.Clone( generatorContext );

            //验证项目上下文
            Assert.NotSame( projectContext, clone );
            Assert.Equal( projectContext.Name, clone.Name );
            Assert.Equal( projectContext.UnitOfWorkName, clone.UnitOfWorkName );
            Assert.Equal( projectContext.ClientAppName, clone.ClientAppName );
            Assert.Equal( projectContext.TargetDbType, clone.TargetDbType );
            Assert.Equal( projectContext.Enabled, clone.Enabled );
            Assert.Equal( projectContext.Utc, clone.Utc );

            //验证架构列表
            Assert.Equal( 2, clone.Schemas.Count );

            //验证实体上下文
            Assert.Equal( 2, clone.Entities.Count );
        }
    }
}
