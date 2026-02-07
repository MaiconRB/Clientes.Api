using Clientes.Api.Models;
namespace Clientes.Api.Services
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task<Cliente?> GetByIdAsync(Guid id);
        Task<Cliente> CreateAsync(Cliente cliente);
        Task<bool> UpdateAsync(Guid id, Cliente cliente);
        Task<bool> DeleteAsync(Guid id);
    }
}
