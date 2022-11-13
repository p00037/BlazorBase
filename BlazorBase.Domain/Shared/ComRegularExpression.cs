namespace BlazorBase.Domain.Shared
{
    public class ComRegularExpression
    {
        public const string 半角英字 = @"[a-zA-Z]+";
        public const string 半角英字大文字 = @"[A-Z]+";
        public const string 半角英数字 = @"[a-zA-Z0-9]+";
        public const string 半角英数字記号 = @"[a-zA-Z0-9- /:-@\[-~]+";
        public const string 半角数字 = @"[0-9]+";
        public const string 半角数字記号 = @"[0-9- /:-@\[-~]+";
        public const string 半角数字記号カタカナ = @"[0-9｡-ﾟ+\s\-]+";
        public const string 半角カタカナ = @"[｡-ﾟ+\s\-]+";
    }
}
