using ClienteService.Models;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;

namespace ClienteService.Repositories.Interfaces
{
    public interface ILogradouroRepository
    {
        Task<Logradouro> Create(Logradouro logradouro);
        Task<Logradouro> Create(Logradouro logradouro, DbContext context);

        Task<Logradouro> Update(Logradouro logradouro);
        Task<Logradouro> Update(Logradouro logradouro, DbContext context);        
        Task<Logradouro> Get(int id);
        Task Delete(int id);
        Task<IEnumerable<Logradouro>> GetAllLogradouros();
        Task<bool> Exists(int id);

    }
}
