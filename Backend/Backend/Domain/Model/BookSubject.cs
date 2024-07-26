using System.Text.Json.Serialization;

namespace Domain.Model
{
    public class BookSubject
    {
        public int BookId { get; set; }

        public int SubjectId { get; set; }

        [JsonIgnore]
        public Book? Book { get; set; }

        [JsonIgnore]
        public Subject? Subject { get; set; }
    }
}
