using SevStudentsApp.DTO;
using SevStudentsApp.Models;

namespace SevStudentsApp.Service
{
    public interface IStudentService
    {
        List<Student> GetAllStudents();
        void InsertStudent(StudentDTO? DTO);

        void UpdateStudent(StudentDTO? DTO);
        Student? DeleteStudent(StudentDTO? dto);
        Student? GetStudent(int id);
    }
}
