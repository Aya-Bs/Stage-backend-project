using ProjetStage.DAO;
using StageApp.Models;

namespace StageApp.Business
{
    public class CandidatureService : ICandidatureService
    {
        private IRepository<Candidature> _repository;
        public CandidatureService(IRepository<Candidature> repository)
        {
            _repository = repository;
        }

        public Task Add(Candidature entity)
        {
            return _repository.Add(entity);
            
        }

        public Task Delete(int id)
        {
            return _repository.Delete(id);
        }

       
        public Task<Candidature> GetById(int id)
        {
            Console.WriteLine(_repository.GetById(id));
            return _repository.GetById(id);
        }

        public Task Update(int id)
        {
            return _repository.Update(id);
        }
        public IEnumerable<Candidature> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
