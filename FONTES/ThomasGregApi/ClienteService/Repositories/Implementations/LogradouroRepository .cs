using ClienteService.Data;
using ClienteService.Models;
using ClienteService.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace ClienteService.Repositories.Implementations
{
    public class LogradouroRepository : ILogradouroRepository
    {
        private readonly ClienteDbContext _context;

        public LogradouroRepository(ClienteDbContext context)
        {
            _context = context;
        }
        #region OPERAÇÕES ENTRADA
        public async Task<Logradouro> Create(Logradouro logradouro, DbContext context)
        {
            var paramNome = new SqlParameter("@Nome", logradouro.Nome);
            var paramIdCliente = new SqlParameter("@ClienteId", logradouro.ClienteId);

            var outputParam = new SqlParameter("@Id", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            await context.Database.ExecuteSqlRawAsync("EXEC InsertLogradouro @Nome, @ClienteId, @Id OUTPUT", paramNome, paramIdCliente, outputParam);

            logradouro.Id = (int)outputParam.Value;

            return logradouro;
        }

        public async Task<Logradouro> Create(Logradouro logradouro)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var paramNome = new SqlParameter("@Nome", logradouro.Nome);
                var paramIdCliente = new SqlParameter("@ClienteId", logradouro.ClienteId);

                var outputParam = new SqlParameter("@Id", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };

                await _context.Database.ExecuteSqlRawAsync("EXEC InsertLogradouro @Nome, @ClienteId, @Id OUTPUT", paramNome, paramIdCliente, outputParam);

                logradouro.Id = (int)outputParam.Value;

                await transaction.CommitAsync();

                return logradouro;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }

        }
     

        public async Task<Logradouro> Update(Logradouro logradouro)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var parameters = new[] {
                new SqlParameter("@Id", logradouro.Id),
                new SqlParameter("@Nome", logradouro.Nome)};

                await _context.Database.ExecuteSqlRawAsync("EXEC UpdateLogradouro @Id, @Nome", parameters);

                await transaction.CommitAsync();
                return logradouro;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }

        }

        public async Task<Logradouro> Update(Logradouro logradouro, DbContext context)
        {
            var parameters = new[] {
                new SqlParameter("@Id", logradouro.Id),
                new SqlParameter("@Nome", logradouro.Nome)};

            await context.Database.ExecuteSqlRawAsync("EXEC UpdateLogradouro @Id, @Nome", parameters);
            return logradouro;
        }

        public async Task Delete(int id)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var parameter = new SqlParameter("@id", id);
                await _context.Database.ExecuteSqlRawAsync("EXEC DeleteLogradouro @id", parameter);

                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }

        }
        #endregion

        #region OPERAÇÕES DE SAIDA
        public async Task<Logradouro> Get(int id)
        {
            return await _context.Logradouros.FindAsync(id);
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Logradouros.AnyAsync(l => l.Id == id);
        }

        public async Task<IEnumerable<Logradouro>> GetAllLogradouros()
        {
            return await _context.Logradouros.ToListAsync();
        }
        #endregion
    }

}
