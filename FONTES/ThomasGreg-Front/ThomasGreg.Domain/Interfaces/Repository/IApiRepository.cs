using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasGreg.Domain.Entities;

namespace ThomasGreg.Domain.Interfaces.Repository
{
    public interface IApiRepository
    {
        Task<Cliente> GetClienteByIdAsync(int id);
        Task<Cliente> AddClienteAsync(Cliente cliente);
        Task<Cliente> UpdateClienteAsync(Cliente cliente);
        Task DeleteClienteAsync(int id);

        Task<IEnumerable<Cliente>> GetAllClientesAsync();

        Task<Logradouro> GetLogradouroByIdAsync(int id);
        Task<Logradouro> AddLogradouroAsync(Logradouro Logradouro);
        Task<Logradouro> UpdateLogradouroAsync(Logradouro Logradouro);
        Task DeleteLogradouroAsync(int id);
        Task<IEnumerable<Logradouro>> GetAllLogradouroAsync();

    }
}
