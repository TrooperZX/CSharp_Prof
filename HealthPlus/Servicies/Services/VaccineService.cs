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
    public class VaccineService : IVaccineService

    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;

        public VaccineService(IMapper mapper,
            IConfiguration configuration,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> CreateVaccineAsync(VaccineDto dto)
        {
            var entity = _mapper.Map<Vaccine>(dto);

            if (entity != null)
            {
                await _unitOfWork.Vaccines.AddAsync(entity);
                var addingResult = await _unitOfWork.Commit();
                return addingResult;
            }
            else
            {
                throw new ArgumentException(nameof(dto));
            }
        }

        public async Task<Guid?> GetVaccineIdByNameAsync(string name)
        {
            var vaccine = await _unitOfWork.Vaccines.FindBy(vaccineType => vaccineType.Type.Equals(name))
                .FirstOrDefaultAsync();
            return vaccine?.Id;
        }

        public async Task<VaccineDto> GetVaccineByIdAsync(Guid id)
        {
            var entity = await _unitOfWork.Vaccines.GetByIdAsync(id);
            var dto = _mapper.Map<VaccineDto>(entity);

            return dto;
        }

        public async Task<int> UpdateVaccineAsync(Guid id, VaccineDto? dto)
        {
            var sourceDto = await GetVaccineByIdAsync(id);

            var patchList = new List<PatchModel>();
            if (dto != null)
            {
                if (!dto.Type.Equals(sourceDto.Type))
                {
                    patchList.Add(new PatchModel()
                    {
                        PropertyName = nameof(dto.Type),
                        PropertyValue = dto.Type
                    });
                }

                if (!dto.Description.Equals(sourceDto.Description))
                {
                    patchList.Add(new PatchModel()
                    {
                        PropertyName = nameof(dto.Description),
                        PropertyValue = dto.Description
                    });
                }

            }

            await _unitOfWork.Vaccines.PatchAsync(id, patchList);
            return await _unitOfWork.Commit();
        }

        public async Task DeleteVaccineById(Guid id)
        {
            var entity = await _unitOfWork.Vaccines.GetByIdAsync(id);

            if (entity != null)
            {
                _unitOfWork.Vaccines.Remove(entity);

                await _unitOfWork.Commit();
            }
            else
            {
                throw new ArgumentException("Vaccine for removing doesn't exist", nameof(id));
            }
        }
    }
}
