namespace Domain.Model
{
    public class Subject
    {
        public Subject()
        {
            BookSubject = new HashSet<BookSubject>();
        }

        public int SubjectId { get; set; }

        public string Description { get; set; }

        public ICollection<BookSubject> BookSubject { get; set; }
    }
}
