namespace Domain.Model
{
    public class Book
    {
        public Book()
        {
            BookActor = new HashSet<BookActor>();
            BookSubject = new HashSet<BookSubject>();
        }

        public int BookId { get; set; }

        public string Title { get; set; }

        public string Publisher { get; set; }

        public int Edition { get; set; }

        public string YearOfPublication { get; set; }

        public ICollection<BookActor> BookActor { get; set; }

        public ICollection<BookSubject> BookSubject { get; set; }
    }
}
