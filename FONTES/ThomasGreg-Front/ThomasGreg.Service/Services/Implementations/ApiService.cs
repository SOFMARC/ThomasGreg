using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasGreg.Domain.Entities;
using ThomasGreg.Domain.Interfaces.Repository;
using ThomasGreg.Domain.Interfaces.Service;

namespace ThomasGreg.Service.Services.Implementations
{
    public class ApiService : IApiService
    {
        private readonly IApiRepository _apiRepository;

        public ApiService(IApiRepository apiRepository)
        {
            _apiRepository = apiRepository;
        }

        public async Task<Cliente> AddClienteAsync(Cliente cliente)
        {
            return await _apiRepository.AddClienteAsync(cliente);
        }

        public async Task<Logradouro> AddLogradouroAsync(Logradouro logradouro)
        {
            return await _apiRepository.AddLogradouroAsync(logradouro);
        }

        public async Task DeleteClienteAsync(int id)
        {
            await _apiRepository.DeleteClienteAsync(id);
        }

        public async Task DeleteLogradouroAsync(int id)
        {
            await _apiRepository.DeleteLogradouroAsync(id);
        }

        public async Task<IEnumerable<Cliente>> GetAllClientes()
        {
            return await _apiRepository.GetAllClientesAsync();
        }

        public async Task<IEnumerable<Logradouro>> GetAlLogradouro()
        {
            return await _apiRepository.GetAllLogradouroAsync();
        }

        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            return await _apiRepository.GetClienteByIdAsync(id);
        }

        public async Task<Logradouro> GetLogradouroByIdAsync(int id)
        {
            return await _apiRepository.GetLogradouroByIdAsync(id);
        }

        public async Task<Cliente> UpdateClienteAsync(Cliente cliente)
        {
            return await _apiRepository.UpdateClienteAsync(cliente);
        }

        public async Task<Logradouro> UpdateLogradouroAsync(Logradouro logradouro)
        {
            return await _apiRepository.UpdateLogradouroAsync(logradouro);
        }
    }

}
