﻿using System.Linq.Expressions;

namespace User_Products_DashBoard_MVC.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();

        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task Remove(T entity);
        Task Update(T entity);

        Task<IEnumerable<T>> GetAllIncludingAsync(params Expression<Func<T, object>>[] includeProperties);

        Task<int> SaveChangesAsync();
    }

}
