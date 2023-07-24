using ClienteService.Models;

namespace ClienteService.Services.Interfaces
{
    public interface ILogradouroService
    {
        Task<Logradouro> CreateLogradouro(Logradouro logradouro);
        Task<Logradouro> UpdateLogradouro(Logradouro logradouro);
        Task<Logradouro> GetLogradouro(int id);
        Task DeleteLogradouro(int id);

        Task<IEnumerable<Logradouro>> GetAllLogradouros();
    }

}
