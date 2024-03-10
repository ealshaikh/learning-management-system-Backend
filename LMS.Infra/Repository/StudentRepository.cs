using Dapper;
using Dapper.Oracle;
using Oracle.ManagedDataAccess.Client;
using LMS.Core.Data;
using LMS.Core.Repository;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Oracle;
using LMS.Core.DTO;


namespace LMS.Infra.Repository
{
    public class StudentRepository :IStudentRepository
    {
        private readonly IDbContext _dbContext;
        public StudentRepository(IDbContext dBContext)
        {
            this._dbContext = dBContext;
        }

        public async void CreateStudent(Student student)
        {
            Console.WriteLine($"Creating student: {Newtonsoft.Json.JsonConvert.SerializeObject(student)}");

            var p = new DynamicParameters();
            p.Add("p_FirstName", student.Studentfname, DbType.String,ParameterDirection.Input );
            p.Add("p_LastName",student.Studentlname, DbType.String, ParameterDirection.Input);
            p.Add("p_PhoneNumber",student.Phoneno, DbType.String, ParameterDirection.Input);
            p.Add("p_DateOfBirth",student.Dob, DbType.Date, ParameterDirection.Input);
            p.Add("p_AddressText",student.Address, DbType.String, ParameterDirection.Input);
            p.Add("p_GenderType",student.Gender, DbType.String, ParameterDirection.Input);
            p.Add("p_ImagePath",student.Profileimage, DbType.String, ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync("Student_Package.CreateStudent", p, commandType: CommandType.StoredProcedure);
        }

        public async void DeleteStudent(int ID)
        {
            var p = new DynamicParameters();
            p.Add("p_StudentID", ID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.ExecuteAsync("Student_Package.DeleteStudent", p, commandType: CommandType.StoredProcedure);

        }

        public async Task<List<Student>> GetAllStudents()
        {
            var result = await _dbContext.Connection.QueryAsync<Student>("Student_Package.GetAllStudents", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<int> GetStudentsCount()
        {
            var p = new DynamicParameters();
            p.Add("p_StudentCount", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("Student_Package.GetStudentCount", p, commandType: CommandType.StoredProcedure);
            return p.Get<int>("p_StudentCount");
        }

        public async void UpdateStudent(Student student)
        {
            var p = new DynamicParameters();
            p.Add("p_StudentID", student.Studentid, DbType.Int32, ParameterDirection.Input);
            p.Add("p_FirstName", student.Studentfname, DbType.String, ParameterDirection.Input);
            p.Add("p_LastName", student.Studentlname, DbType.String, ParameterDirection.Input);
            p.Add("p_PhoneNumber", student.Phoneno, DbType.String, ParameterDirection.Input);
            p.Add("p_DateOfBirth", student.Dob, DbType.Date, ParameterDirection.Input);
            p.Add("p_AddressText", student.Address, DbType.String, ParameterDirection.Input);
            p.Add("p_GenderType", student.Gender, DbType.String, ParameterDirection.Input);
            p.Add("p_ImagePath", student.Profileimage, DbType.String, ParameterDirection.Input);
            _dbContext.Connection.ExecuteAsync("Student_Package.UpdateStudent", p, commandType: System.Data.CommandType.StoredProcedure);


        }

        public async Task<Student> GetStudentByID(int ID)
        {
            var p = new DynamicParameters();
            p.Add("p_StudentID", ID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Student>("Student_Package.GetStudentByID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<List<Student>> GetCourseTopThreeGrades(int courseID)
        {
            var p = new DynamicParameters();
            p.Add("p_CourseID", courseID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Student>("Student_Package.GetCourseTopThreeGrades", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<PassedStudent> GetPassedStudents(int courseID)
        {
            try
            {
                var p = new OracleDynamicParameters();
                p.Add("p_CourseID", courseID, OracleMappingType.Int32, ParameterDirection.Input);
                p.Add("p_UserCourses", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
                var result = _dbContext.Connection.Query<PassedStudent>(
                    "Student_Package.GetPassedStudent",
                    p,
                    commandType: CommandType.StoredProcedure
                ).ToList();

                return result;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in GetPassedStudents for course ID {courseID}: {ex.Message}");
                throw;
            }
        }









        public List<StudentGrade> GetStudentGrades(int studentID)
        {
            try
            {
                var parameters = new OracleDynamicParameters();
                parameters.Add("p_StudentID", studentID, OracleMappingType.Int32, ParameterDirection.Input);
                parameters.Add("p_UserCourses", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

                var result = _dbContext.Connection.Query<StudentGrade>(
                    "Student_Package.GetStudentGrades",
                    parameters,
                    commandType: CommandType.StoredProcedure
                ).ToList();

                return result;
            }
            catch (OracleException ex)
            {
                Console.WriteLine($"Oracle Exception: {ex.Number} - {ex.Message}");
                throw; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in GetStudentGrades for student ID {studentID}: {ex.Message}");
                throw; 
            }
        }

     



    }
}
