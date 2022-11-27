using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthPlus.DataBase;
using HealthPlus.DataBase.Entities;
using HealthPlus.Core;
using HealthPlus.Core.Abstractions;
using HealthPlus.Core.DataTransferObjects;
using HealthPlus.Data.Abstractions;
using HealthPlus.Data.Abstractions.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HealthPlus.Business.Services
{
    public class VaccinationService : IVaccinationService
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;

        public VaccinationService(IMapper mapper,
            IConfiguration configuration,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
        }
        public async Task<int> CreateVaccinationAsync(VaccinationDto dto)
        {
            var entity = _mapper.Map<Vaccination>(dto);

            if (entity != null)
            {
                await _unitOfWork.Vaccinations.AddAsync(entity);
                var addingResult = await _unitOfWork.Commit();
                return addingResult;
            }
            else
            {
                throw new ArgumentException(nameof(dto));
            }
        }

        public async Task<Guid?> GetVaccinationIdByDateAndVaccineIdAsync(DateTime vaccinationDate, Guid vaccineId)
        {
            var vaccination = await _unitOfWork.Vaccinations
                .FindBy(vaccination => vaccination.DateOfVaccination.Equals(vaccinationDate))
                .Where(vaccination => vaccination.VaccineId.Equals(vaccineId))
                .FirstOrDefaultAsync();
            return vaccination?.Id;
        }

        public async Task<VaccinationDto> GetVaccinationByIdAsync(Guid id)
        {
            var entity = await _unitOfWork.Vaccinations.GetByIdAsync(id);
            var dto = _mapper.Map<VaccinationDto>(entity);

            return dto;
        }

        public async Task<int> UpdateVaccinationAsync(Guid id, VaccinationDto? dto)
        {
            var sourceDto = await GetVaccinationByIdAsync(id);

            var patchList = new List<PatchModel>();
            if (dto != null)
            {
                if (!dto.Equals(sourceDto.Status))
                {
                    patchList.Add(new PatchModel()
                    {
                        PropertyName = nameof(dto.Status),
                        PropertyValue = dto.Status
                    });
                }

                if (!dto.Note.Equals(sourceDto.Note))
                {
                    patchList.Add(new PatchModel()
                    {
                        PropertyName = nameof(dto.Note),
                        PropertyValue = dto.Note
                    });
                }
                if (!dto.Equals(sourceDto.DateOfVaccination))
                {
                    patchList.Add(new PatchModel()
                    {
                        PropertyName = nameof(dto.DateOfVaccination),
                        PropertyValue = dto.DateOfVaccination
                    });
                }

                if (!dto.Note.Equals(sourceDto.Note))
                {
                    patchList.Add(new PatchModel()
                    {
                        PropertyName = nameof(dto.Note),
                        PropertyValue = dto.Note
                    });
                }
            }

            await _unitOfWork.Vaccines.PatchAsync(id, patchList);
            return await _unitOfWork.Commit();
        }

        public async Task DeleteVaccinationById(Guid id)
        {
            var entity = await _unitOfWork.Vaccinations.GetByIdAsync(id);

            if (entity != null)
            {
                _unitOfWork.Vaccinations.Remove(entity);

                await _unitOfWork.Commit();
            }
            else
            {
                throw new ArgumentException("Vaccination for removing doesn't exist", nameof(id));
            }
        }
    }
}


//public Guid Id { get; set; }
//public Guid UserId { get; set; }
//public DateTime DateOfVaccination { get; set; }
//public string Status { get; set; }
//public string? Note { get; set; }