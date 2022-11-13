namespace BlazorBase.Shared.ViewModels.MstOffice
{
    public class M_事業所ViewEntity
    {
        public string 事業所番号 { get; set; }

        public string 事業所名 { get; set; }

        public string 事業所名カナ { get; set; }

        public string 郵便番号 { get; set; }

        public string 住所 { get; set; }

        public string 電話番号 { get; set; }

        public int? 定員規模 { get; set; }

        public bool 就労継続A型減免有無 { get; set; }

        public DateTime? 登録日 { get; set; }

        public List<M_事業所明細ViewEntity> M_事業所明細Entities { get; set; } = new List<M_事業所明細ViewEntity>();

        public string Url => $"MstOfficePage/1/{事業所番号}";
    }
}