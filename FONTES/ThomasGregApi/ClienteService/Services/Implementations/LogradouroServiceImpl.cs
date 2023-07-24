using ClienteService.Models;
using ClienteService.Repositories.Interfaces;
using ClienteService.Services.Interfaces;

namespace ClienteService.Services.Implementations
{
    public class LogradouroServiceImpl : ILogradouroService
    {
        private readonly ILogradouroRepository _logradouroRepository;

        public LogradouroServiceImpl(ILogradouroRepository logradouroRepository)
        {
            _logradouroRepository = logradouroRepository;
        }

        public async Task<Logradouro> CreateLogradouro(Logradouro logradouro)
        {
            return await _logradouroRepository.Create(logradouro);
        }

        public async Task<Logradouro> UpdateLogradouro(Logradouro logradouro)
        {
            return await _logradouroRepository.Update(logradouro);
        }

        public async Task<Logradouro> GetLogradouro(int id)
        {
            return await _logradouroRepository.Get(id);
        }

        public async Task DeleteLogradouro(int id)
        {
            await _logradouroRepository.Delete(id);
        }

        public async Task<IEnumerable<Logradouro>> GetAllLogradouros()
        {
            return await _logradouroRepository.GetAllLogradouros();
        }
    }


}
