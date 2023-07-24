using AutoMapper;
using AutoMapper.Execution;
using ClienteService.Data;
using ClienteService.DTOs;
using ClienteService.Exceptions;
using ClienteService.Models;
using ClienteService.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using ThomasGregApi.ClienteService.MapperProfiles;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ClienteService.Repositories.Implementations
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClienteDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly LogradouroRepository LogradouroRepository;

        public ClienteRepository(ClienteDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            LogradouroRepository = new LogradouroRepository(_dbContext);
            _mapper = mapper;
        }
        #region OPERAÇÕES DE SAIDA
        public async Task<Cliente> GetClienteById(int id)
        {
            var cliente = await _dbContext.Clientes
                                .Include(c => c.Logradouros)
                                .AsNoTracking()
                                .FirstOrDefaultAsync(c => c.Id == id);

            return cliente;
        }


        public async Task<IEnumerable<Cliente>> GetAllClientes()
        {
            var clientes = await _dbContext.Clientes
                                .Include(c => c.Logradouros)
                                .AsNoTracking()
                                .ToListAsync();

            return clientes;
        }
        #endregion

        #region OPERAÇÕES DE ENTRADA
        public async Task<Cliente> AddCliente(Cliente cliente)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                var paramNome = new SqlParameter("@Nome", cliente.Nome);
                var paramEmail = new SqlParameter("@Email", cliente.Email);             
                var paramLogotipo = new SqlParameter("@Logotipo", cliente.Logotipo);

                var outputParam = new SqlParameter("@Id", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };

                await _dbContext.Database.ExecuteSqlRawAsync("EXEC InsertCliente @Nome, @Email, @Logotipo, @Id OUTPUT", paramNome, paramEmail, paramLogotipo, outputParam);

                cliente.Id = (int)outputParam.Value;

                foreach (var l in cliente.Logradouros)
                {
                    l.ClienteId = cliente.Id;
                    var logradouro = await LogradouroRepository.Create(l, _dbContext);
                }

                await transaction.CommitAsync();

                return cliente;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();

                if (ex is SqlException sqlEx)
                {
                    int sqlErrorCode = sqlEx.Number;
                    if (sqlErrorCode == 2601)
                    {
                        throw new CustomException($"Cliente já cadastrado com o e-mail {cliente.Email}.", "DUPLICATE_EMAIL");
                    }
                }
                throw;
            }
        }

        public async Task UpdateCliente(Cliente cliente)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                var idParam = new SqlParameter("@Id", cliente.Id);
                var nomeParam = new SqlParameter("@Nome", cliente.Nome);
                var emailParam = new SqlParameter("@Email", cliente.Email);
                var logotipoParam = new SqlParameter("@Logotipo", cliente.Logotipo);

                await _dbContext.Database.ExecuteSqlRawAsync("EXEC UpdateCliente @Id, @Nome, @Email, @Logotipo", idParam, nomeParam, emailParam, logotipoParam);

              
                var existingLogradouros = await _dbContext.Logradouros
                                                          .Where(l => l.ClienteId == cliente.Id)
                                                          .ToListAsync();
                _dbContext.Logradouros.RemoveRange(existingLogradouros);
                await _dbContext.SaveChangesAsync();

                
                foreach (var l in cliente.Logradouros)
                {                  
                    await LogradouroRepository.Create(l, _dbContext);                  
                }
               
                await _dbContext.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch (DbUpdateException ex)
            {
                await transaction.RollbackAsync();

                if (ex.InnerException is SqlException sqlEx && sqlEx.Number == 2627)
                {
                    throw new CustomException($"Cliente já cadastrado com o e-mail {cliente.Email}.", "DUPLICATE_EMAIL");
                }

                throw;
            }
        }




        public async Task DeleteCliente(int id)
        {
            var idParam = new SqlParameter("@Id", id);

            await _dbContext.Database.ExecuteSqlRawAsync("EXEC DeleteCliente @Id", idParam);
        }

        #endregion
    }

}
