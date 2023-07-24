using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasGreg.Domain.Entities;

namespace ThomasGreg.Domain.Interfaces.Service
{
    public interface IClienteService
    {
        Task<Cliente> GetClienteById(int id);
        Task<IEnumerable<Cliente>> GetAllClientes();
        Task<Cliente> CreateCliente(Cliente cliente);
        Task DeleteCliente(int id);
        Task UpdateCliente(Cliente cliente);
    }


}
