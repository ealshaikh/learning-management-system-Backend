using LMS.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Core.Service
{
    public interface IContactService
    {
        Task CreateContact(Contact contact);
        Contact GetContact(int contactId);
        List<Contact> GetAllContacts();
        void UpdateContact(int contactId, string message, string email, string fullName, string title);
        void DeleteContact(int contactId);
    }
}
