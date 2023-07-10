using System;

namespace Util.Generators.Helpers {
    /// <summary>
    /// VS解决方案项目标识
    /// </summary>
    public static class VsProjectId {
        /// <summary>
        /// src解决方案文件夹标识
        /// </summary>
        public static string Src { get; set; } = Guid.NewGuid().ToString().ToUpperInvariant();
        /// <summary>
        /// Presentation解决方案文件夹标识
        /// </summary>
        public static string Presentation { get; set; } = Guid.NewGuid().ToString().ToUpperInvariant();
        /// <summary>
        /// Application解决方案文件夹标识
        /// </summary>
        public static string Application { get; set; } = Guid.NewGuid().ToString().ToUpperInvariant();
        /// <summary>
        /// Domain解决方案文件夹标识
        /// </summary>
        public static string Domain { get; set; } = Guid.NewGuid().ToString().ToUpperInvariant();
        /// <summary>
        /// Infrastructure解决方案文件夹标识
        /// </summary>
        public static string Infrastructure { get; set; } = Guid.NewGuid().ToString().ToUpperInvariant();
        /// <summary>
        /// test解决方案文件夹标识
        /// </summary>
        public static string Test { get; set; } = Guid.NewGuid().ToString().ToUpperInvariant();
    }
}
