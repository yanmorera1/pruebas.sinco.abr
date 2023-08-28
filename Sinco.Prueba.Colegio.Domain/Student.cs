using Sinco.Prueba.Colegio.Domain.Common;

namespace Sinco.Prueba.Colegio.Domain
{
    public class Student : Person
    {
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }

        public Student(string identificationNumber, string name, string lastName, int age, string address, string phoneNumber)
        {
            IdentificationNumber = identificationNumber;
            Name = name;
            LastName = lastName;
            Age = age;
            Address = address;
            PhoneNumber = phoneNumber;
        }

        public Student()
        {
            
        }
    }
}
