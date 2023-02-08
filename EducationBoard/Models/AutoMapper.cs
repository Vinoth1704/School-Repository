using AutoMapper;

namespace EducationBoard.Models
{
    public class AutoMappers : Profile
    {
        public AutoMappers()
        {
            CreateMap<Student, StudentsDTO>()
                .ForMember(dto => dto.SchoolName, src => src.MapFrom(s => s.school!.SchoolName));
        }
    }
}
