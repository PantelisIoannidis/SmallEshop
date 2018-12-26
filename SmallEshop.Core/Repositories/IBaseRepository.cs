using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmallEshop.Core.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        int Add(T entity);
        Task<int> AddAsync(T entity);
        int Delete(T entity);
        Task<int> DeleteAsync(T entity);
        int DeleteWhere(Expression<Func<T, bool>> expression);
        Task<int> DeleteWhereAsync(Expression<Func<T, bool>> expression);
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        List<T> ListAll();
        Task<List<T>> ListAllAsync();
        List<T> ListWhere(Expression<Func<T, bool>> expression, int? skip = null, int? take = null);
        Task<List<T>> ListWhereAsync(Expression<Func<T, bool>> expression, int? skip = null, int? take = null);
        int Update(T entity);
        Task<int> UpdateAsync(T entity);
    }
}