using System.ComponentModel.DataAnnotations;

namespace EstacionamentoAPI.Models.DTO
{
    public class UserDTO
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
