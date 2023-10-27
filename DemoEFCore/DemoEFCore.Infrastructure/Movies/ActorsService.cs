using DemoEFCore.Core.Movies;
using DemoEFCore.Core.Movies.Interfaces;
using DemoEFCore.Data.Movies;
using Microsoft.EntityFrameworkCore;

namespace DemoEFCore.Infrastructure.Movies;

public class ActorsService : IActorData
{
    private MoviesDbContext? moviesDbContext;

    public ActorsService(MoviesDbContext moviesDbContext)
    {
        this.moviesDbContext = moviesDbContext;
    }

    public async Task CreateActorAsync(Actor actor)
    {
        if (moviesDbContext != null)
        {
            moviesDbContext.Actors.Add(actor);
            await moviesDbContext.SaveChangesAsync();
        }
    }

    public async Task DeleteActorAsync(int Id)
    {
        if (moviesDbContext == null) return;
        var actor = await moviesDbContext.Actors.FindAsync(Id);
        if(actor != null)
        {
            moviesDbContext.Entry(actor).State = EntityState.Deleted;
            await moviesDbContext.SaveChangesAsync();
        }
    }

    public async Task<Actor?> GetActorByIdAsync(int id)
    {
        if (moviesDbContext == null) return null;
        return await moviesDbContext.Actors.FindAsync(id);
    }

    public async Task<List<Actor>?> GetActorsAsync()
    {
        if (moviesDbContext == null) return null;
        return await moviesDbContext.Actors.ToListAsync();
    }

    public async Task UpdateActorAsync(Actor actor)
    {
        if (moviesDbContext == null) return;
        var actorDb = await GetActorByIdAsync(actor.Id);
        if (actorDb == null) return;

        moviesDbContext.Entry(actor).State = EntityState.Modified;
       
        //actorDb.Name = actor.Name;
        //actorDb.Salary = actor.Salary;
        //actorDb.Age = actor.Age;
        await moviesDbContext.SaveChangesAsync();
    }
}
