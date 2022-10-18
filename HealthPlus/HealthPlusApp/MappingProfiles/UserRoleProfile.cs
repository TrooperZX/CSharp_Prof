using HealthPlus.DataBase.Entities;
using HealthPlus.Core.DataTransferObjects;
using HealthPlusApp.Models;
using AutoMapper;

namespace HealthPlusApp.MappingProfiles
{
    public class UserRoleProfile : Profile
    {
        public UserRoleProfile()
        {
            CreateMap<UserRole, UserRoleDto>()
                .ForMember(dto => dto.Id,
                    opt
                        => opt.MapFrom(entity => entity.Id))
                .ForMember(dto => dto.Name,
                    opt
                        => opt.MapFrom(entity => entity.Name));


            CreateMap<UserRoleDto, UserRole>()
                .ForMember(entity => entity.Id,
                    opt
                        => opt.MapFrom(dto => dto.Id))
                .ForMember(entity => entity.Name,
                    opt
                        => opt.MapFrom(dto => dto.Name));


            CreateMap<UserRoleDto, UserRoleModel>().ReverseMap();
        }
    }
}
