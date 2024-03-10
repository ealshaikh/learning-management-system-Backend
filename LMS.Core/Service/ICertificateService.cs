using LMS.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Core.Service
{
    public interface ICertificateService
    {
        Task CreateCertificate(DateTime certificateDate, int studentId, int planId);
        Task<Certificate> GetCertificateById(int certificateId);
        Task<IEnumerable<Certificate>> GetAllCertificates();
        Task DeleteCertificate(int certificateId);
    }
}
