using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasGreg.Domain.Entities;
using ThomasGreg.Domain.Interfaces.Repository;
using ThomasGreg.Domain.Interfaces.Service;
using ThomasGreg.Repository.Repository.Implementations;

namespace ThomasGreg.Service.Services.Implementations
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<Cliente>> GetAllClientes()
        {
            return await _clienteRepository.GetAllClientes();
        }

        public Task<Cliente> GetClienteById(int id)
        {
            var cliente = _clienteRepository.GetClienteById(id);

            return cliente;
        }

        public Task<Cliente> CreateCliente(Cliente cliente)
        {
            var novoCliente = _clienteRepository.CreateCliente(cliente);

            return novoCliente;
        }

        public async Task DeleteCliente(int id)
        {
            await _clienteRepository.DeleteCliente(id);
        }

        public Task UpdateCliente(Cliente cliente)
        {
            var clienteAtualizado = _clienteRepository.UpdateCliente(cliente);

            return clienteAtualizado;
        }
    }


}
