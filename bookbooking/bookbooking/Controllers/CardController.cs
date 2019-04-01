using bookbooking.Common.ViewModels.CardV;
using bookbooking.Web.Areas.Administration.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace bookbooking.Web.Controllers
{
    public class CardController : BaseController<CardController>
    {
        CardView cardView = new CardView();
        
        public IActionResult Index()
        {
            doldur();
            cardView = cardService.CardList();
            return View(cardView);
        }
        [HttpPost]
        public IActionResult AddCard(CardView model)
        {
            var user = userManager.FindByNameAsync(User.Identity.Name);
            model.Card.UserId = user.Id.ToString();
            return View();
        }
        public IActionResult RemoveCard(int[] cards)
        {
            cardView.IdsToDelete = cards;
            cardService.DeleteCard(cardView);
            return View();
        }
    }
}