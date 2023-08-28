using Sinco.Prueba.Colegio.Domain.Common;

namespace Sinco.Prueba.Colegio.Domain
{
    public class StudentSubject : Entity
    {
        public float Rating { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        public StudentSubject(float rating, int studentId, int subjectId)
        {
            Rating = rating;
            StudentId = studentId;
            SubjectId = subjectId;
        }
        public StudentSubject()
        {
            
        }
    }
}
