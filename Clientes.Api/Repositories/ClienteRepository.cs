using Clientes.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Clientes.Api.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly Data.AppDbContext _context;
        public ClienteRepository(Data.AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _context.Clientes.Where(c => c.Ativo).ToListAsync();
        }
        public async Task<Cliente?> GetByIdAsync(Guid id)
        {
            return await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id && c.Ativo);
        }
        public async Task AddAsync(Models.Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Models.Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }
    }
}
