using System.Text.Json.Serialization;

namespace Domain.Model
{
    public class BookValue
    {
        public int BookId { get; set; }

        public int OriginPurchaseId { get; set; }

        public decimal Value { get; set; }

        [JsonIgnore]
        public Book? Book { get; set; }

        [JsonIgnore]
        public OriginPurchase? OriginPurchase { get; set; }
    }
}
