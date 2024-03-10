using Dapper;
using LMS.Core.Data;
using LMS.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infra.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly IDbContext dbContext;

        public TeacherRepository(IDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }
        public List<Teacher> GetAllTeachers()
        {
            var parameters = new DynamicParameters();
            // Add parameters if required by your stored procedure

            IEnumerable<Teacher> result = dbContext.Connection.Query<Teacher>(
                "TeacherPackage.GetAllTeachers", param: parameters, commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public async Task CreateTeacher(Teacher teacher)
        {
            var p = new DynamicParameters();
            p.Add("p_TeacherFname", teacher.Teacherfname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_TeacherLname", teacher.Teacherlname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_PhoneNo", teacher.Phoneno, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_DOB", teacher.Dob, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("p_Address", teacher.Address, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Gender", teacher.Gender, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_ProfileImage", teacher.Profileimage, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_RoleID", 2, dbType: DbType.Int32, direction: ParameterDirection.Input);

            await dbContext.Connection.ExecuteAsync("TeacherPackage.CreateTeacher", p, commandType: CommandType.StoredProcedure);
        }
        public async Task UpdateTeacher(Teacher teacher)
        {
            var p = new DynamicParameters();
            p.Add("p_TeacherID", teacher.Teacherid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_TeacherFname", teacher.Teacherfname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_TeacherLname", teacher.Teacherlname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_PhoneNo", teacher.Phoneno, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_DOB", teacher.Dob, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("p_Address", teacher.Address, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Gender", teacher.Gender, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_ProfileImage", teacher.Profileimage, dbType: DbType.String, direction: ParameterDirection.Input);


            await dbContext.Connection.ExecuteAsync("TeacherPackage.UpdateTeacher", p, commandType: CommandType.StoredProcedure);
        }






        public async Task<Teacher> GetTeacherById(int teacherId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_TeacherID", teacherId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("p_TeacherFname", dbType: DbType.String, direction: ParameterDirection.Output, size: 255);
            parameters.Add("p_TeacherLname", dbType: DbType.String, direction: ParameterDirection.Output, size: 255);
            parameters.Add("p_PhoneNo", dbType: DbType.String, direction: ParameterDirection.Output, size: 20);
            parameters.Add("p_DOB", dbType: DbType.Date, direction: ParameterDirection.Output);
            parameters.Add("p_Address", dbType: DbType.String, direction: ParameterDirection.Output, size: 255);
            parameters.Add("p_Gender", dbType: DbType.String, direction: ParameterDirection.Output, size: 10);
            parameters.Add("p_ProfileImage", dbType: DbType.String, direction: ParameterDirection.Output, size: 255);


            using (var result = await dbContext.Connection.QueryMultipleAsync("TeacherPackage.GetTeacherById", parameters, commandType: CommandType.StoredProcedure))
            {
                var teacher = new Teacher
                {
                    Teacherid = teacherId,
                    Teacherfname = parameters.Get<string>("p_TeacherFname"),
                    Teacherlname = parameters.Get<string>("p_TeacherLname"),
                    Phoneno = parameters.Get<string>("p_PhoneNo"),
                    Dob = parameters.Get<DateTime>("p_DOB"),
                    Address = parameters.Get<string>("p_Address"),
                    Gender = parameters.Get<string>("p_Gender"),
                    Profileimage = parameters.Get<string>("p_ProfileImage"),

                    // Add other properties as needed
                };

                return teacher;
            }
        }
        public async Task<int> GetTeacherCount()
        {
            var p = new DynamicParameters();
            p.Add("p_Counter", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await dbContext.Connection.ExecuteAsync("TeacherPackage.GetTeacherCount", p, commandType: CommandType.StoredProcedure);

            return p.Get<int>("p_Counter");
        }

        public async Task DeleteTeacher(int teacherId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_TeacherID", teacherId, DbType.Int32, ParameterDirection.Input);

            await dbContext.Connection.ExecuteAsync(
                "TeacherPackage.DeleteTeacher",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

    }
}
