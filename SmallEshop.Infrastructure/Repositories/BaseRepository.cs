using Microsoft.EntityFrameworkCore;
using SmallEshop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmallEshop.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>  where T : class
    {
        private readonly ApplicationDbContext context;

        public BaseRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public virtual T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public virtual List<T> ListAll()
        {
            return context.Set<T>().ToList();
        }

        public virtual async Task<List<T>> ListAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public virtual List<T> ListWhere(Expression<Func<T,bool>> expression,int? skip=null,int? take=null)
        {
            //var predicate = expression.Compile();
            return context.Set<T>()
                        .Where(expression)
                        .Skip(skip??0)
                        .Take(take??int.MaxValue)
                        .ToList();
        }

        public virtual async Task<List<T>> ListWhereAsync(Expression<Func<T, bool>> expression, int? skip = null, int? take = null)
        {
            //var predicate = expression.Compile();
            var result = context.Set<T>()
                            .Where(expression)
                            .Skip(skip ?? 0)
                            .Take(take ?? int.MaxValue)
                            .AsQueryable();
            return await result.ToListAsync();
        }

        public virtual int Add(T entity)
        {
            context.Set<T>().Add(entity);
            return context.SaveChanges();
        }

        public virtual async Task<int> AddAsync(T entity)
        {
            context.Set<T>().Add(entity);
            return await context.SaveChangesAsync();
        }

        public virtual int Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            return context.SaveChanges();
        }

        public virtual async Task<int> UpdateAsync(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            return await context.SaveChangesAsync();
        }

        public virtual int Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            return context.SaveChanges();
        }

        public virtual async Task<int> DeleteAsync(T entity)
        {
            context.Set<T>().Remove(entity);
            return await context.SaveChangesAsync();
        }

        public virtual int DeleteWhere(Expression<Func<T,bool>> expression)
        {
            //var predicate = expression.Compile();
            var listOfEntitiesToDelete = context.Set<T>()
                                        .Where(expression);
            context.Set<T>().RemoveRange(listOfEntitiesToDelete);
            return context.SaveChanges();           
        }

        public virtual async Task<int> DeleteWhereAsync(Expression<Func<T, bool>> expression)
        {
            //var predicate = expression.Compile();
            var listOfEntitiesToDelete = context.Set<T>()
                                        .Where(expression);
            context.Set<T>().RemoveRange(listOfEntitiesToDelete);
            return await context.SaveChangesAsync();
        }

    }
}
