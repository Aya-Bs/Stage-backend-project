using StageApp.DTO;
using StageApp.Models;

namespace StageApp.Business
{
    public interface IAdresseService : IService<Adresse>
    {
        Task<bool> Update(int id, AdresseDto dto);

    }
}
