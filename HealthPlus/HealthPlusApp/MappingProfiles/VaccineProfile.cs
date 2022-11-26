using HealthPlus.DataBase.Entities;
using HealthPlus.Core.DataTransferObjects;
using HealthPlusApp.Models;
using AutoMapper;

namespace HealthPlusApp.MappingProfiles
{

    //db
    //public Guid Id { get; set; }
    //public string Type { get; set; }
    //public string Description { get; set; }
    //dto
    //public Guid Id { get; set; }
    //public string Type { get; set; }
    //public string Description { get; set; }

    public class VaccineProfile : Profile
    {
        public VaccineProfile()
        {
            //from db to dto
            CreateMap<Vaccine, VaccineDto>()
                .ForMember(dto => dto.Id,
                    opt
                        => opt.MapFrom(entity => entity.Id))
                .ForMember(dto => dto.Type,
                    opt
                        => opt.MapFrom(entity => entity.Type))
                .ForMember(dto => dto.Description,
                    opt
                        => opt.MapFrom(entity => entity.Description));


            //from dto to db
            CreateMap<VaccineDto, Vaccine>()
                .ForMember(entity => entity.Id,
                    opt
                        => opt.MapFrom(dto => dto.Id))
                .ForMember(entity => entity.Type,
                    opt
                        => opt.MapFrom(dto =>dto.Type))
                .ForMember(entity => entity.Description,
                    opt
                        => opt.MapFrom(dto => dto.Description));

            CreateMap<VaccineDto, VaccineModel>().ReverseMap();
        }
    }
}
