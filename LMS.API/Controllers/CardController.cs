using LMS.Core.Data;
using LMS.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {

        private readonly ICardService _cardService;

        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCard([FromBody] int cardNumber, int cardCVV, DateTime expiryDate, string cardholderName, decimal balance)
        {
            await _cardService.CreateCard(cardNumber, cardCVV, expiryDate, cardholderName, balance);
            return Ok("created successfully");
        }
        [HttpGet("{cardId}")]
        public async Task<ActionResult<Card>> GetCard(int cardId)
        {
            try
            {
                var card = await _cardService.GetCard(cardId);

                if (card == null)
                {
                    return NotFound(); // Return 404 Not Found if the card is not found
                }

                return Ok(card); // Return the card if found
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine($"Exception: {ex.Message}\nStackTrace: {ex.StackTrace}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Card>>> GetAllCards()
        {
            var cards = await _cardService.GetAllCards();

            if (!cards.Any()) // Ensure cards is not null before calling Any()
            {
                return NotFound("No cards found");
            }

            return Ok(cards);
        }
        [HttpDelete("{cardId}")]
        public async Task<IActionResult> DeleteCard(int cardId)
        {
            try
            {
                await _cardService.DeleteCard(cardId);
                return Ok("Card deleted successfully");
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }

}
