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
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;

        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }



        public async Task CreateCard(int cardNumber, int cardCVV, DateTime expiryDate, string cardholderName, decimal balance)
        {
            await _cardRepository.CreateCard(cardNumber, cardCVV, expiryDate, cardholderName, balance);
        }

        public async Task<Card> GetCard(int Id)
        {
            return await _cardRepository.GetCard(Id);
        }
        public async Task<IEnumerable<Card>> GetAllCards()
        {
            return await _cardRepository.GetAllCards();
        }
        public async Task DeleteCard(int cardId)
        {
            await _cardRepository.DeleteCard(cardId);
        }
    }

}
