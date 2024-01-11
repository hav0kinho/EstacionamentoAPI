using System.ComponentModel.DataAnnotations;

namespace EstacionamentoAPI.Models
{
    public class Estacionamento
    {
        [Required(ErrorMessage = "O ID é obrigatório.")]
        [Range(0, int.MaxValue, ErrorMessage = "O ID é inválido.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O endereço é obrigatório.")]
        public string? Endereco {get; set;}

        public List<Carro> Veiculos { get; set; } = new List<Carro>();
    }
}
