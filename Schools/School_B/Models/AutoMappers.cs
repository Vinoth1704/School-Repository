using AutoMapper;

namespace School.Models
{
    public class AutoMappers : Profile
    {
        public AutoMappers()
        {
            CreateMap<Score, ScoreDTO>()
            .ForMember(s => s.StudentName, src => src.MapFrom(sc => sc.student!.StudentName))
            .ForMember(dto => dto.subjectName, opt => opt.MapFrom(src => src.subject!.SubjectName));
        }
    }
}