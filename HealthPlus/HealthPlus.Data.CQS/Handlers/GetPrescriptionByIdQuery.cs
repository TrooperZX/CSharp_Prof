using HealthPlus.Core.DataTransferObjects;
using MediatR;


namespace HealthPlus.Data.CQS.Handlers
{
    public class GetPrescriptionByIdQuery : IRequest<PrescriptionDto?>
    {
        public Guid Id { get; set; }
    }
}
