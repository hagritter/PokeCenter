using System.ComponentModel.DataAnnotations;

namespace PokeCenter.API.Base.DTOs
{
    public class TrainerUpdateDto
    {
        [Required(ErrorMessage = "You should provide a name value.")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(200)]
        public string? Description { get; set; }
    }
}
