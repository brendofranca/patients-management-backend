namespace Patients.Management.Application.Responses
{
    public record PatientResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
    }
}