using System.ComponentModel.DataAnnotations;

namespace Patients.Management.Application.Requests
{
    public record PatientRequest
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public PatientRequest() => Id = Guid.NewGuid();
    }
}