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
        Task<List<DocAppointmentDto>> GetDocAppointmentByPageNumberAndPageSizeAsync
        (int pageNumber, int pageSize);

        Task<List<DocAppointmentDto>> GetNewDocAppointmentsFromAsync();

        Task<DocAppointmentDto> GetDocAppointmentByIdAsync(Guid id);

        Task<int> CreateArticleAsync(DocAppointmentDto dto);

        Task<int> DeleteArticleByIdAsync(Guid id);

        Task Do();
    }
}
