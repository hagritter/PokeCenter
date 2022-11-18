using System.ComponentModel.DataAnnotations;

namespace PokeCenter.API.Base.DTOs
{
    public class TrainerNewDto
    {
        [Required(ErrorMessage = "You should provide a name value.")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        public string? Origin { get; set; }

        [MaxLength(200)]
        public string? Description { get; set; }
    }
}
