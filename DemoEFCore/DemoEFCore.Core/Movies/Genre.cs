namespace DemoEFCore.Core.Movies;

public class Genre: IEntity<int>
{
    public string? Name { get; set; }
    public List<Movie> Movies { get; set; } = new();
    public int Id { get; set; }
}
