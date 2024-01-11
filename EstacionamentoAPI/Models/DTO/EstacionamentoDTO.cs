using System.ComponentModel.DataAnnotations;

namespace EstacionamentoAPI.Models.DTO
{
    public class EstacionamentoDTO
    {
        [Required(ErrorMessage = "O endereço é obrigatório.")]
        public string? Endereco {get; set;}
    }
}
