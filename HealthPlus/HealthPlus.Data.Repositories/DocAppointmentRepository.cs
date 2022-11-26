using HealthPlus.DataBase;
using HealthPlus.DataBase.Entities;
using HealthPlus.Data.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;


namespace HealthPlus.Data.Repositories
{
    public class DocAppointmentRepository : IDocAppointmentRepository
    {
        private readonly HealthPlusContext _database;

        public DocAppointmentRepository(HealthPlusContext database)
        {
            _database = database;
        }

        public async Task<DocAppointment?> GetDocAppointmentByIdAsync(Guid id)
        {
            return await _database
                .DocAppointments.FirstOrDefaultAsync(docAppointment => docAppointment.Id.Equals(id));
        }
        

        public async Task<List<DocAppointment?>> GetAllDocAppointmentsAsync()
        {
            return await _database.DocAppointments.ToListAsync();
        }
        
        public async Task CreateDocAppointmentAsync(DocAppointment docAppointment)
        {
            await _database.DocAppointments.AddAsync(docAppointment);
        }

        public async Task AddDocAppointmentsAsync(IEnumerable<DocAppointment> docAppointment)
        {
            await _database.DocAppointments.AddRangeAsync(docAppointment);
        }

        public async Task RemoveDocAppointmentAsync(DocAppointment docAppointment)
        {
            _database.DocAppointments.Remove(docAppointment);
        }

        public async Task UpdateDocAppointment(Guid id, DocAppointment docAppointment)
        {
            var entity = await _database.DocAppointments.FirstOrDefaultAsync(docAppointment => docAppointment.Id.Equals(id));

            if (entity != null)
            {
                entity = docAppointment;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _database.SaveChangesAsync();
        }
    }
}
//11public Task<DocAppointment?> GetDocAppointmentByIdAsync(Guid id);
//22public Task<List<DocAppointment?>> GetAllDocAppointmentsAsync();
//public Task CreateDocAppointmentAsync(DocAppointment docAppointment);
//44public Task AddDocAppointmentsAsync(IEnumerable<DocAppointment> docAppointment);
//55public Task RemoveDocAppointmentAsync(DocAppointment docAppointment);
//66public Task UpdateDocAppointmentAsync(Guid id, DocAppointment docAppointment);