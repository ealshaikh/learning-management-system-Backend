using LMS.Core.Data;
using LMS.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Core.Service
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudents();

        Task<Student> GetStudentByID(int ID);

        Task<int> GetStudentsCount();

        void CreateStudent(Student student);
        void UpdateStudent(Student student);

        void DeleteStudent(int ID);

        List<StudentGrade> GetStudentGrades(int studentID);

        List<PassedStudent> GetPassedStudents(int courseID);

    }
}
