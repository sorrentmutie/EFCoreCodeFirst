namespace DemoEFCore.Movies;

public class Actor: Entity<int>
{
    public string Name { get; set; } = "";
    public int Age { get; set; }
    public double Salary { get; set; }
}
