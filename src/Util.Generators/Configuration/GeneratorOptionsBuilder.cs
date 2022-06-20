using Util.Helpers;

namespace Util.Generators.Configuration {
    /// <summary>
    /// 生成器配置项构建器
    /// </summary>
    public class GeneratorOptionsBuilder : IGeneratorOptionsBuilder {
        /// <summary>
        /// 构建生成器配置项
        /// </summary>
        public GeneratorOptions Build() {
            return Config.Get<GeneratorOptions>( "Generator" );
        }
    }
}
