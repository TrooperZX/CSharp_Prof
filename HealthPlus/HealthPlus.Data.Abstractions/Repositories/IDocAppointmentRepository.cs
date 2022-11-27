using HealthPlus.DataBase.Entities;

namespace HealthPlus.Data.Abstractions.Repositories
{
    public interface IDocAppointmentRepository
    {
        public Task<DocAppointment?> GetDocAppointmentByIdAsync(Guid id);

        public Task<List<DocAppointment?>> GetAllDocAppointmentsByUserIdAsync(Guid id);

        public Task CreateDocAppointmentAsync(DocAppointment docAppointment);

        public Task AddDocAppointmentsAsync(IEnumerable<DocAppointment> docAppointment);

        public Task RemoveDocAppointmentAsync(DocAppointment docAppointment);

        public Task UpdateDocAppointment(Guid id, DocAppointment docAppointment);
    }
}
