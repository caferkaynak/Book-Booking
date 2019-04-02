using bookbooking.Common.ViewModels.CardV;
using bookbooking.Common.ViewModels.Library;
using bookbooking.Entity.Entities;
using bookbooking.Web.Areas.Administration.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace bookbooking.Web.Controllers
{
    public class CardController : BaseController<CardController>
    { 
        CardView cardView = new CardView();
        public IActionResult Index()
        {
            StartTemp();
            cardView = cardService.CardList(User.Identity.Name);
            return View(cardView);
        }
        [HttpPost]
        public async Task<IActionResult> AddCard(BookView model)
        {
                model.Card.BookId = model.Card.BookId;
                var user = await userManager.FindByNameAsync(User.Identity.Name);
                model.Card.UserId = user.Id;
                Card card = new Card();
                card = model.Card;
                cardService.AddCard(card);
                return RedirectToAction("Index", "Card");
        }
        [HttpPost]
        public IActionResult RemoveCard(CardView cardView)
        {
            if (cardView.IdsToDelete!=null)
            {
                cardService.DeleteCard(cardView);
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Card");
        }
    }
}