using AutoMapper;

namespace School.Models
{
    public class AutoMappers : Profile
    {
        public AutoMappers()
        {
            CreateMap<Score, ScoreDTO>()
            .ForMember(dto => dto.StudentName, src => src.MapFrom(s => s.student!.StudentName))
            .ForMember(dto => dto.subjectName, src => src.MapFrom(s => s.subject!.SubjectName));
        }
    }
}