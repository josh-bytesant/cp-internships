using AutoMapper;
using Domain.Application.Create;
using Domain.Program.Create;

namespace Application.Helpers.Automapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<CreateProgramDTO, Domain.Program.Entities.Program>()
             .ForMember(dest => dest.id, opt => opt.MapFrom(src => Guid.NewGuid().ToString()))
             .ForMember(dest => dest.DateModified, opt => opt.MapFrom(src => DateTime.UtcNow))
             .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<CreateApplicationDTO, Domain.Application.Entities.Application>()
             .ForMember(dest => dest.id, opt => opt.MapFrom(src => Guid.NewGuid().ToString()))
             .ForMember(dest => dest.DateModified, opt => opt.MapFrom(src => DateTime.UtcNow))
             .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}
