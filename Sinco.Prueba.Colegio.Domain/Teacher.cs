using Sinco.Prueba.Colegio.Domain.Common;

namespace Sinco.Prueba.Colegio.Domain
{
    public class Teacher : Person
    {
        public virtual ICollection<Subject> Subjects { get; set; }

        public Teacher(string identificationNumber, string name, string lastName, int age, string address, string phoneNumber)
        {
            IdentificationNumber = identificationNumber;
            Name = name;
            LastName = lastName;
            Age = age;
            Address = address;
            PhoneNumber = phoneNumber;
            IsActive = true;
        }

        public Teacher()
        {
            
        }
    }
}
