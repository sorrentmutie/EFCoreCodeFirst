namespace DemoEFCore.Core.Movies;

public class Movie: IEntity<int>
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description {  get; set; } = string.Empty;
    public bool IsReleased { get; set; }
    public DateTime ReleaseDate { get; set; }
    public List<Genre> Genres { get; set; } = new();
    public List<Comment> Comments { get; set; } = new();
}
