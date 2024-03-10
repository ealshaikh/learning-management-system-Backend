using LMS.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Core.Service
{
    public interface IAttendenceService
    {
        Task<List<Attendance>> GetAllAttendances();
        Task<int> GetAttendanceCount();
        Task CreateAttendance(Attendance attendance);
        Task UpdateAttendance(Attendance attendance);
        Task<Attendance> GetAttendanceById(int attendanceID);

        Task<List<Attendance>> GetAttendancesBySection(int sectionID);
        Task<List<Attendance>> GetAttendancesByStudent(int studentID);
        Task DeleteAttendance(int attendanceID);
    }
}
