using Dapper;
using LMS.Core.Data;
using LMS.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace LMS.Infra.Repository
{
    public class StudentUserLoginRepository : IStudentUserLoginRepository
    {
        private readonly IDbContext _dbContext;

        public StudentUserLoginRepository(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<List<Studentuserlogin>> GetAllStudentLogins()
        {
            var result = await _dbContext.Connection.QueryAsync<Studentuserlogin>("StudentUserLogin_Package.GetAllStudentLogins", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<int> GetStudentLoginCount()
        {
            var p = new DynamicParameters();
            p.Add("p_StudentLoginCount", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("StudentUserLogin_Package.GetStudentLoginCount", p, commandType: CommandType.StoredProcedure);
            return p.Get<int>("p_StudentLoginCount");
        }

        public async void CreateStudentLogin(Studentuserlogin studentLogin)
        {

            string hashedPassword = HashPassword(studentLogin.Password);


            var p = new DynamicParameters();
            p.Add("p_StudentID", studentLogin.Studentid, DbType.Int32, ParameterDirection.Input);
            p.Add("p_Email", studentLogin.Email, DbType.String, ParameterDirection.Input);
            p.Add("p_Password", hashedPassword, DbType.String, ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync("StudentUserLogin_Package.CreateStudentLogin", p, commandType: CommandType.StoredProcedure);
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        public async void UpdateStudentLogin(Studentuserlogin studentLogin)
        {
            var p = new DynamicParameters();
            p.Add("p_StudentUserLoginID", studentLogin.Studentuserloginid, DbType.Int32, ParameterDirection.Input);
            p.Add("p_StudentID", studentLogin.Studentid, DbType.Int32, ParameterDirection.Input);
            p.Add("p_Email", studentLogin.Email, DbType.String, ParameterDirection.Input);
            p.Add("p_Password", studentLogin.Password, DbType.String, ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync("StudentUserLogin_Package.UpdateStudentLogin", p, commandType: CommandType.StoredProcedure);
        }

        public async void DeleteStudentLogin(int studentUserLoginID)
        {
            var p = new DynamicParameters();
            p.Add("p_StudentUserLoginID", studentUserLoginID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            await _dbContext.Connection.ExecuteAsync("StudentUserLogin_Package.DeleteStudentLogin", p, commandType: CommandType.StoredProcedure);
        }

        public async Task<Studentuserlogin> GetStudentLoginByID(int studentUserLoginID)
        {
            var p = new DynamicParameters();
            p.Add("p_StudentUserLoginID", studentUserLoginID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Studentuserlogin>("StudentUserLogin_Package.GetStudentLoginByID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
