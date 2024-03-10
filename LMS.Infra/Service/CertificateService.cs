using LMS.Core.Data;
using LMS.Core.Repository;
using LMS.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infra.Service
{
    public class CertificateService : ICertificateService
    {
        private readonly ICertificateRepository _certificateRepository;

        public CertificateService(ICertificateRepository certificateRepository)
        {
            _certificateRepository = certificateRepository;
        }
        public async Task CreateCertificate(DateTime certificateDate, int studentId, int planId)
        {
            await _certificateRepository.CreateCertificate(certificateDate, studentId, planId);
        }

        public async Task<Certificate> GetCertificateById(int certificateId)
        {
            return await _certificateRepository.GetCertificateById(certificateId);
        }
        public async Task<IEnumerable<Certificate>> GetAllCertificates()
        {
            return await _certificateRepository.GetAllCertificates();
        }
        public async Task DeleteCertificate(int certificateId)
        {
            await _certificateRepository.DeleteCertificate(certificateId);
        }
    }

}
