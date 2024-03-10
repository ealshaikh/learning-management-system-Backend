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
    public class UserSectionRepository :IUserSectionRepository
    {
        private readonly IDbContext _dbContext;

        public UserSectionRepository(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async void CreateUserInSection(Usersection usersection)
        {
            var p = new DynamicParameters();
            p.Add("p_SectionID", usersection.Sectionid, DbType.Int32, ParameterDirection.Input);
            p.Add("p_StudentID", usersection.Studentid, DbType.Int32, ParameterDirection.Input);


            _dbContext.Connection.Execute("UserSection_Package.CreateUserInSection", p, commandType: CommandType.StoredProcedure);

        }

        public async void DeleteUserInSection(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_UserSectionID", id, DbType.Int32, ParameterDirection.Input);

            _dbContext.Connection.Execute("UserSection_Package.DeleteUserInSection", p, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<Usersection>> GetAllUserInSections()
        {
            var result = await _dbContext.Connection.QueryAsync<Usersection>("UserSection_Package.GetAllUserInSections", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<Usersection> GetUserInSectionById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_UserSectionID", id, DbType.Int32, ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<Usersection>("UserSection_Package.GetUserInSectionByID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<int> GetUserInSectionCount()
        {
            var p = new DynamicParameters();
            p.Add("p_UserSectionCount", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("UserSection_Package.GetUserInSectionCount", p, commandType: CommandType.StoredProcedure);

            return p.Get<int>("p_UserSectionCount");
        }

        public async void UpdateUserInSection(Usersection usersection)
        {
            var p = new DynamicParameters();

            p.Add("p_UserSectionID", usersection.Usersectionid, DbType.Int32, ParameterDirection.Input);
            p.Add("p_SectionID", usersection.Sectionid, DbType.Int32, ParameterDirection.Input);
            p.Add("p_StudentID", usersection.Studentid, DbType.Int32, ParameterDirection.Input);


            _dbContext.Connection.Execute("UserSection_Package.UpdateUserInSection", p, commandType: CommandType.StoredProcedure);

        }
    }
}
