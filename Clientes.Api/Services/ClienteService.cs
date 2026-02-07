using Clientes.Api.Models;
using Clientes.Api.Repositories;

namespace Clientes.Api.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task<Cliente?> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public async Task<Cliente> CreateAsync(Cliente cliente)
        {
            cliente.Id = Guid.NewGuid();
            cliente.DataCadastro = DateTime.UtcNow;
            cliente.Ativo = true;

            await _repository.AddAsync(cliente);
            return cliente;
        }
        public async Task<bool> UpdateAsync(Guid id, Cliente cliente)
        {
            var existente = await _repository.GetByIdAsync(id);
            if (existente == null) return false;

            existente.Nome = cliente.Nome;
            existente.Email = cliente.Email;
            existente.Documento = cliente.Documento;

            await _repository.UpdateAsync(existente);
            return true;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var existente = await _repository.GetByIdAsync(id);
            if (existente == null) return false;

            existente.Ativo = false; //delete simple, apenas inativa o cliente
            await _repository.UpdateAsync(existente);
            return true;
        }
    }
}