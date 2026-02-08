using System.ComponentModel.DataAnnotations;

namespace Clientes.Api.DTOs
{
    public class ClienteUpdateDto
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo Email deve ser um endereço de email válido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Documento é obrigatório.")]
        public string Documento { get; set; } = string.Empty;
    }
}
