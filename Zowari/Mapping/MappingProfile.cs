using AutoMapper;
using Domain.Boundary.Requests;
using Domain.Entities.Identity;

namespace Zowari.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserRegistrationRequest, User>()
            .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.EmailAddress));
    }
}