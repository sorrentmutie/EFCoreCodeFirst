using Microsoft.EntityFrameworkCore;

namespace DemoEFCore.Movies;

public class MoviesDbContext: DbContext
{
    public MoviesDbContext()
    {
            
    }

    protected override void OnConfiguring
        (DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=mymovies.db");
        optionsBuilder.LogTo(Console.WriteLine);
        optionsBuilder.EnableSensitiveDataLogging();
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<MovieActor>()
        //    .HasKey(x => new { x.MovieId, x.ActorId });

        modelBuilder.Entity<Actor>()
            .Property(a => a.Salary)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Movie>()
            .Property(p => p.ReleaseDate)
                .HasColumnType("date");

        modelBuilder.Entity<Movie>()
            .Property(m => m.Title).IsRequired();


        modelBuilder.Entity<Genre>()
            .Property(p => p.Name)
                //.HasColumnName("Nome")
                .HasMaxLength(50);
        //modelBuilder.Entity<Genre>().ToTable("tblGenres")

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<MovieActor> MoviesActors { get; set; }
}
