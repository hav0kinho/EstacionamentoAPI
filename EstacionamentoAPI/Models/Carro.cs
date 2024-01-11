using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EstacionamentoAPI.Models
{
    public class Carro
    {
        [Required(ErrorMessage = "O ID é obrigatório.")]
        [Range(0, int.MaxValue, ErrorMessage = "O ID é inválido.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "A Marca é obrigatória.")]
        [MaxLength(20, ErrorMessage = "A Marca deve ter no máximo 20 caractéres.")]
        public string? Marca { get; set; }

        [Required(ErrorMessage = "A Cor é obrigatória.")]
        [MaxLength(20, ErrorMessage = "A Cor deve ter no máximo 20 caractéres")]
        public string? Cor { get; set; }

        [Required(ErrorMessage = "A Placa do carro deve ser fornecida")]
        [StringLength(7, ErrorMessage = "A Placa deve ter exatamente 7 caractéres")]
        public string? Placa { get; set; }
        public int? EstacionamentoId { get; set; }

        [JsonIgnore]
        public Estacionamento? Estacionamento { get; set; }
    }
}
