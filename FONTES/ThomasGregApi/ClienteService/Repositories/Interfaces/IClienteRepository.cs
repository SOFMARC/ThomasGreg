using System.Threading.Tasks;
using ClienteService.Models;

namespace ClienteService.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente> GetClienteById(int id);
        Task<IEnumerable<Cliente>> GetAllClientes();
        Task<Cliente> AddCliente(Cliente cliente);
        Task UpdateCliente(Cliente cliente);
        Task DeleteCliente(int id);
    }
}
