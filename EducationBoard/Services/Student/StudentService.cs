using System.ComponentModel.DataAnnotations;
using AutoMapper;
using EducationBoard.DAL;
using EducationBoard.Models;
using EducationBoard.Validations;

namespace EducationBoard.Services
{
    public class StudentService : IStudentService
    {
        private IStudentDAL _studentDAL;
        private IMapper _mapper;
        public StudentService(IStudentDAL studentDAL, IMapper mapper)
        {
            _studentDAL = studentDAL;
            _mapper = mapper;
        }
        public bool CreateStudent(Student student)
        {
            StudentValidation.IsStudentValid(student);
            try
            {
                return _studentDAL.CreateStudent(student) ? true : false;
            }
            catch (ValidationException VE)
            {
                throw VE;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<StudentsDTO> GetAllStudents()
        {
            try
            {
                var students = _studentDAL.GetAllStudents();
                var studentsDto = _mapper.Map<List<StudentsDTO>>(students);
                return studentsDto;
            }
            catch
            {
                throw new Exception("Internal server error");
            }
        }
    }
}