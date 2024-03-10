using LMS.Core.Data;
using LMS.Core.DTO;
using LMS.Core.Repository;
using LMS.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infra.Service
{
    public class StudentService :IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            this._studentRepository = studentRepository;
        }

        public async void CreateStudent(Student student)
        {
            _studentRepository.CreateStudent(student);
        }

        public async void DeleteStudent(int ID)
        {
            _studentRepository.DeleteStudent(ID);
        }

        public async Task<List<Student>> GetAllStudents()
        {
           return await _studentRepository.GetAllStudents();
        }

  

        public List<PassedStudent> GetPassedStudents(int courseID)
        {
            return  _studentRepository.GetPassedStudents(courseID);
        }

        public async Task<Student> GetStudentByID(int ID)
        {
            return await _studentRepository.GetStudentByID(ID);
        }

        public List<StudentGrade> GetStudentGrades(int studentID)
        {
            return _studentRepository.GetStudentGrades(studentID);
        }

        public async Task<int> GetStudentsCount()
        {
            return await _studentRepository.GetStudentsCount();
        }

        public async void UpdateStudent(Student student)
        {
            _studentRepository.UpdateStudent(student);
        }
    }
}
