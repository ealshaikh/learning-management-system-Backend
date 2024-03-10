using LMS.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Core.Repository
{
    public interface ITeacherRepository

    {
        List<Teacher> GetAllTeachers();
        Task CreateTeacher(Teacher teacher);
        Task UpdateTeacher(Teacher teacher);
        Task DeleteTeacher(int teacherId);
        Task<int> GetTeacherCount();
        Task<Teacher> GetTeacherById(int teacherId);


    }
}
