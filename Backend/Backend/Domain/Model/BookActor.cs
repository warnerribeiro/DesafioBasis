namespace Domain.Model
{
    public class BookActor
    {
        public int BookId { get; set; }

        public int ActorId { get; set; }

        public Book Book { get; set; }

        public Actor Actor { get; set; }
    }
}
