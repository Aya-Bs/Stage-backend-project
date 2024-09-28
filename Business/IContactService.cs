using StageApp.Models;

namespace StageApp.Business
{
    public interface IContactService : IService<Contact>
    {
        Task<Contact> Get(int id);
    }
}