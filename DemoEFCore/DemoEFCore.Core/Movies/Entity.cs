namespace DemoEFCore.Core.Movies;

public class Entity<T>
{
    public T? Id { get; set; }
}

public interface IEntity<TKey>
{
    public TKey? Id { get; set; }
}
