namespace DemoEFCore.Core.Movies;

public class Comment: IEntity<int>
{
    public string Text { get; set; } = "";
    public int Vote { get; set; }
    public int MovieId { get; set; }
    public Movie? Movie { get; set; }
    public int Id { get; set; }
}
