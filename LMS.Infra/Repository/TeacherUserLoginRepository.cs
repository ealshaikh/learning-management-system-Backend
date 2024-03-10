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
    public class TeacherUserLoginRepository : ITeacherUserLoginRepository
    {
        private readonly IDbContext dbContext;

        public TeacherUserLoginRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task CreateTeacherUserLogin(int teacherId, int roleId, string email, string password)
        {
            var p = new DynamicParameters();
            p.Add("p_TeacherID", teacherId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_RoleID", roleId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_Email", email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Password", password, dbType: DbType.String, direction: ParameterDirection.Input);

            await dbContext.Connection.ExecuteAsync("TeacherUserLoginPackage.CreateTeacherUserLogin", p, commandType: CommandType.StoredProcedure);
        }

        //GetAll
        public async Task<List<Teacheruserlogin>> GetAllTeacherUserLogin()
        {
            try
            {
                var parameters = new DynamicParameters();
                // Add parameters if required by your stored procedure

                IEnumerable<Teacheruserlogin> result = await dbContext.Connection.QueryAsync<Teacheruserlogin>(
                    "TeacherUserLoginPackage.GetAllTeachers", param: parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred in GetAllTeacherUserLogin: {ex.Message}");
                throw; // Rethrow the exception for further handling
            }
        }

        // GetTeacherUserLogin


        public async Task DeleteTeacherUserLogin(int teacherUserLoginId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_TeacherUserLoginID", teacherUserLoginId, DbType.Int32, ParameterDirection.Input);

            await dbContext.Connection.ExecuteAsync("TeacherUserLoginPackage.DeleteTeacherUserLogin", parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task UpdateTeacherUserLogin(int teacherUserLoginId, int teacherId, int roleId, string email, string password)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_TeacherUserLoginID", teacherUserLoginId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("p_TeacherID", teacherId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("p_RoleID", roleId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("p_Email", email, DbType.String, ParameterDirection.Input, size: 255);
            parameters.Add("p_Password", password, DbType.String, ParameterDirection.Input, size: 255);

            await dbContext.Connection.ExecuteAsync("TeacherUserLoginPackage.UpdateTeacherUserLogin", parameters, commandType: CommandType.StoredProcedure);
        }



        public async Task<Teacheruserlogin> GetTeacherUserLogin(int teacherUserLoginId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_TeacherUserLoginID", teacherUserLoginId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("p_TeacherID", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("p_RoleId", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("p_Email", dbType: DbType.String, direction: ParameterDirection.Output, size: 255);
            parameters.Add("p_Password", dbType: DbType.String, direction: ParameterDirection.Output, size: 255);

            dbContext.Connection.Execute("TeacherUserLoginPackage.GetTeacherUserLogin", parameters, commandType: CommandType.StoredProcedure);

            // Retrieve output parameters
            int teacherId = parameters.Get<int>("p_TeacherID");
            int roleId = parameters.Get<int>("p_RoleId");
            string email = parameters.Get<string>("p_Email");
            string password = parameters.Get<string>("p_Password");

            // Create and return a Teacheruserlogin object
            return new Teacheruserlogin
            {
                Teacheruserloginid = teacherUserLoginId,
                Teacherid = teacherId,
                Roleid = roleId,
                Email = email,
                Password = password
                // Add other properties as needed
            };
        }


        Task<int> ITeacherUserLoginRepository.GetTeacherUserLoginCount()
        {
            throw new NotImplementedException();
        }

        Task ITeacherUserLoginRepository.UpdateTeacherUserLogin(Teacher teacher)
        {
            throw new NotImplementedException();
        }
    }

}
