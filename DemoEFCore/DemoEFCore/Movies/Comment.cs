namespace DemoEFCore.Movies;

public class Comment: Entity<int>
{
    public string Text { get; set; } = "";
    public int Vote { get; set; }
    public int MovieId { get; set; }
    public Movie? Movie { get; set; }
}
