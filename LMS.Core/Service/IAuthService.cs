using LMS.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Core.Service
{
    public interface IAuthService
    {
        string Login(Studentuserlogin login);

        string AdminLogin (Adminuserlogin login);
    }
}
