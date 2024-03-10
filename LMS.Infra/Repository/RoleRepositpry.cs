using Dapper;
using LMS.Core.Data;
using LMS.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infra.Repository
{
    public class RoleRepositpry : IRoleRepository
    {

        private readonly IDbContext _dbContext;
        public RoleRepositpry(IDbContext dBContext)
        {
            this._dbContext = dBContext;
        }



        public async void CreateRole(Role role)
        {
            var p = new DynamicParameters();
             p.Add("RoleName",role.Rolename, direction: System.Data.ParameterDirection.Input);
            _dbContext.Connection.ExecuteAsync("Role_Package.CreateRole", p,commandType: CommandType.StoredProcedure);
        }

        public async void DeleteRole(int ID)
        {
            var p = new DynamicParameters();
            p.Add("ID", ID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.ExecuteAsync("Role_Package.DeleteRole", p, commandType: CommandType.StoredProcedure);

        }

        public async Task<List<Role>> GetAllRolles()
        {
            var result = await _dbContext.Connection.QueryAsync<Role>("Role_Package.GetAllRoles", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<Role> GetRoleByID(int ID)
        {
            var p = new DynamicParameters();
            p.Add("ID", ID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Role>("Role_Package.GetRoleByID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<int> GetRolesCount()
        {
            var p = new DynamicParameters();
            p.Add("RoleCount", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("Role_Package.GetRoleCount", p, commandType: CommandType.StoredProcedure);
            return p.Get<int>("RoleCount");
        }

        public async void UpdateRole(Role role)
        {
            var p = new DynamicParameters();
            p.Add("ID", role.Roleid, DbType.Int32, ParameterDirection.Input);
            p.Add("name", role.Rolename, DbType.String, ParameterDirection.Input);
            _dbContext.Connection.Execute("Role_Package.UpdateRole", p, commandType: CommandType.StoredProcedure);


        }
    }
}
