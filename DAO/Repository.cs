
using Microsoft.EntityFrameworkCore;
using StageApp.DAO;

namespace ProjetStage.DAO
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly BdStageContext _bdStageContext;
        private readonly DbSet<T> _dbSet;
        public Repository(BdStageContext bdStageContext)
        {
            _bdStageContext = bdStageContext ?? throw new ArgumentNullException(nameof(bdStageContext));
            _dbSet = _bdStageContext.Set<T>();


        }
        public async Task Add(T entity)
        {
            _bdStageContext.Set<T>().AddAsync(entity);
            await _bdStageContext.SaveChangesAsync();
        }

        public Task Delete(int id)
        {
            var entity =  _bdStageContext.Find<T>(id);
            if (entity != null)
            {
                _bdStageContext.Remove(entity);
                _bdStageContext.SaveChanges();
            }
            else
            {
                return Task.FromException(new Exception("Entity not found"));
            }
            return Task.CompletedTask;

        }

        public IEnumerable<T> GetAll()
        {
            return _bdStageContext.Set<T>().ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _bdStageContext.Set<T>().ToListAsync();
            
        }

        public async Task<T> GetById(int id)
        {
            Console.WriteLine(_bdStageContext.FindAsync<T>(id));
            return await _bdStageContext.FindAsync<T>(id);


        }


        public async Task Update(int id)
        {
            var entity = await _bdStageContext.FindAsync<T>(id);
            if (entity != null)
            {
                _bdStageContext.Update(entity);
                await _bdStageContext.SaveChangesAsync();
            }
        }

    }
}
