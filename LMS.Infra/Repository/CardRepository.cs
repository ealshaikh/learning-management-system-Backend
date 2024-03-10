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
    public class CardRepository : ICardRepository
    {
        private readonly IDbContext _dBContext;
        public CardRepository(IDbContext dBContext)
        {
            _dBContext = dBContext;
        }
        public async Task CreateCard(int cardNumber, int cardCVV, DateTime expiryDate, string cardholderName, decimal balance)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_Card_Number", cardNumber, DbType.Int32, ParameterDirection.Input);
            parameters.Add("p_Card_CVV", cardCVV, DbType.Int32, ParameterDirection.Input);
            parameters.Add("p_Expiry_Date", expiryDate, DbType.Date, ParameterDirection.Input);
            parameters.Add("p_Cardholder_Name", cardholderName, DbType.String, ParameterDirection.Input);
            parameters.Add("p_Balance", balance, DbType.Decimal, ParameterDirection.Input);

            await _dBContext.Connection.ExecuteAsync("CardPackage.CreateCard", parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<Card> GetCard(int cardId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_CardID", cardId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("p_Card_Number", dbType: DbType.Int32, direction: ParameterDirection.Output, size: 255);
            parameters.Add("p_Card_Cvv", dbType: DbType.Byte, direction: ParameterDirection.Output); // Corrected data type to DbType.Byte
            parameters.Add("p_Card_Expiry", dbType: DbType.Date, direction: ParameterDirection.Output);
            parameters.Add("p_Card_Holder", dbType: DbType.String, direction: ParameterDirection.Output, size: 255);
            parameters.Add("p_Balance", dbType: DbType.Decimal, direction: ParameterDirection.Output);

            await _dBContext.Connection.ExecuteAsync("CardPackage.GetCard", parameters, commandType: CommandType.StoredProcedure);

            // Retrieve output parameters
            int cardNumber = parameters.Get<int>("p_Card_Number");
            byte? cardCvv = parameters.Get<byte?>("p_Card_Cvv"); // Corrected data type to byte?
            DateTime cardExpiry = parameters.Get<DateTime>("p_Card_Expiry");
            string cardHolder = parameters.Get<string>("p_Card_Holder");
            decimal balance = parameters.Get<decimal>("p_Balance");

            // Create and return a Card object
            return new Card
            {
                Cardid = cardId,
                CardNumber = cardNumber,
                CardCvv = cardCvv,
                ExpiryDate = cardExpiry,
                CardholderName = cardHolder,
                Balance = balance
            };
        }
        public async Task<IEnumerable<Card>> GetAllCards()
        {
            var cards = await _dBContext.Connection.QueryAsync<Card>("CardPackage.GetAllCards", commandType: CommandType.StoredProcedure);
            return cards;
        }
        public async Task DeleteCard(int cardId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_CardID", cardId, DbType.Int32, ParameterDirection.Input);

            await _dBContext.Connection.ExecuteAsync("CardPackage.DeleteCard", parameters, commandType: CommandType.StoredProcedure);
        }
    }

}
