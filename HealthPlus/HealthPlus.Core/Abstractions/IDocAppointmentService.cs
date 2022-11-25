using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthPlus.Core.DataTransferObjects;

namespace HealthPlus.Core.Abstractions
{
    public interface IDocAppointmentService
    {
        Task<int> CreateDocAppointmentAsync(DocAppointmentDto dto);

        Task<List<DocAppointmentDto>> GetDocAppointmentByPageNumberPageSizeAndUserIdAsync
        (int pageNumber, int pageSize, Guid id);

        Task<DocAppointmentDto> GetDocAppointmentByIdAsync(Guid id);

        Task<int> UpdateDocAppointmentAsync(Guid id, DocAppointmentDto? patchList);

        Task DeleteDocAppointmentById(Guid id);
    }
}
