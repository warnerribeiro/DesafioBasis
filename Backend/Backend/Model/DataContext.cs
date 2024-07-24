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
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BookDb;Trusted_Connection=True;ConnectRetryCount=0");
        }
    }


}
