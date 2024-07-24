using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Model.Configuration;

namespace Backend.Model
{
    public class DataContext : DbContext
    {
        public DataContext() { }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Actor> Actor { get; set; }

        public DbSet<Subject> Subject { get; set; }

        public DbSet<Book> Book { get; set; }

        public DbSet<BookActor> BookActor { get; set; }

        public DbSet<BookSubject> BookSubject { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ActorConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new BookActorConfiguration());
            modelBuilder.ApplyConfiguration(new BookSubjectConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=192.168.1.100,11433;Database=BookDb;user id=sa;password=@War23ner10;Trusted_Connection=False;TrustServerCertificate=False;Encrypt=false;ConnectRetryCount=0");
        }
    }


}
