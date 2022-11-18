namespace PokeCenter.API.Base.DTOs
{
    public class TeamDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string? Description { get; set; }
        public int NumberTrainers
        {
            get
            {
                return Trainers.Count;
            }
        }

        public ICollection<TrainerDto> Trainers { get; set; }
            = new List<TrainerDto>();
    }
}
