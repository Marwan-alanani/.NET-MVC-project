using System.Linq.Expressions;

namespace C43_G04_MVC03.Presentation.DAL.Repositories;

public interface IGenericRepository<TEnitity> where TEnitity : BaseEntity
{
    TEnitity? GetById(int id);
    IEnumerable<TEnitity> GetAll(bool withTracking = false);


    IEnumerable<TResult> GetAll<TResult>(Expression<Func<TEnitity, TResult>> selector,
        Expression<Func<TEnitity, bool>> predicate,
        params Expression<Func<TEnitity, object>>[] includes);

    // IQueryable<TEnitity> GetAllQueryable();
    void Add(TEnitity enitity);
    void Update(TEnitity entity);
    void Delete(TEnitity entity);
}