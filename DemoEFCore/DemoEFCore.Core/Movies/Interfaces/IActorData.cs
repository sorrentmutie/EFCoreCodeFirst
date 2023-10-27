namespace DemoEFCore.Core.Movies.Interfaces;

public interface IActorData
{
  Task<List<Actor>?> GetActorsAsync();
  Task<Actor?> GetActorByIdAsync(int Id);
  Task CreateActorAsync(Actor actor);
  Task DeleteActorAsync(int Id);
  Task UpdateActorAsync(Actor actor);
}
