namespace Domain.Model
{
    public class Author
    {
        public Author()
        {
            BookAuthor = new HashSet<BookAuthor>();
        }

        public int AuthorId { get; set; }

        public string Name { get; set; }

        public ICollection<BookAuthor> BookAuthor { get; set; }

    }
}
