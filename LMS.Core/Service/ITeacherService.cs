using LMS.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Core.Service
{
    public interface ITeacherService
    {
        List<Teacher> GetAllTeachers();
        Task CreateTeacher(Teacher teacher);
        Task UpdateTeacher(Teacher teacher);
        Task<Teacher> GetTeacherById(int teacherId);
        public Task<int> GetTeacherCount();


        Task DeleteTeacher(int teacherId);


    }
}
