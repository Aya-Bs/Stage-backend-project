using ProjetStage.DAO;
using StageApp.Models;

namespace ProjetStage.Business
{
    public class SalarieService : ISalarieService
    {
        private IRepository<Salarie> _repository;

        public SalarieService(IRepository<Salarie> repository)
        {
            _repository = repository;
        }

        public Task Add(Salarie entity)
        {
           return _repository.Add(entity);
        }

        public Task Delete(int id)
        {
            return (_repository.Delete(id));
        }

        public IEnumerable<Salarie> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Salarie>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<Salarie> GetById(int id)
        {
            return _repository.GetById(id);
        }

        public Task Update(int id)
        {
            return _repository.Update(id);
        }
    }
}
