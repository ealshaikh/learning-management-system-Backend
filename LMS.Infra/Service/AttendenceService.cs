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
    public class AttendenceService : IAttendenceService
    {
        private readonly IAttendenceRepository _attendenceRepository;

        public AttendenceService(IAttendenceRepository attendenceRepository)
        {
            _attendenceRepository = attendenceRepository;
        }

        public async Task CreateAttendance(Attendance attendance)
        {
            await _attendenceRepository.CreateAttendance(attendance);
        }

        public async  Task DeleteAttendance(int attendanceID)
        {
            await _attendenceRepository.DeleteAttendance(attendanceID);
        }

        public async Task<List<Attendance>> GetAllAttendances()
        {
            return await _attendenceRepository.GetAllAttendances();
        }

        public async Task<Attendance> GetAttendanceById(int attendanceID)
        {
            return await _attendenceRepository.GetAttendanceById(attendanceID);
        }

        public async Task<int> GetAttendanceCount()
        {
            return await _attendenceRepository.GetAttendanceCount();
        }

        public async Task<List<Attendance>> GetAttendancesBySection(int sectionID)
        {
            return await _attendenceRepository.GetAttendancesBySection(sectionID);
        }

        public async Task<List<Attendance>> GetAttendancesByStudent(int studentID)
        {
            return await _attendenceRepository.GetAttendancesByStudent(studentID);
        }

        public async Task UpdateAttendance(Attendance attendance)
        {
            await _attendenceRepository.UpdateAttendance(attendance);
        }
    }
}
