using Newtonsoft.Json;
using School.DAL;
using School.Models;
using School.Validations;

namespace School.Services
{
    public class StudentService : IStudentService
    {
        private IStudentDAL _studentDAL;
        private IMessagingService _messagingService;
        private int _schoolCode;
        public StudentService(IStudentDAL studentDAL, IMessagingService messagingService, IConfiguration configuration)
        {
            _studentDAL = studentDAL;
            _messagingService = messagingService;
            _schoolCode = Convert.ToInt32(configuration.GetSection("SchoolSettings").GetSection("SchoolCode").Value);
        }
        public bool CreateStudent(Student student)
        {
            StudentValidation.IsStudentValid(student);
            try
            {
                if (_studentDAL.CreateStudent(student))
                {
                    var lastStudent = _studentDAL.GetParticularStudent();
                    string studentDetails = JsonConvert.SerializeObject(new
                    {
                        Function = "Create Student",
                        RollNumber = lastStudent.RollNumber,
                        StudentName = lastStudent.StudentName,
                        SchoolID = _schoolCode
                    });
                    _messagingService.SendMessage(studentDetails);
                    return true;
                }
                else
                {
                    throw new Exception("Internal error occured");
                }
            }
            catch
            {
                throw ;
            }
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _studentDAL.GetAllStudents();
        }
    }
}