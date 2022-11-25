using HealthPlus.DataBase.Entities;
using HealthPlus.Core.DataTransferObjects;
using HealthPlusApp.Models;
using AutoMapper;

namespace HealthPlusApp.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            //from db to dto
            CreateMap<User, UserDto>()
                //id
                .ForMember(dto => dto.Id,
                opt
                    => opt.MapFrom(entity => entity.Id))
                //email
                .ForMember(dto => dto.Email,
                opt
                    => opt.MapFrom(entity => entity.Email))
                //passwordhash
                .ForMember(dto => dto.PasswordHash,
                opt
                    => opt.MapFrom(entity => entity.PasswordHash))
                //regdate
                .ForMember(dto => dto.RegistrationDate,
                opt
                    => opt.MapFrom(entity => entity.RegistrationDate))
                //role id
                .ForMember(dto => dto.RoleId,
                opt
                    => opt.MapFrom(entity => entity.RoleId));

            //to db
            CreateMap<UserDto, User>()
                //id
                .ForMember(entity => entity.Id,
                    opt
                        => opt.MapFrom(dto => dto.Id))
                //registration date
                .ForMember(entity => entity.RegistrationDate,
                    opt
                        => opt.MapFrom(dto => dto.RegistrationDate))
                //email
                .ForMember(entity => entity.Email,
                    opt
                        => opt.MapFrom(dto => dto.Email))
                //pass hash
                .ForMember(entity => entity.PasswordHash,
                    opt
                        => opt.MapFrom(dto => dto.PasswordHash))
                //role id
                .ForMember(entity => entity.RoleId,
                    opt
                        => opt.MapFrom(dto => dto.RoleId));


            CreateMap<RegisterModel, UserDto>()
                .ForMember(dto => dto.Email,
                opt => opt.MapFrom(reg => reg.Email))

                .ForMember(dto => dto.PasswordHash,
                opt => opt.MapFrom(reg => reg.Password));


            CreateMap<LoginModel, UserDto>();

            CreateMap<UserDto, UserDataModel>();
        }
    }
}
