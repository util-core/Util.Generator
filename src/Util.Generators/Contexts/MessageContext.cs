namespace Util.Generators.Contexts {
    /// <summary>
    /// 消息上下文
    /// </summary>
    public class MessageContext {
        /// <summary>
        /// 必填项消息
        /// </summary>
        public string RequiredMessage { get; set; }

        /// <summary>
        /// 复制
        /// </summary>
        public MessageContext Clone() {
            return new() {
                RequiredMessage = RequiredMessage
            };
        }
    }
}
