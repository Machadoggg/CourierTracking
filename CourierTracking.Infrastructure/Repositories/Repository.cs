using Microsoft.EntityFrameworkCore;
using CourierTracking.Domain.Interfaces;
using CourierTracking.Domain.Entities;
using CourierTracking.Application.Interfaces;

namespace CourierTracking.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _dbContext;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> GetByIdAsync(int id) => await _dbContext.Set<T>().FindAsync(id);
        public async Task<IEnumerable<T>> GetAllAsync() => await _dbContext.Set<T>().ToListAsync();
        public async Task AddAsync(T entity) => await _dbContext.Set<T>().AddAsync(entity);
        public async Task UpdateAsync(T entity) => _dbContext.Set<T>().Update(entity);
        public async Task DeleteAsync(T entity) => _dbContext.Set<T>().Remove(entity);
    }

    

    
}

