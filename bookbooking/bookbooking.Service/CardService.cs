using bookbooking.Common.ViewModels.CardV;
using bookbooking.Data;
using bookbooking.Entity.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace bookbooking.Service
{
    public interface ICardService
    {
        CardView CardList();
        void AddCard(CardView card);
        void DeleteCard(CardView model);
    }
    public class CardService :ICardService
    {
        private IRepository<Card> cardRepository;
        public CardService(IRepository<Card> _cardRepository)
        {
            cardRepository = _cardRepository;
        }
        public CardView CardList()
        {
            CardView cardView = new CardView();
            cardView.Cards = cardRepository.GetAll().Include(i => i.User).Include(i => i.Book).ToList();
            return cardView;
        }
        public void AddCard(CardView card)
        {
            cardRepository.Add(card.Card);
        }
        public void DeleteCard(CardView model)
        {
            foreach (var bookId in model.IdsToDelete)
            {
                var card = cardRepository.GetAll().Where(w => w.BookId == bookId).FirstOrDefault();
                cardRepository.Remove(card);
            }
        }
    }
}
