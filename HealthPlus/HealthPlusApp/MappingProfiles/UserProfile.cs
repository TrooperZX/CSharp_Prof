using HealthPlus.DataBase.Entities;
using HealthPlus.Core.DataTransferObjects;
using HealthPlusApp.Models;
using AutoMapper;


//db
//public Guid Id { get; set; }
//public string Email { get; set; }
//public string PasswordHash { get; set; }
//public DateTime RegistrationDate { get; set; }
//public Guid RoleId { get; set; }
//public UserRole Role { get; set; }

//Core dto


//public Guid RoleId { get; set; }
//public string RoleName { get; set; }




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
                    => opt.MapFrom(entity => entity.RoleId))
                //role name
                .ForMember(dto => dto.RoleName,
                opt
                    => opt.MapFrom(entity => entity.Role));

            //to db
            CreateMap<UserDto, User>()
                //id
                .ForMember(entity => entity.Id,
                    opt
                        => opt.MapFrom(dto => Guid.NewGuid()))
                //registration date
                .ForMember(entity => entity.RegistrationDate,
                    opt
                        => opt.MapFrom(dto => DateTime.Now))
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
                        => opt.MapFrom(dto => dto.RoleId))
                //role name
                .ForMember(entity => entity.Role,
                    opt
                        => opt.MapFrom(dto => dto.RoleName));


            CreateMap<RegisterModel, UserDto>()
                .ForMember(dto => dto.Email,
                opt => opt.MapFrom(reg => reg.Email))

                .ForMember(dto => dto.PasswordHash,
                opt => opt.MapFrom(reg => reg.Password));


            CreateMap<LoginModel, UserDto>();

        }
    }
}
