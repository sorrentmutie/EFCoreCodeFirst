namespace DemoEFCore.Movies;

public class Genre: Entity<int>
{
    public string? Name { get; set; }
    public List<Movie> Movies { get; set; } = new();
}
