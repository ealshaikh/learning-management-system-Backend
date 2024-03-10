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
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task CreateContact(Contact contact)
        {
            // Add any business logic or validation here before calling the repository
            await _contactRepository.CreateContact( contact);
        }
        public Contact GetContact(int contactId)
        {
            return _contactRepository.GetContact(contactId);
        }

        public List<Contact> GetAllContacts()
        {
            return _contactRepository.GetAllContacts();
        }
        public void UpdateContact(int contactId, string message, string email, string fullName, string title)
        {
            _contactRepository.UpdateContact(contactId, message, email, fullName, title);
        }
        public void DeleteContact(int contactId)
        {
            _contactRepository.DeleteContact(contactId);
        }

    }

}
