using AutoMapper;
using Patients.Management.Application.Responses;
using Patients.Management.Domain.Entities;

namespace Patients.Management.Application.AutoMappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile() => CreateMap<Patient, PatientResponse>();
    }
}