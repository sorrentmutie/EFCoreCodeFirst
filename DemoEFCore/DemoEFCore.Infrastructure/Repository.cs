using DemoEFCore.Core.Movies;
using DemoEFCore.Core.Movies.Interfaces;
using DemoEFCore.Data.Movies;
using Microsoft.EntityFrameworkCore;

namespace DemoEFCore.Infrastructure;

public class Repository<TEntity, TKey> : 
    IRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey> ,new()
{
   // private MoviesDbContext? moviesDbContext;
   private DbContext dbContext;
    private readonly DbSet<TEntity> dbSet;

    public Repository( DbContext dbContext) //MoviesDbContext moviesDbContext)
    {
        this.dbContext = dbContext;
        dbSet = dbContext.Set<TEntity>();
        //this.moviesDbContext = moviesDbContext;
        //dbSet = moviesDbContext.Set<TEntity>();
    }



    public async Task CreateAsync(TEntity item)
    {
        if (dbContext == null) return;
        dbSet.Add(item);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(TKey Id)
    {
        var entity = new TEntity();
        entity.Id = Id;
        if(dbContext != null)
        {
           // moviesDbContext.Entry(entity).State = EntityState.Deleted;
           dbSet.Remove(entity);
            await dbContext.SaveChangesAsync();
        }        
    }

    public IQueryable<TEntity>? Get()
    {
        return dbSet;
    }

    public async Task<TEntity?> GetByIdAsync(TKey Id)
    {
        var entity = await dbSet.FindAsync(Id);
        if(entity == null || dbContext == null){ 
            return null; 
        } else
        {
            dbContext.Entry(entity).State = EntityState.Detached;
            return entity;
        }

    }

    public async Task UpdateAsync(TEntity item)
    {
        if(dbContext == null) return;
        dbContext.Entry(item).State = EntityState.Modified;
        await dbContext.SaveChangesAsync();
    }
}
