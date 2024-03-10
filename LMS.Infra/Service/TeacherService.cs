using LMS.Core.Data;
using LMS.Core.Repository;
using LMS.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infra.Service
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository teacherrepository;

        public TeacherService(ITeacherRepository teacherrepository)
        {
            this.teacherrepository = teacherrepository;

        }
        public List<Teacher> GetAllTeachers()
        {
            return teacherrepository.GetAllTeachers();
        }
        public async Task CreateTeacher(Teacher teacher)
        {
            await teacherrepository.CreateTeacher(teacher);
        }
        public async Task UpdateTeacher(Teacher teacher)
        {

            await teacherrepository.UpdateTeacher(teacher);
        }

        public async Task DeleteTeacher(int teacherId)
        {
            await teacherrepository.DeleteTeacher(teacherId);
        }

        public async Task<Teacher> GetTeacherById(int teacherId)
        {
            return await teacherrepository.GetTeacherById(teacherId);
        }

        public async Task<int> GetTeacherCount()
        {
            return await teacherrepository.GetTeacherCount();
        }
    }

}
