using Microsoft.EntityFrameworkCore;
using ClienteService.Models;
using ClienteService.DTOs;

namespace ClienteService.Data
{
    public class ClienteDbContext : DbContext
    {
        public ClienteDbContext(DbContextOptions<ClienteDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Logradouro> Logradouros { get; set; }
        public DbSet<ClienteLogradouroResultDTO> ClienteLogradouroResultDTOs { get; set; }

    }
}
