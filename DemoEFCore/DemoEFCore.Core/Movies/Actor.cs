namespace DemoEFCore.Core.Movies;

public class Actor: IEntity<int>
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int Age { get; set; }
    public double Salary { get; set; }
}
