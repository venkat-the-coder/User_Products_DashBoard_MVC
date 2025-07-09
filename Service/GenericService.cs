using System.Linq.Expressions;
using User_Products_DashBoard_MVC.Repository;

namespace User_Products_DashBoard_MVC.Service
{
    public class GenericService<T> : IGenericService<T> where T : class
    {

        private readonly IGenericRepository<T> _repository;

        public GenericService(IGenericRepository<T> genericRepository)
        {
            this._repository = genericRepository;
        }
        public async Task CreateItemAsync(T item)
        {
            await _repository.AddAsync(item);
        }

        public async void DeleteItem(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            _repository.Remove(item);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _repository.FindAsync(predicate);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IEnumerable<T>> GetAllIncludingAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            return await _repository.GetAllIncludingAsync(includeProperties);
        }

        public async Task<T> GetItemByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public void UpdateItem(T item)
        {
            _repository.Update(item);
        }
    }

}
