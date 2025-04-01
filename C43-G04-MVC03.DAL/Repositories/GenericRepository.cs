using System.Linq.Expressions;

namespace C43_G04_MVC03.Presentation.DAL.Repositories;

public class GenericRepository<TEntity>(ApplicationDbContext context) : IGenericRepository<TEntity> where TEntity : 
    BaseEntity
{
    
    protected readonly ApplicationDbContext _context = context; 
    
    // Get
    public TEntity? GetById(int id)
    {
        return _context.Set<TEntity>().Find(id);
    }

    // Get All
    public IEnumerable<TEntity> GetAll(bool withTracking = false)
    {
        return (withTracking ? _context.Set<TEntity>() : _context.Set<TEntity>().AsNoTracking())
            .Where(e => !e.IsDeleted)
            .ToList();
    }

    public IEnumerable<TResult> GetAll<TResult>(Expression<Func<TEntity, TResult>> selector, 
        Expression<Func<TEntity, bool>> predicate,
        params Expression<Func<TEntity, object>>[] includes)
    {
        IQueryable<TEntity> query = _context.Set<TEntity>().AsNoTracking()
            .Where(predicate);
        
        foreach (var include in includes)
        {
            query.Include(include);
        }
        
        return query
        .Select(selector)
        .ToList();
    }


    // public IQueryable<TEntity> GetAllQueryable()
    // {
    //     return _context.Set<TEntity>().AsNoTracking().Where(e => !e.IsDeleted);
    // }

    // Add
    public void Add(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
    }
    
    // Update
    public void Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
    }
    
    // Delete
    public void Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }
}