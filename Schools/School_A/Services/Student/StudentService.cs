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

        public StudentService(
            IStudentDAL studentDAL,
            IMessagingService messagingService,
            IConfiguration configuration
        )
        {
            _studentDAL = studentDAL;
            _messagingService = messagingService;
            _schoolCode = Convert.ToInt32(
                configuration.GetSection("SchoolSettings").GetSection("SchoolCode").Value
            );
        }

        public bool CreateStudent(Student student)
        {
            StudentValidation.IsStudentValid(student);

            if (_studentDAL.CreateStudent(student))
            {
                var lastStudent = _studentDAL.GetParticularStudent();
                string studentDetails = JsonConvert.SerializeObject(
                    new
                    {
                        Function = "Create Student",
                        RollNumber = lastStudent.RollNumber,
                        StudentName = lastStudent.StudentName,
                        SchoolID = _schoolCode
                    }
                );
                try
                {
                    _messagingService.SendMessage(studentDetails);
                    var response = _messagingService.ReceiveMessage();
                    if (response == true)
                    {
                        Console.WriteLine("true");
                        return true;
                    }
                    else
                    {
                        throw new Exception(
                            "Student created successfully but internal error occured at Education board"
                        );
                    }
                }
                catch (Exception)
                {
                    throw new Exception(
                        "Student created successfully but failed to send data to Education board"
                    );
                }
            }
            else
            {
                throw new Exception("Internal error occured");
            }
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _studentDAL.GetAllStudents();
        }
    }
}
