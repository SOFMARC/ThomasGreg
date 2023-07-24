using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasGreg.Domain.Entities;

namespace ThomasGreg.Domain.Interfaces.Repository
{
    public interface ILogradouroRepository
    {
        Task<Logradouro> CreateLogradouro(Logradouro logradouro);
        Task<Logradouro> UpdateLogradouro(Logradouro logradouro);
        Task<Logradouro> GetByIdLogradouro(int id);
        Task DeleteLogradouro(int id);
        Task<IEnumerable<Logradouro>> GetAllLogradouros();
    }
}
