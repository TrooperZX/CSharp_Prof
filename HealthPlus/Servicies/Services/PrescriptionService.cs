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
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public PrescriptionService(IMapper mapper,
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
        public async Task<int> CreatePrescriptionAsync(PrescriptionDto dto)
        {
            var entity = _mapper.Map<Prescription>(dto);

            if (entity != null)
            {
                await _unitOfWork.Prescriptions.AddAsync(entity);
                var addingResult = await _unitOfWork.Commit();
                return addingResult;
            }
            else
            {
                throw new ArgumentException(nameof(dto));
            }
        }

        // READ
        public async Task<List<PrescriptionDto>> GetPrescriptionByPageNumberAndPageSizeAsync(int pageNumber,
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
                    .Select(article => _mapper.Map<PrescriptionDto>(article))
                    .ToListAsync();

                return list;
            }
            catch (Exception e)
            {
                //todo add logger here
                throw;
            }

        }

        public async Task<PrescriptionDto> GetPrescriptionByIdAsync(Guid id)
        {
            var dto = await _mediator.Send(new GetPrescriptionByIdQuery() { Id = id });
            return dto;
        }

        // UPDATE
        public async Task<int> UpdatePrescriptionAsync(Guid id, PrescriptionDto? dto)
        {
            var sourceDto = await GetPrescriptionByIdAsync(id);

            var patchList = new List<PatchModel>();
            if (dto != null)
            {
                if (!dto.MedicationId.Equals(sourceDto.MedicationId))
                {
                    if (!dto.DateOfPrescription.Equals(sourceDto.DateOfPrescription))
                    {
                        patchList.Add(new PatchModel()
                        {
                            PropertyName = nameof(dto.DurationOfPrescription),
                            PropertyValue = dto.DurationOfPrescription
                        });
                    }
                }
            }

            await _unitOfWork.Prescriptions.PatchAsync(id, patchList);
            return await _unitOfWork.Commit();
        }

        // DELETE
        public async Task DeletePrescriptionAsync(Guid id)
        {

            var entity = await _unitOfWork.Prescriptions.GetByIdAsync(id);

            if (entity != null)
            {
                _unitOfWork.Prescriptions.Remove(entity);

                await _unitOfWork.Commit();
            }
            else
            {
                throw new ArgumentException("Article for removing doesn't exist", nameof(id));
            }
        }
    }
}

