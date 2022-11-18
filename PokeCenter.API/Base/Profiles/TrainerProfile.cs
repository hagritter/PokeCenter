using AutoMapper;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace PokeCenter.API.Base.Profiles
{
    public class TrainerProfile : Profile
    {
        public TrainerProfile()
        {
            CreateMap<Base.Entities.Trainer, Base.DTOs.TrainerDto>() ;
            CreateMap<Base.DTOs.TrainerNewDto, Base.Entities.Trainer>();
            CreateMap<Base.DTOs.TrainerUpdateDto, Base.Entities.Trainer>();
            CreateMap<Base.Entities.Trainer, Base.DTOs.TrainerUpdateDto>();
        }
    }
}
