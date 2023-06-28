using Patients.Management.Application.Requests;
using Patients.Management.Application.Responses;

namespace Patients.Management.Application.Services
{
    public interface IPatientService
    {
        Task<PatientResponse> GetPatientByIdAsync(Guid id, CancellationToken cancellationToken);

        Task<IEnumerable<PatientResponse>> GetAllPatientsAsync(CancellationToken cancellationToken);

        Task<bool> RegisterPatientAsync(PatientRequest request, CancellationToken cancellationToken);

        Task<bool> DeletePatientAsync(Guid id, CancellationToken cancellationToken);
    }
}