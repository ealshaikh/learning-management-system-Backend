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
    public class AdminUserloginRepository :IAdminUserloginRepository
    {
        private readonly IDbContext _dbContext;
        public AdminUserloginRepository(IDbContext dBContext)
        {
            this._dbContext = dBContext;
        }

        public async void CreateAdminUserlogin(Adminuserlogin admin)
        {

            string hashedPassword = HashPassword(admin.Password);

            var p = new DynamicParameters();
            p.Add("AdminID", admin.Adminid, DbType.Int32, ParameterDirection.Input);
            p.Add("Email", admin.Email, DbType.String, ParameterDirection.Input);
            p.Add("Pass", hashedPassword, DbType.String, ParameterDirection.Input); // Use "Pass" here instead of "Password"

            await _dbContext.Connection.ExecuteAsync("AdminUserLogin_Package.CreateAdminUserLogin", p, commandType: CommandType.StoredProcedure);
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        public async void DeleteAdminUserlogin(int ID)
        {
            var p = new DynamicParameters();
            p.Add("ID", ID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.ExecuteAsync("AdminUserLogin_Package.DeleteAdminUserLogin", p, commandType: CommandType.StoredProcedure);

        }

        public async Task<Adminuserlogin> GetAdminUserloginByID(int ID)
        {
            var p = new DynamicParameters();
            p.Add("ID", ID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Adminuserlogin>("AdminUserLogin_Package.GetAdminUserLoginByID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();

        }

        public async Task<int> GetAdminUserloginCount()
        {
            var p = new DynamicParameters();
            p.Add("AdminUserLoginCount", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("AdminUserLogin_Package.GetAdminUserLoginCount", p, commandType: CommandType.StoredProcedure);
            return p.Get<int>("AdminUserLoginCount");
        }

        public async Task<List<Adminuserlogin>> GetAllAdminUserLogin()
        {
            var result = await _dbContext.Connection.QueryAsync<Adminuserlogin>("AdminUserLogin_Package.GetAllAdminUserLogins", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }



        public void UpdateAdminUserlogin(Adminuserlogin admin)
        {
            var p = new DynamicParameters();
            p.Add("p_AdminUserLoginID", admin.Adminuserloginid, dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Input);
            p.Add("p_AdminID", admin.Adminid, dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Input);
            p.Add("p_Email", admin.Email, dbType: System.Data.DbType.String, direction: System.Data.ParameterDirection.Input);
            p.Add("p_Password", admin.Password, dbType: System.Data.DbType.String, direction: System.Data.ParameterDirection.Input);
            _dbContext.Connection.ExecuteAsync("AdminUserLogin_Package.UpdateAdminUserLogin", p, commandType: System.Data.CommandType.StoredProcedure);

        }


    }
}
