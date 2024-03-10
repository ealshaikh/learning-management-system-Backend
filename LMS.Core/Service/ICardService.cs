using LMS.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Core.Service
{
    public interface ICardService
    {
        Task CreateCard(int cardNumber, int cardCVV, DateTime expiryDate, string cardholderName, decimal balance);
        Task<Card> GetCard(int cardId);
        Task<IEnumerable<Card>> GetAllCards();
        Task DeleteCard(int cardId);
    }
}
