using System.Collections.Generic;
using System.Threading.Tasks;
using ClienteService.Models;
using ClienteService.Repositories.Interfaces;

namespace ClienteService.Services.Interfaces
{
    public interface IClienteService
    {
        Task<ServiceResult<Cliente>> GetClienteById(int id);
        Task<IEnumerable<Cliente>> GetAllClientes();
        Task<Cliente> CreateCliente(Cliente cliente);
        Task DeleteCliente(int id);
        Task UpdateCliente(Cliente cliente);      
    }
}
