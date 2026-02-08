using System.ComponentModel.DataAnnotations;

namespace Clientes.Api.DTOs
{
    public class ClienteCreateDto
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email deve ser um endereço de email válido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "O documento é obrigatório.")]
        public string Documento { get; set; } = string.Empty;
    }
}
