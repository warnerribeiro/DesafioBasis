namespace Domain.Model
{
    public class BookSubject
    {
        public int BookId { get; set; }

        public int SubjectId { get; set; }

        public Book Book { get; set; }

        public Subject Subject { get; set; }
    }
}
