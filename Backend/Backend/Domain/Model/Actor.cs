namespace Domain.Model
{
    public class Actor
    {
        public Actor()
        {
            BookActor = new HashSet<BookActor>();
        }

        public int ActorId { get; set; }

        public string Name { get; set; }

        public ICollection<BookActor> BookActor { get; set; }

    }
}
