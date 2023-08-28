using Sinco.Prueba.Colegio.Domain.Common;

namespace Sinco.Prueba.Colegio.Domain
{
    public class Subject : Entity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }

        public Subject(string code, string name)
        {
            Name = name;
            Code = code;
        }

        public Subject(string code, string name, int teacherId) : this(code, name)
        {
            TeacherId = teacherId;
        }

        public Subject()
        {
            
        }
    }
}
