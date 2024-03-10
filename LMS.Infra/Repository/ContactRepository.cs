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
    public class ContactRepository : IContactRepository
    {
        private readonly IDbContext _dbContext;

        public ContactRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public async Task CreateContact(Contact conatct)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_MESSAGE", conatct.Messeage, DbType.String, ParameterDirection.Input);
            parameters.Add("p_EMAIL", conatct.Email, DbType.String, ParameterDirection.Input);
            parameters.Add("p_FULLNAME", conatct.Fullname, DbType.String, ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync("Contact_Package.Create_Contact", parameters, commandType: CommandType.StoredProcedure);
        }





        public Contact GetContact(int contactId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_CONTACT_ID", contactId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("o_MESSAGE", dbType: DbType.String, direction: ParameterDirection.Output, size: 255);
            parameters.Add("o_EMAIL", dbType: DbType.String, direction: ParameterDirection.Output, size: 255);
            parameters.Add("o_FULLNAME", dbType: DbType.String, direction: ParameterDirection.Output, size: 255);
            parameters.Add("o_TITLE", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);

            _dbContext.Connection.Execute("Contact_Package.Get_Contact", parameters, commandType: CommandType.StoredProcedure);

            // Retrieve output parameters
            string message = parameters.Get<string>("o_MESSAGE");
            string email = parameters.Get<string>("o_EMAIL");
            string fullName = parameters.Get<string>("o_FULLNAME");
            string title = parameters.Get<string>("o_TITLE");

            return new Contact
            {
                ContactId = contactId,
                Messeage = message,
                Email = email,
                Fullname = fullName
            };
        }


        public List<Contact> GetAllContacts()
        {
            IEnumerable<Contact> result = _dbContext.Connection.Query<Contact>("Contact_Package.GetAll_Contacts", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }
        public void UpdateContact(int contactId, string message, string email, string fullName, string title)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_CONTACT_ID", contactId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("p_MESSAGE", message, DbType.String, ParameterDirection.Input);
            parameters.Add("p_EMAIL", email, DbType.String, ParameterDirection.Input);
            parameters.Add("p_FULLNAME", fullName, DbType.String, ParameterDirection.Input);
            parameters.Add("p_TITLE", title, DbType.String, ParameterDirection.Input);

            _dbContext.Connection.Execute("Contact_Package.Update_Contact", parameters, commandType: CommandType.StoredProcedure);
        }
        public void DeleteContact(int contactId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_CONTACT_ID", contactId, DbType.Int32, ParameterDirection.Input);

            _dbContext.Connection.Execute("Contact_Package.Delete_Contact", parameters, commandType: CommandType.StoredProcedure);
        }
    }

}
