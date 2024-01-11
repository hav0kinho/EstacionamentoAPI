using System.ComponentModel.DataAnnotations;

namespace EstacionamentoAPI.Models
{
    public class Estacionamento
    {
        [Required(ErrorMessage = "O ID é obrigatório.")]
        [Range(0, int.MaxValue, ErrorMessage = "O ID é inválido.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O preco inicial é obrigatório.")]
        [Range(0, int.MaxValue, ErrorMessage = "O preço inicial é inválido.")]
        public float PrecoInicial { get; set; }

        [Required(ErrorMessage = "O Preco por hora é obrigatório.")]
        [Range(0, int.MaxValue, ErrorMessage = "O preço por hora é inválido.")]
        public float PrecoHora { get; set; }

        public List<Carro> Veiculos { get; set; } = new List<Carro>();
    }
}
