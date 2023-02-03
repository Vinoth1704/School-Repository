using AutoMapper;

namespace EducationBoard.Models
{
    public class AutoMappers : Profile
    {
        public AutoMappers()
        {
            CreateMap<Student, StudentsDTO>()
            .ForMember(dto => dto.StudentName, src => src.MapFrom(s => s.StudentName))
            .ForMember(dto => dto.SchoolName, src => src.MapFrom(s => s.school!.SchoolName));
        }
    }
}