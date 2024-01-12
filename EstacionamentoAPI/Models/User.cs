using System.ComponentModel.DataAnnotations;

namespace EstacionamentoAPI.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string[]? Roles { get; set; }
    }
}
