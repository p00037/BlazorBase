namespace BlazorBase.Shared.ViewModels.MstOffice
{
    public class M_事業所明細ViewEntity
    {
        public string? 事業所番号 { get; set; }

        public int? 連番 { get; set; }

        public string? 施設名 { get; set; }

        public bool 種類コード { get; set; }

        public string? サービス提供単位番号 { get; set; }

        public int? 定員 { get; set; }

        public string? 多機能型用件 { get; set; }

        public decimal? 単位数単価 { get; set; }

        public string? 種類区分 { get; set; }
    }
}