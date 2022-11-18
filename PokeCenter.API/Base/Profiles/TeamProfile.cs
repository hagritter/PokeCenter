using AutoMapper;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace PokeCenter.API.Base.Profiles
{
    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            CreateMap<Base.Entities.Team, Base.DTOs.TeamWithoutTrainersDto>();
            CreateMap<Base.Entities.Team, Base.DTOs.TeamDto>();
        }
    }
}
