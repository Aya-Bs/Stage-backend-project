using ProjetStage.DAO;
using StageApp.Models;

namespace StageApp.Business
{
    public class ContactService : IContactService
    {
        private readonly IRepository<Contact> _repository;

        public ContactService(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public Task Add(Contact entity)
        {
            
                return _repository.Add(entity);
           
        }

        public Task Delete(int id)
        {
            return _repository.Delete(id);
        }

        public async Task<Contact> Get(int id)
        {
            Console.WriteLine(_repository.GetById(id));
            return await _repository.GetById(id);
        }

        public IEnumerable<Contact> GetAll()
        {
            return _repository.GetAll();
        }

        public  Task<Contact> GetById(int id)
        {
            return _repository.GetById(id);

        }

        public Task Update(int id)
        {
            return _repository.Update(id);
        }
    }
}
