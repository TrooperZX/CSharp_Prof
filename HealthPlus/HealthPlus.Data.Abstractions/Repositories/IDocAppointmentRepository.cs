using HealthPlus.DataBase.Entities;

namespace HealthPlus.Data.Abstractions.Repositories
{
    public interface IDocAppointmentRepository
    {
        public Task<DocAppointment?> GetDocAppointmentByIdAsync(Guid id);

        public IQueryable<DocAppointment> GetDocAppointmentsAsQueryable();


        public Task<List<DocAppointment?>> GetAllDocAppointmentsAsync();


        public Task AddDocAppointmentAsync(DocAppointment docAppointment);


        public Task AddDocAppointmentsAsync(IEnumerable<DocAppointment> docAppointment);

        public Task RemoveDocAppointmentAsync(DocAppointment docAppointment);


        public Task UpdateDocAppointment(Guid id, DocAppointment docAppointment);
    }
}
