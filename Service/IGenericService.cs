using System.Linq.Expressions;

namespace User_Products_DashBoard_MVC.Service
{
    public interface IGenericService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task CreateItemAsync(T item);    
        void DeleteItem(int id);
        void UpdateItem(T item);
        Task<T> GetItemByIdAsync(int id);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllIncludingAsync(params Expression<Func<T, object>>[] includeProperties);
    }
}
