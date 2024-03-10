using Dapper;
using LMS.Core.Data;
using LMS.Core.Repository;
using LMS.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infra.Repository
{
    public class AdminRepository : IAdminRepository
    {

        private readonly IDbContext _dbContext;
        public AdminRepository(IDbContext dBContext)
        {
            this._dbContext = dBContext;
        }

        public async void CreateAdmin(Admin admin)
        {
            var p = new DynamicParameters();
            p.Add("FullName", admin.Fullname, dbType: System.Data.DbType.String, direction: System.Data.ParameterDirection.Input);
            _dbContext.Connection.ExecuteAsync("Admin_Package.CreateAdmin", p, commandType: System.Data.CommandType.StoredProcedure);

        }

        public async void DeleteAdmin(int ID)
        {
            var p = new DynamicParameters();
            p.Add("ID", ID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.ExecuteAsync("Admin_Package.DeleteAdmin", p, commandType: CommandType.StoredProcedure);

        }

        public async Task<Admin> GetAdminByID(int ID)
        {
            var p = new DynamicParameters();
            p.Add("ID", ID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Admin>("Admin_Package.GetAdminByID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<int> GetAdminCount()
        {
            var p = new DynamicParameters();
            p.Add("AdminCount", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("Admin_Package.GetAdminCount", p, commandType: CommandType.StoredProcedure);
            return p.Get<int>("AdminCount");
        }

        public async Task<List<Admin>> GetAllAdmins()
        {
            
            var result = await _dbContext.Connection.QueryAsync<Admin>("Admin_Package.GetAllAdmins", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }

        public async void UpdateAdmin(Admin admin)
        {
            var p = new DynamicParameters();
            p.Add("p_AdminID", admin.Adminid, dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Input);
            p.Add("p_FullName", admin.Fullname, dbType: System.Data.DbType.String, direction: System.Data.ParameterDirection.Input);
            _dbContext.Connection.ExecuteAsync("Admin_Package.UpdateAdmin", p, commandType: System.Data.CommandType.StoredProcedure);

        }
    }
}
