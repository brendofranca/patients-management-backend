using AutoMapper;
using Patients.Management.Application.Requests;
using Patients.Management.Application.Responses;
using Patients.Management.Domain.Entities;
using Patients.Management.Infrastructure.Repositories;

namespace Patients.Management.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IMapper _mapper;
        private readonly IPatientRepository _patientRepository;

        public PatientService(IMapper mapper, IPatientRepository patientRepository)
        {
            _mapper = mapper;
            _patientRepository = patientRepository;
        }

        public async Task<PatientResponse> GetPatientByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var patient = await _patientRepository.GetByIdAsync(id, cancellationToken);

            return _mapper.Map<PatientResponse>(patient);
        }

        public async Task<IEnumerable<PatientResponse>> GetAllPatientsAsync(CancellationToken cancellationToken)
        {
            var patients = await _patientRepository.GetAllAsync(cancellationToken);

            return _mapper.Map<IEnumerable<PatientResponse>>(patients);
        }

        public async Task<bool> RegisterPatientAsync(PatientRequest request, CancellationToken cancellationToken)
        {
            var patientExists = await _patientRepository.GetByIdAsync(request.Id, cancellationToken);

            var id = patientExists?.Id != null ? patientExists.Id : request.Id;

            var patient = new Patient(id, request.Name, request.DateOfBirth, request.Email);

            await (patientExists == null ? _patientRepository.CreateAsync(patient, cancellationToken) : _patientRepository.UpdateAsync(patient, cancellationToken));

            return true;
        }

        public async Task<bool> DeletePatientAsync(Guid id, CancellationToken cancellationToken)
        {
            await _patientRepository.DeleteAsync(id, cancellationToken);

            return true;
        }
    }
}