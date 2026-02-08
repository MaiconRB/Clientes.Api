using Clientes.Api.Models;
using Clientes.Api.Repositories;
using Clientes.Api.DTOs;

namespace Clientes.Api.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<ClienteResponseDto>> GetAllAsync()
        {
            var clientes = await _repository.GetAllAsync();
            return clientes.Select(c => new ClienteResponseDto
            {
                Id = c.Id,
                Nome = c.Nome,
                Email = c.Email,
                Documento = c.Documento
            });
        }
        public async Task<ClienteResponseDto?> GetByIdAsync(Guid id)
        {
            var cliente = await _repository.GetByIdAsync(id);
            if (cliente == null) return null;
            return new ClienteResponseDto
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Documento = cliente.Documento
            };
        }
        public async Task<ClienteResponseDto> CreateAsync(ClienteCreateDto clienteDto)
        {
            var cliente = new Cliente
            {
                Id = Guid.NewGuid(),
                Nome = clienteDto.Nome,
                Email = clienteDto.Email,
                Documento = clienteDto.Documento,
                DataCadastro = DateTime.UtcNow,
                Ativo = true
            };

            await _repository.AddAsync(cliente);

            return new ClienteResponseDto
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Documento = cliente.Documento
            };
        }
        public async Task<bool> UpdateAsync(Guid id, ClienteUpdateDto clienteDto)
        {
            var existente = await _repository.GetByIdAsync(id);
            if (existente == null) return false;

            existente.Nome = clienteDto.Nome;
            existente.Email = clienteDto.Email;
            existente.Documento = clienteDto.Documento;

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