namespace Domain.Model
{
    public class OriginPurchase
    {
        public int OriginPurchaseId { get; set; }

        public string Name { get; set; }

        public ICollection<BookValue> BookValue { get; set; }
    }
}
