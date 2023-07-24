using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasGreg.Domain.Entities;
using ThomasGreg.Domain.Interfaces.Repository;

namespace ThomasGreg.Repository.Repository.Implementations
{
    public class LogradouroRepository : ILogradouroRepository
    {
        private readonly IApiRepository _apiRepository;
        public LogradouroRepository(IApiRepository apiRepository)
        {
            _apiRepository = apiRepository;
        }
        public async Task<Logradouro> CreateLogradouro(Logradouro logradouro)
        {
            return await _apiRepository.AddLogradouroAsync(logradouro);
        }

        public async Task DeleteLogradouro(int id)
        {
            await _apiRepository.DeleteLogradouroAsync(id);
        }
    
        public async Task<IEnumerable<Logradouro>> GetAllLogradouros()
        {
            return await _apiRepository.GetAllLogradouroAsync();          
        }

        public async Task<Logradouro> GetByIdLogradouro(int id)
        {
            return await _apiRepository.GetLogradouroByIdAsync(id);
        }

        public async Task<Logradouro> UpdateLogradouro(Logradouro logradouro)
        {
            return await _apiRepository.UpdateLogradouroAsync(logradouro);
        }
    }
}
