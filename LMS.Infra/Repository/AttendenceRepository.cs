using Dapper;
using Dapper.Oracle;
using LMS.Core.Data;
using LMS.Core.DTO;
using LMS.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infra.Repository
{
    public class AttendenceRepository : IAttendenceRepository
    {
        private readonly IDbContext _dbContext;

        public AttendenceRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAttendance(Attendance attendance)
        {
            var p = new DynamicParameters();
            p.Add("p_AttendanceDate", attendance.Attendancedate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("p_SectionID", attendance.Sectionid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_StudentID", attendance.Studentid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_status", attendance.Status, dbType: DbType.String, direction: ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync("AttendancePackage.CreateAttendance", p, commandType: CommandType.StoredProcedure);

        }

        public async Task DeleteAttendance(int attendanceID)
        {
            var p = new DynamicParameters();
            p.Add("p_AttendanceID", attendanceID, dbType: DbType.Int32, direction: ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync("AttendancePackage.DeleteAttendance", p, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<Attendance>> GetAllAttendances()
        {
            try
            {
                var result = await _dbContext.Connection.QueryAsync<Attendance>(
                    "AttendancePackage.GetAllAttendance",
                    commandType: CommandType.StoredProcedure
                );
                return result.ToList();
            }
            catch (Exception ex)
            {
                // Add logging or debugging statements here
                Console.WriteLine($"Error in GetAllAttendances: {ex.Message}");
                throw; // Rethrow the exception
            }
        }

        public async Task<Attendance> GetAttendanceById(int attendanceID)
        {
            var p = new DynamicParameters();
            p.Add("p_AttendanceID", attendanceID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Attendance>("AttendancePackage.GetAttendanceById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<int> GetAttendanceCount()
        {
            var p = new DynamicParameters();
            p.Add("p_Counter", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("AttendancePackage.GetAttendanceCount", p, commandType: CommandType.StoredProcedure);
            return p.Get<int>("p_Counter");

        }

        public async Task<List<Attendance>> GetAttendancesBySection(int sectionID)
        {

            try
            {
                var p = new OracleDynamicParameters();
                p.Add("p_SectionID", sectionID, dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);
                p.Add("p_AttendanceList", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

                var result = await _dbContext.Connection.QueryAsync<Attendance>(
                    "AttendancePackage.GetAttendancesBySection",
                    p,
                    commandType: CommandType.StoredProcedure
                );
                return result.ToList();

            }

            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in GetPassedStudents for course ID {sectionID}: {ex.Message}");
                throw;
            }


        }

        public async Task<List<Attendance>> GetAttendancesByStudent(int studentID)
        {
            try
            {
                var p = new OracleDynamicParameters();
                p.Add("p_StudentID", studentID, dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);
                p.Add("p_AttendanceList", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

                var result = await _dbContext.Connection.QueryAsync<Attendance>(
                    "AttendancePackage.GetAttendancesByStudent",
                    p,
                    commandType: CommandType.StoredProcedure
                );
                return result.ToList();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"An error occurred in GetPassedStudents for course ID {studentID}: {ex.Message}");
                throw;
            }
        }


      

        public async Task UpdateAttendance(Attendance attendance)
        {
            var p = new DynamicParameters();
            p.Add("p_AttendanceID", attendance.Attendanceid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_AttendanceDate", attendance.Attendancedate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("p_SectionID", attendance.Sectionid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_StudentID", attendance.Studentid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_status", attendance.Status, dbType: DbType.String, direction: ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync("AttendancePackage.UpdateAttendance", p, commandType: CommandType.StoredProcedure);
        }
    }
}
