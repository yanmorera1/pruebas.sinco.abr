using AutoMapper;
using Sinco.Prueba.Colegio.Application.Models.ViewModels;
using Sinco.Prueba.Colegio.Domain;

namespace Sinco.Prueba.Colegio.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Teacher, TeacherVm>();
            CreateMap<Student, StudentVm>();
            CreateMap<Subject, SubjectVm>()
                .ForMember(sr => sr.TeacherName, r => r.MapFrom(r => $"{r.Teacher.Name} {r.Teacher.LastName}"));
            CreateMap<StudentSubject, ReportVm>()
                .ForMember(sr => sr.Id, r => r.MapFrom(r => r.Id))
                .ForMember(sr => sr.AcademicYear, r => r.MapFrom(r => r.CreatedAt.Value.Year))
                .ForMember(sr => sr.StudentIdentificationNumber, r => r.MapFrom(r => r.Student.IdentificationNumber))
                .ForMember(sr => sr.StudentName, r => r.MapFrom(r => $"{r.Student.Name} {r.Student.LastName}"))
                .ForMember(sr => sr.SubjectCode, r => r.MapFrom(r => r.Subject.Code))
                .ForMember(sr => sr.SubjectName, r => r.MapFrom(r => r.Subject.Name))
                .ForMember(sr => sr.TeacherIdentificationNumber, r => r.MapFrom(r => r.Subject.Teacher.IdentificationNumber))
                .ForMember(sr => sr.TeacherName, r => r.MapFrom(r => $"{r.Subject.Teacher.Name} {r.Subject.Teacher.LastName}"))
                .ForMember(sr => sr.Rating, r => r.MapFrom(r => r.Rating))
                .ForMember(sr => sr.WasApproved, r => r.MapFrom(r => r.Rating >= 3));
        }
    }
}
