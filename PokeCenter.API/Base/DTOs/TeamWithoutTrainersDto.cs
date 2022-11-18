namespace PokeCenter.API.Base.DTOs
{
    public class TeamWithoutTrainersDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string? Description { get; set; }
    }
}
