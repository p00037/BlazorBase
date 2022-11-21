namespace BlazorBase.Client.Pages
{
    public class ErrorMessage
    {
        private readonly List<string> messages;

        private ErrorMessage(List<string> messages)
        {
            this.messages = messages;
        }

        public bool IsError => this.messages.Any();

        public string HtmlCode => ConcatWithHtmlItemize(messages);

        /// <summary>
        /// 文字列を結合する(Htmlの箇条書きにする）
        /// </summary>
        /// <param name="source">拡張メソッド本体の値</param>
        /// <returns>結合した文字</returns>
        private string ConcatWithHtmlItemize(IEnumerable<string> source)
        {
            return "<ul><li>" + string.Join("</li><li>", source) + "</li></ul>";
        }

        public static ErrorMessage Create(List<string> messages)
        {
            return new ErrorMessage(messages);
        }

        public static ErrorMessage CreateNoError()
        {
            return new ErrorMessage(new List<string>());
        }
    }
}
