using System.ComponentModel.DataAnnotations;

namespace EstacionamentoAPI.Models.DTO
{
    public class EstacionamentoDTO
    {
        [Required(ErrorMessage = "O preco inicial é obrigatório.")]
        [Range(0, int.MaxValue, ErrorMessage = "O preço inicial é inválido.")]
        public float PrecoInicial { get; set; }

        [Required(ErrorMessage = "O Preco por hora é obrigatório.")]
        [Range(0, int.MaxValue, ErrorMessage = "O preço por hora é inválido.")]
        public float PrecoHora { get; set; }
    }
}
