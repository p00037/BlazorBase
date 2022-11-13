namespace BlazorBase.Domain.Shared
{
    public class ComValidationMessage
    {
        public const string Required = @"{0}は必須です";
        public const string Range = @"{0}の範囲は{1}～{2}です";
        public const string StringLength = @"{0}の最大文字数は{1}です";
        public const string RegularExpression半角英字 = @"{0}は半角英字のみ入力できます";
        public const string RegularExpression半角英字大文字 = @"{0}は半角英字大文字のみ入力できます";
        public const string RegularExpression半角英数字 = @"{0}は半角英数のみ入力できます";
        public const string RegularExpression半角英数字記号 = @"{0}は半角英数字記号のみ入力できます";
        public const string RegularExpression半角数字 = @"{0}は半角数字のみ入力できます";
        public const string RegularExpression半角数字記号 = @"{0}は半角数字記号のみ入力できます";
        public const string RegularExpression半角カタカナ = @"{0}は半角カタカナのみ入力できます";
        public const string RegularExpression半角カタカナ数字記号 = @"{0}は半角カタカナ数字記号のみ入力できます";

        public static string GetRequiredMessage(string name)
        {
            return string.Format(Required, name);
        }
    }
}
