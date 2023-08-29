namespace Sinco.Prueba.Colegio.Application.Models.ViewModels
{
    public class ReportVm
    {
        public int Id { get; set; }
        public int AcademicYear { get; set; }
        public string StudentIdentificationNumber { get; set; }
        public string StudentName { get; set; }
        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public string TeacherIdentificationNumber { get; set; }
        public string TeacherName { get; set; }
        public float Rating { get; set; }
        public bool WasApproved { get; set; }
    }
}
