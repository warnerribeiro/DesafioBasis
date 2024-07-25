namespace Domain.Model
{
    public class BookValue
    {
        public int BookId { get; set; }

        public int OriginPurchaseId { get; set; }

        public decimal Value { get; set; }

        public Book Book { get; set; }

        public OriginPurchase OriginPurchase { get; set; }
    }
}
