using ProjetStage.DAO;
using StageApp.DTO;
using StageApp.Models;

namespace StageApp.Business
{
    public class AdresseService : IAdresseService
    {
        private readonly IRepository<Adresse> _repository;

        public AdresseService(IRepository<Adresse> repository)
        {
            _repository = repository;
        }
        public Task Add(Adresse entity)
        {
            return _repository.Add(entity);
        }

        public Task Delete(int id)
        {
            return _repository.Delete(id);
        }

        public IEnumerable<Adresse> GetAll()
        {
            return _repository.GetAll();
        }

        

        public Task<Adresse> GetById(int id)
        {
            Console.WriteLine(_repository.GetById(id));
            return _repository.GetById(id);
        }

        public Task Update(int id)
        {
            return _repository.Update(id);
        }
        public async Task<bool> Update(int id, AdresseDto dto)
        {
            var adresse = await _repository.GetById(id);

            if (adresse == null)
            {
                return false;
            }
            //adresse = new Adresse();

            // Update the entity fields with the values from dto
            adresse.Adresse1 = dto.Adresse1;
            adresse.CodePostal = dto.CodePostal;
            adresse.Ville = dto.Ville;

            _repository.Update(adresse.IdAdresse);
            return true;
        }

    }
}
