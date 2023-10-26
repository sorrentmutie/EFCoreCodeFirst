namespace DemoEFCore.Movies;

public class Movie: Entity<int>
{
    public string Title { get; set; } = string.Empty;
    public string Description {  get; set; } = string.Empty;
    public bool IsReleased { get; set; }
    public DateTime ReleaseDate { get; set; }
    public List<Genre> Genres { get; set; } = new();
    public List<Comment> Comments { get; set; } = new();
}
