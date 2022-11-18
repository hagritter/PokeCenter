using PokeCenter.API.Base.Entities;

namespace PokeCenter.API.Base.DTOs
{
    public class TrainerDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string? Origin { get; set; }
        public string? Description { get; set; }
        //public Team? Team { get; set; }
        //public int TeamId { get; set; }

    }
}
