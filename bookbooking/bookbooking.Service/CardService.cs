using bookbooking.Common.ViewModels.CardV;
using bookbooking.Data;
using bookbooking.Entity.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using bookbooking.Common.ViewModels;

namespace bookbooking.Service
{
    public interface ICardService
    {
        CardView CardList(string username);
        ServiceResult AddCard(Card card);
        void DeleteCard(CardView model);
    }
    public class CardService : ICardService
    {
        private IRepository<Card> cardRepository;
        ServiceResult serviceResult = new ServiceResult();
        public CardService(IRepository<Card> _cardRepository)
        {
            cardRepository = _cardRepository;
        }
        public CardView CardList(string username)
        {
            CardView cardView = new CardView();
            cardView.Cards = cardRepository.GetAll()
                .Include(i => i.User)
                .Include(i => i.Book)
                .Where(w=>w.User.UserName==username)
                .ToList();
            return cardView;
        }
        public ServiceResult AddCard(Card card)
        {
            if (cardRepository.GetAll().Count()>0)
            {
                var result = cardRepository.GetAll().Where(w => w.BookId == card.BookId && w.UserId == card.UserId);
                if (result!=null)
                    cardRepository.Add(card);
            }
            else
            {
                cardRepository.Add(card);
            }
            return serviceResult;
        }
        public void DeleteCard(CardView model)
        {
            foreach (var bookId in model.IdsToDelete)
            {
                var card = cardRepository.GetAll().Where(w => w.Id == w.Id).FirstOrDefault();
                cardRepository.Remove(card);
            }
        }
    }
}
