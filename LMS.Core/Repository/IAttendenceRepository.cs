using LMS.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Core.Repository
{
    public interface IAttendenceRepository
    {
        Task CreateAttendance(Attendance attendance);
        Task DeleteAttendance(int attendanceID);
        Task<List<Attendance>> GetAllAttendances();
        Task<Attendance> GetAttendanceById(int attendanceID);

        Task<int> GetAttendanceCount();


        Task<List<Attendance>> GetAttendancesBySection(int sectionID);
        Task<List<Attendance>> GetAttendancesByStudent(int studentID);

        Task UpdateAttendance(Attendance attendance);

    }
}
