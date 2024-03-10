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
    public class CertificateRepository : ICertificateRepository
    {
        private readonly IDbContext _dbContext;

        public CertificateRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateCertificate(DateTime certificateDate, int studentId, int planId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_CertificateDate", certificateDate, DbType.Date, ParameterDirection.Input);
            parameters.Add("p_StudentID", studentId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("p_PlanID", planId, DbType.Int32, ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync("CertificatePackage.CreateCertificate", parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<Certificate> GetCertificateById(int certificateId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_CertificateID", certificateId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("p_CertificateDate", dbType: DbType.Date, direction: ParameterDirection.Output);
            parameters.Add("p_StudentID", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("p_PlanID", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("CertificatePackage.GetCertificateById", parameters, commandType: CommandType.StoredProcedure);

            // Retrieve output parameters
            DateTime certificateDate = parameters.Get<DateTime>("p_CertificateDate");
            int studentId = parameters.Get<int>("p_StudentID");
            int planId = parameters.Get<int>("p_PlanID");

            // Create and return a Certificate object
            return new Certificate
            {
                Certificateid = certificateId,
                Certificatedate = certificateDate,
                Studentid = studentId,
                Planid = planId
                // Add other properties as needed
            };
        }
        public async Task<IEnumerable<Certificate>> GetAllCertificates()
        {
            var c = await _dbContext.Connection.QueryAsync<Certificate>("CertificatePackage.GetAllCertificate", commandType: CommandType.StoredProcedure);
            return c;
        }
        public async Task DeleteCertificate(int certificateId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_CertificateID", certificateId, DbType.Int32, ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync("CertificatePackage.DeleteCertificate", parameters, commandType: CommandType.StoredProcedure);
        }
    }

}
