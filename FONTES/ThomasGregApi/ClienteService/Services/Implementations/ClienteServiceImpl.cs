using System.Collections.Generic;
using System.Threading.Tasks;
using ClienteService.Models;
using ClienteService.Services.Interfaces;
using ClienteService.Repositories.Interfaces;
using ClienteService.Validacoes;
using ClienteService.Exceptions;

namespace ClienteService.Services.Implementations
{
    public class ClienteServiceImpl : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteServiceImpl(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        private async Task<Cliente> GetClienteOrThrow(int id)
        {
            var cliente = await _clienteRepository.GetClienteById(id);
            if (cliente == null)
            {
                throw new EntityNotFoundException($"Cliente com o id {id} não foi encontrado.");
            }

            return cliente;
        }

        #region OPERAÇÕES DE SAIDA
        public async Task<ServiceResult<Cliente>> GetClienteById(int id)
        {
            var cliente = await _clienteRepository.GetClienteById(id);
            if (cliente == null)
            {
                return new ServiceResult<Cliente>
                {
                    ErrorMessage = $"Cliente com o id {id} não foi encontrado."
                };
            }

            return new ServiceResult<Cliente>
            {
                Result = cliente
            };
        }

        public async Task<IEnumerable<Cliente>> GetAllClientes()
        {
            return await _clienteRepository.GetAllClientes();
        }
        #endregion

        #region OPERAÇÕES DE ENTRADA
        public async Task<Cliente> CreateCliente(Cliente cliente)
        {
            ValidationHelper.ValidateEmail(cliente.Email);
            ValidationHelper.ValidateNome(cliente.Nome);

            return await _clienteRepository.AddCliente(cliente);
        }

        public async Task DeleteCliente(int id)
        {
            var cliente = await GetClienteOrThrow(id);
            await _clienteRepository.DeleteCliente(id);
        }
        public async Task UpdateCliente(Cliente cliente)
        {
            ValidationHelper.ValidateEmail(cliente.Email);
            ValidationHelper.ValidateNome(cliente.Nome);
            ValidationHelper.ValidateClienteId(cliente.Id);

            var clienteexiste = await GetClienteOrThrow(cliente.Id);

            await _clienteRepository.UpdateCliente(cliente);
        }
        #endregion
    }
}
