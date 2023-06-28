using Patients.Management.Domain.Entities;

namespace Patients.Management.Infrastructure.Repositories
{
    public interface IPatientRepository
    {
        Task<List<Patient>> GetAllAsync(CancellationToken cancellationToken);

        Task<Patient> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        Task CreateAsync(Patient patient, CancellationToken cancellationToken);

        Task UpdateAsync(Patient patient, CancellationToken cancellationToken);

        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}