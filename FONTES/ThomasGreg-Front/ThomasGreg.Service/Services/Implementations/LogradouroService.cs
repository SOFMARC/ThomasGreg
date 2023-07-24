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
    public class LogradouroService : ILogradouroService
    {
        private readonly ILogradouroRepository _logradouroRepository;

        public LogradouroService(ILogradouroRepository logradouroRepository)
        {
            _logradouroRepository = logradouroRepository;
        }

        public Task<Logradouro> UpdateLogradouro(Logradouro logradouro)
        {
            var LogradouroAtualizado = _logradouroRepository.UpdateLogradouro(logradouro);

            return LogradouroAtualizado;
        }

        public Task<Logradouro> CreateLogradouro(Logradouro logradouro)
        {
            var novoLogradouro = _logradouroRepository.CreateLogradouro(logradouro);

            return novoLogradouro;
        }

        public async Task DeleteLogradouro(int id)
        {
            await _logradouroRepository.DeleteLogradouro(id);
        }

        public Task<Logradouro> GetByIdLogradouro(int id)
        {
            var logradouro = _logradouroRepository.GetByIdLogradouro(id);

            return logradouro;
        }

        public async Task<IEnumerable<Logradouro>> GetAllLogradouros()
        {
            return await _logradouroRepository.GetAllLogradouros();
        }
    }
}
