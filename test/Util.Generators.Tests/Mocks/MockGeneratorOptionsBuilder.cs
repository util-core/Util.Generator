using System.Collections.Generic;
using Util.Data;
using Util.Generators.Configuration;

namespace Util.Generators.Tests.Mocks {
    /// <summary>
    /// 模拟生成器配置项构建器
    /// </summary>
    public class MockGeneratorOptionsBuilder : IGeneratorOptionsBuilder {
        /// <summary>
        /// 构建生成器配置项
        /// </summary>
        public GeneratorOptions Build() {
            return new GeneratorOptions {
                TemplatePath = "Templates",
                OutputPath = "Output",
                Messages = new MessageOptions {
                    RequiredMessage = "Required_Message"
                },
                Projects = new Dictionary<string, ProjectOptions> {
                    {"Test",new ProjectOptions {
                        Name = "Test",
                        UnitOfWorkName = "UnitOfWork",
                        ClientAppName = "ClientApp",
                        DbType = DatabaseType.SqlServer,
                        TargetDbType = DatabaseType.PgSql,
                        ConnectionString = "TestConnection",
                        Enabled = true,
                        Utc = true
                    }},
                    {"Test2",new ProjectOptions {
                        Name = "Test2",
                        UnitOfWorkName = "UnitOfWork2",
                        ClientAppName = "ClientApp2",
                        DbType = DatabaseType.PgSql,
                        ConnectionString = "TestConnection2",
                        Enabled = true,
                        Utc = true
                    }},
                    {"Test3",new ProjectOptions {
                        Name = "Test3",
                        UnitOfWorkName = "UnitOfWork3",
                        ClientAppName = "ClientApp3",
                        DbType = DatabaseType.SqlServer,
                        TargetDbType = DatabaseType.PgSql,
                        ConnectionString = "TestConnection3",
                        Enabled = false,
                        Utc = false
                    }},
                }
            };
        }
    }

    /// <summary>
    /// 模拟生成器配置项构建器2
    /// </summary>
    public class MockGeneratorOptionsBuilder2 : IGeneratorOptionsBuilder {
        /// <summary>
        /// 构建生成器配置项
        /// </summary>
        public GeneratorOptions Build() {
            return new GeneratorOptions {
                TemplatePath = @"c:\Templates",
                OutputPath = @"d:\Output",
                Projects = new Dictionary<string, ProjectOptions> {
                    {"Test",new ProjectOptions {
                        Name = "Test",
                        UnitOfWorkName = "UnitOfWork",
                        ClientAppName = "ClientApp",
                        DbType = DatabaseType.SqlServer,
                        ConnectionString = "TestConnection"
                    }},
                    {"Test2",new ProjectOptions {
                        Name = "Test2",
                        UnitOfWorkName = "UnitOfWork2",
                        ClientAppName = "ClientApp2",
                        DbType = DatabaseType.PgSql,
                        TargetDbType = DatabaseType.SqlServer,
                        ConnectionString = "TestConnection2"
                    }}
                }
            };
        }
    }
}
