using LMS.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Core.Repository
{
    public interface IAuthRepository
    {
        Studentuserlogin Login(Studentuserlogin login);

        Adminuserlogin Adminlogin(Adminuserlogin login);

    }
}
