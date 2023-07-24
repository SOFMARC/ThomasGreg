using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasGreg.Domain.Entities;

namespace ThomasGreg.Domain.Interfaces.Service
{
    public interface ILogradouroService
    {
        Task<Logradouro> CreateLogradouro(Logradouro logradouro);
        Task<Logradouro> UpdateLogradouro(Logradouro logradouro);
        Task<Logradouro> GetByIdLogradouro(int id);
        Task DeleteLogradouro(int id);
        Task<IEnumerable<Logradouro>> GetAllLogradouros();
    }
}
