using Clientes.Api.DTOs;
using Clientes.Api.Models;
namespace Clientes.Api.Services
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteResponseDto>> GetAllAsync();
        Task<ClienteResponseDto?> GetByIdAsync(Guid id);
        Task<ClienteResponseDto> CreateAsync(ClienteCreateDto clienteDto);
        Task<bool> UpdateAsync(Guid id, ClienteUpdateDto clienteDto);
        Task<bool> DeleteAsync(Guid id);
    }
}
