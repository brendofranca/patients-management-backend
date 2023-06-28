namespace Patients.Management.Domain.Entities
{
    public class Patient
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string Email { get; private set; }

        public Patient(Guid id, string name, DateTime dateOfBirth, string email)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            Email = email;
        }
    }
}