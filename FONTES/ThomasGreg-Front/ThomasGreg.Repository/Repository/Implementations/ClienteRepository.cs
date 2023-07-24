using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasGreg.Domain.Interfaces.Repository;
using ThomasGreg.Domain.Interfaces.Service;
using Newtonsoft.Json;
using ThomasGreg.Domain.Entities;

namespace ThomasGreg.Repository.Repository.Implementations
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IApiRepository _apiRepository;
        public ClienteRepository(IApiRepository apiRepository)
        {
            _apiRepository = apiRepository;
        }

        public async Task<Cliente> CreateCliente(Cliente cliente)
        {
            foreach (var item in cliente.Logradouros)
            {
                item.ClienteId = cliente.Id;
            }
            return await _apiRepository.AddClienteAsync(cliente);
        }

        public async Task<Cliente> UpdateCliente(Cliente cliente)
        {
            foreach (var item in cliente.Logradouros)
            {
                item.ClienteId = cliente.Id;
            }
            return await _apiRepository.UpdateClienteAsync(cliente);
        }

        public async Task<Cliente> GetClienteById(int id)
        {
            return await _apiRepository.GetClienteByIdAsync(id);
        }

        public async Task DeleteCliente(int id)
        {
            await _apiRepository.DeleteClienteAsync(id);
        }

        public async Task<IEnumerable<Cliente>> GetAllClientes()
        {
            return await _apiRepository.GetAllClientesAsync();
        }
    }

}
