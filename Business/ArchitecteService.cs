using Microsoft.EntityFrameworkCore;
using ProjetStage.DAO;
using StageApp.DAO;
using StageApp.Models;

namespace StageApp.Business
{
    public class ArchitecteService : IArchitecteService
    {
        private readonly IRepository<Architecte> _repository;
        private readonly BdStageContext _context;

        public ArchitecteService(IRepository<Architecte> repository, BdStageContext context)
        {
            _repository = repository;
            _context = context;
        }
        public Task Add(Architecte entity)
        {
            var adresseExists =  _context.Adresses.AnyAsync(a => a.IdAdresse == entity.IdAdresse);
            if (adresseExists ==null)
            {
                throw new Exception("Invalid Adresse ID. No matching record found.");
            }

            // Check if related Contact exists
            var contactExists =  _context.Contacts.AnyAsync(c => c.IdContact == entity.IdContact);
            if (contactExists == null)
            {
                throw new Exception("Invalid Contact ID. No matching record found.");
            }
            return _repository.Add(entity);
        }

        public Task Delete(int id)
        {
            return _repository.Delete(id);
        }

        public IEnumerable<Architecte> GetAll()
        {
            return _repository.GetAll();
        }

        public Task<Architecte> GetById(int id)
        {Console.WriteLine(_repository.GetById(id));
            return _repository.GetById(id);
        }

        public Task Update(int id)
        {

            return _repository.Update(id);

        }
    }
}
