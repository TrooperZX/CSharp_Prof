using HealthPlus.Core.DataTransferObjects;
using MediatR;

namespace HealthPlus.Data.CQS.Handlers
{
    public class GetMedicationByIdQuery : IRequest<MedicationDto?>
    {
        public Guid Id { get; set; }
    }
}
