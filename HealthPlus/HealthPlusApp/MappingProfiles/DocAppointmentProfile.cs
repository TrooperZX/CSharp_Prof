using HealthPlus.DataBase.Entities;
using HealthPlus.Core.DataTransferObjects;
using HealthPlusApp.Models;
using AutoMapper;

namespace HealthPlusApp.MappingProfiles
{
    public class DocAppointmentProfile : Profile
    {
        public DocAppointmentProfile()
        {
            //from db to dto
            CreateMap<DocAppointment, DocAppointmentDto>()
                //id
                .ForMember(dto => dto.Id,
                opt
                    => opt.MapFrom(entity => entity.Id))
                //userId
                .ForMember(dto => dto.UserId,
                opt
                    => opt.MapFrom(entity => entity.UserId))
                //specialization
                .ForMember(dto => dto.Specialization,
                opt
                    => opt.MapFrom(entity => entity.Specialization))
                //note
                .ForMember(dto => dto.Note,
                opt
                    => opt.MapFrom(entity => entity.Note))
                //appointment date
                .ForMember(dto => dto.AppointmentDate,
                opt
                    => opt.MapFrom(entity => entity.AppointmentDate));

            //to db
            CreateMap<DocAppointmentDto, DocAppointment>()
                //id
                .ForMember(entity => entity.Id,
                    opt
                        => opt.MapFrom(dto => dto.Id))
                //userId
                .ForMember(entity => entity.UserId,
                    opt
                        => opt.MapFrom(dto => dto.UserId))
                //specialization
                .ForMember(entity => entity.Specialization,
                    opt
                        => opt.MapFrom(dto => dto.Specialization))
                //Note
                .ForMember(entity => entity.Note,
                    opt
                        => opt.MapFrom(dto => dto.Note))
                //role id
                .ForMember(entity => entity.AppointmentDate,
                    opt
                        => opt.MapFrom(dto => dto.AppointmentDate));

            CreateMap<DocAppointmentDto, DocAppointmentModel>().ReverseMap();
        }
    }
}
