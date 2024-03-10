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
    public class AuthRepository : IAuthRepository
    {
        private readonly IDbContext _dbContext;
        
        public AuthRepository (IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Adminuserlogin Adminlogin(Adminuserlogin login)
        {
            var p = new DynamicParameters();
            p.Add("User_Name", login.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Pass", login.Password, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<Adminuserlogin>("UserLogin_Package.AdminUser_Login", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public Studentuserlogin Login(Studentuserlogin login)
        {
            var p = new DynamicParameters();
            p.Add("User_Name", login.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Pass", login.Password, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<Studentuserlogin>("UserLogin_Package.StudentUser_Login", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
