using System.Text.Json.Serialization;

namespace Domain.Model
{
    public class BookAuthor
    {
        public int BookId { get; set; }

        public int AuthorId { get; set; }

        [JsonIgnore]
        public Book? Book { get; set; }

        [JsonIgnore]
        public Author? Author { get; set; }
    }
}
