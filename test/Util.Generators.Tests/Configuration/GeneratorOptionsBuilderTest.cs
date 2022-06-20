using Util.Data;
using Util.Generators.Configuration;
using Xunit;

namespace Util.Generators.Tests.Configuration {
    /// <summary>
    /// 生成器配置项构建器测试
    /// </summary>
    public class GeneratorOptionsBuilderTest {
        /// <summary>
        /// 生成器配置项
        /// </summary>
        private readonly GeneratorOptions _options;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public GeneratorOptionsBuilderTest() {
            var builder = new GeneratorOptionsBuilder();
            _options = builder.Build();
        }

        /// <summary>
        /// 测试基础配置
        /// </summary>
        [Fact]
        public void TestBaseInfo() {
            Assert.Equal( "TemplatePath", _options.TemplatePath );
            Assert.Equal( "OutputPath", _options.OutputPath );
        }

        /// <summary>
        /// 测试项目配置1
        /// </summary>
        [Fact]
        public void TestProjects_1() {
            var project = _options.Projects["Test"];
            Assert.Equal( "Test", project.Name );
            Assert.Equal( DatabaseType.PgSql, project.DbType );
            Assert.Null( project.TargetDbType );
            Assert.Equal( "ConnectionString_Test", project.ConnectionString );
            Assert.Equal( "UnitOfWorkName_Test", project.UnitOfWorkName );
            Assert.Equal( "ClientAppName_Test", project.ClientAppName );
            Assert.True( project.Enabled );
            Assert.True( project.Utc );
        }

        /// <summary>
        /// 测试项目配置2
        /// </summary>
        [Fact]
        public void TestProjects_2() {
            var project = _options.Projects["Test2"];
            Assert.Equal( "Test2", project.Name );
            Assert.Equal( DatabaseType.MySql, project.DbType );
            Assert.Equal( DatabaseType.SqlServer, project.TargetDbType );
            Assert.Equal( "ConnectionString_Test2", project.ConnectionString );
            Assert.Equal( "UnitOfWorkName_Test2", project.UnitOfWorkName );
            Assert.Equal( "ClientAppName_Test2", project.ClientAppName );
            Assert.False( project.Enabled );
            Assert.False( project.Utc );
        }

        /// <summary>
        /// 测试消息配置
        /// </summary>
        [Fact]
        public void TestMessages() {
            Assert.Equal( "RequiredMessage", _options.Messages.RequiredMessage );
        }
    }
}
