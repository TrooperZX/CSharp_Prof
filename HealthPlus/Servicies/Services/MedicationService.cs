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
using MediatR;
using HealthPlus.Data.CQS.Handlers;

namespace HealthPlus.Business.Services
{
    public class MedicationService : IMedicationService
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public MedicationService(IMapper mapper,
                IConfiguration configuration,
                IUnitOfWork unitOfWork,
                IMediator mediator)
        {
            _mapper = mapper;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        // CREATE
        public async Task<int> CreateMedicationAsync(MedicationDto dto)
        {
            var entity = _mapper.Map<Medication>(dto);

            if (entity != null)
            {
                await _unitOfWork.Medications.AddAsync(entity);
                var addingResult = await _unitOfWork.Commit();
                return addingResult;
            }
            else
            {
                throw new ArgumentException(nameof(dto));
            }
        }

        // READ
        public async Task<List<MedicationDto>> GetMedicationByPageNumberAndPageSizeAsync(int pageNumber,
            int pageSize)
        {
            try
            {
                var myApiKey = _configuration.GetSection("UserSecrets")["MyApiKey"];
                //_configuration.
                var list = await _unitOfWork.Medications
                    .Get()
                    .Skip(pageNumber * pageSize)
                    .Take(pageSize)
                    .Select(article => _mapper.Map<MedicationDto>(article))
                    .ToListAsync();

                return list;
            }
            catch (Exception e)
            {
                //todo add logger here
                throw;
            }

        }

        public async Task<MedicationDto> GetMedicationByIdAsync(Guid id)
        {
            var dto = await _mediator.Send(new GetMedicationByIdQuery() { Id = id });
            return dto;
        }

        // UPDATE
        public async Task<int> UpdateMedicationAsync(Guid id, MedicationDto? dto)
        {
            var sourceDto = await GetMedicationByIdAsync(id);

            var patchList = new List<PatchModel>();
            if (dto != null)
            {
                if (!dto.Name.Equals(sourceDto.Name))
                {
                    patchList.Add(new PatchModel()
                    {
                        PropertyName = nameof(dto.Name),
                        PropertyValue = dto.Name
                    });
                }
            }

            await _unitOfWork.Medications.PatchAsync(id, patchList);
            return await _unitOfWork.Commit();
        }

        // DELETE
        public async Task DeleteMedicationAsync(Guid id)
        {

            var entity = await _unitOfWork.Medications.GetByIdAsync(id);

            if (entity != null)
            {
                _unitOfWork.Medications.Remove(entity);

                await _unitOfWork.Commit();
            }
            else
            {
                throw new ArgumentException("Article for removing doesn't exist", nameof(id));
            }
        }
    }
}

