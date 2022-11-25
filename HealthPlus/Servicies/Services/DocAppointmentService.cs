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
    public class DocAppointmentService : IDocAppointmentService
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;

        public DocAppointmentService(IMapper mapper,
            IConfiguration configuration,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> CreateDocAppointmentAsync(DocAppointmentDto dto)
        {
            var entity = _mapper.Map<DocAppointment>(dto);

            if (entity != null)
            {
                await _unitOfWork.DocAppointments.AddAsync(entity);
                var addingResult = await _unitOfWork.Commit();
                return addingResult;
            }
            else
            {
                throw new ArgumentException(nameof(dto));
            }
        }

        public async Task<List<DocAppointmentDto>> GetDocAppointmentByPageNumberPageSizeAndUserIdAsync
        (int pageNumber, int pageSize, Guid userId)
        {
            try
            {
                var list = await _unitOfWork.DocAppointments
                    .Get()
                    .Where(docAppointment => docAppointment.UserId == userId)
                    .Skip(pageNumber * pageSize)
                    .Take(pageSize)
                    .Select(docAppointment => _mapper.Map<DocAppointmentDto>(docAppointment))
                    .ToListAsync();

                return list;
            }
            catch (Exception e)
            {
                //todo add logger here
                throw;
            }
        }

        public async Task<DocAppointmentDto> GetDocAppointmentByIdAsync(Guid id)
        {
            var entity = await _unitOfWork.DocAppointments.GetByIdAsync(id);
            var dto = _mapper.Map<DocAppointmentDto>(entity);

            return dto;
        }

        public async Task<int> UpdateDocAppointmentAsync(Guid id, DocAppointmentDto? dto)
        {
            var sourceDto = await GetDocAppointmentByIdAsync(id);

            //checks and updates for edit docApp-ts
            //should be sure that dto property naming is the same with entity property naming
            var patchList = new List<PatchModel>();
            if (dto != null)
            {
                if (!dto.Specialization.Equals(sourceDto.Specialization))
                {
                    patchList.Add(new PatchModel()
                    {
                        PropertyName = nameof(dto.Specialization),
                        PropertyValue = dto.Specialization
                    });
                }

                if (!dto.AppointmentDate.Equals(sourceDto.AppointmentDate))
                {
                    patchList.Add(new PatchModel()
                    {
                        PropertyName = nameof(dto.AppointmentDate),
                        PropertyValue = dto.AppointmentDate
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

            await _unitOfWork.DocAppointments.PatchAsync(id, patchList);
            return await _unitOfWork.Commit();
        }

        public async Task DeleteDocAppointmentById(Guid id)
        {
            var entity = await _unitOfWork.DocAppointments.GetByIdAsync(id);

            if (entity != null)
            {
                _unitOfWork.DocAppointments.Remove(entity);

                await _unitOfWork.Commit();
            }
            else
            {
                throw new ArgumentException("DocAppointment for removing doesn't exist", nameof(id));
            }
        }
    }
}
