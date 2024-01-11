using System.ComponentModel.DataAnnotations;

namespace EstacionamentoAPI.Models.DTO
{
    public class CarroDTO
    {
        [Required(ErrorMessage = "A Marca é obrigatória.")]
        [MaxLength(20, ErrorMessage = "A Marca deve ter no máximo 20 caractéres.")]
        public string? Marca { get; set; }

        [Required(ErrorMessage = "A Cor é obrigatória.")]
        [MaxLength(20, ErrorMessage = "A Cor deve ter no máximo 20 caractéres")]
        public string? Cor { get; set; }

        [Required(ErrorMessage = "A Placa do carro deve ser fornecida")]
        [StringLength(7, MinimumLength = 7, ErrorMessage = "A Placa deve ter exatamente 7 caracteres")]
        public string? Placa { get; set; }
    }
}
