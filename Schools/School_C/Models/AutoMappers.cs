using AutoMapper;

namespace School.Models
{
    public class AutoMappers : Profile
    {
        public AutoMappers()
        {
            // CreateMap<Score, ScoreDTO>()
            // .ForMember(s => s.Name, src => src.MapFrom(sc => sc.student.Name))
            // .ForMember(dto => dto.subjectName, opt => opt.MapFrom(src => src.subject.Name));
        }
    }
}