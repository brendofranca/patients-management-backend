using MongoDB.Driver;
using Patients.Management.Domain.Entities;

namespace Patients.Management.Infrastructure.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly IMongoCollection<Patient> _patientsCollection;

        public PatientRepository(IMongoDatabase mongoDatabase) =>
            _patientsCollection = mongoDatabase.GetCollection<Patient>("patients");

        public async Task<List<Patient>> GetAllAsync(CancellationToken cancellationToken) =>
            await _patientsCollection.Find(_ => true).ToListAsync(cancellationToken);

        public async Task<Patient> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
            await _patientsCollection.Find(p => p.Id == id).FirstOrDefaultAsync(cancellationToken);

        public async Task CreateAsync(Patient patient, CancellationToken cancellationToken) =>
            await _patientsCollection.InsertOneAsync(patient, cancellationToken: cancellationToken);

        public async Task UpdateAsync(Patient patient, CancellationToken cancellationToken) =>
            await _patientsCollection.ReplaceOneAsync(p => p.Id == patient.Id, patient, cancellationToken: cancellationToken);

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken) =>
            await _patientsCollection.DeleteOneAsync(x => x.Id == id, cancellationToken);
    }
}