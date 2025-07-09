using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using User_Products_DashBoard_MVC.Data;

namespace User_Products_DashBoard_MVC.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private readonly CustomContext _appContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(CustomContext appContext)
        {
            this._appContext = appContext;
            this._dbSet = appContext.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await this._dbSet.AddAsync(entity);
            await SaveChangesAsync();
        }
        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await this._dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async void Remove(T entity)
        {
            _dbSet.Remove(entity);
            await SaveChangesAsync();
        }

        public async void Update(T entity)
        {
            _dbSet.Update(entity);
            await SaveChangesAsync();
        }


        public async Task<int> SaveChangesAsync()
        {
            return await _appContext.SaveChangesAsync();
        }
    }
}
