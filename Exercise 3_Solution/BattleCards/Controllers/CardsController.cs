using BattleCards.Services;
using BattleCards.ViewModels.Cards;

using SUS.HTTP;
using SUS.MvcFramework;

namespace BattleCards.Controllers
{
    public class CardsController: Controller
    {
        private readonly ICardsService cardsService;

        public CardsController(ICardsService cardsService)
        {
            this.cardsService = cardsService;
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var cards = this.cardsService.AllCards();
            return this.View(cards);
            //only for SIS Frameworkq because it does not work with collection in comparison with SUS!!!
            //var allCardsCollection = new AllCardsViewModel
            //{
            //    AllCards = cards,
            //};
            //return this.View(allCardsCollection);
        }

        public HttpResponse Add()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddCardInputModel input)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrWhiteSpace(input.Name) || input.Name.Length < 5 || input.Name.Length > 15)
            {
                return this.Error("Name should be between 5 and 15 characters long.");
            }

            if (string.IsNullOrWhiteSpace(input.Image))
            {
                return this.Error("Image Url is required.");
            }

            if (string.IsNullOrWhiteSpace(input.Keyword))
            {
                return this.Error("Keyword is required.");
            }

            if (!int.TryParse(input.Attack, out _) || int.Parse(input.Attack) < 0)
            {
                return this.Error("Attack should be non-negative integer.");
            }

            if (!int.TryParse(input.Health, out _) || int.Parse(input.Health) < 0)
            {
                return this.Error("Health should be non-negative integer.");
            }

            if (string.IsNullOrWhiteSpace(input.Description) || input.Description.Length > 200)
            {
                return this.Error("Description should be maximum 200 characters long.");
            }

            var userId = this.GetUserId();
            this.cardsService.AddCard(input,userId);
            return this.Redirect("/Cards/All");
        }

        public HttpResponse Collection()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();
            var cards = this.cardsService.CollectionByUserId(userId);

            return this.View(cards);
        }

        public HttpResponse AddToCollection(int cardId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            
            var userId = this.GetUserId();
            bool cardIsAddedToCollection = this.cardsService.AddCardToCollection(userId, cardId);
            if (!cardIsAddedToCollection)
            {
                return this.Error("Card is already in collection.");
            }
            return this.Redirect("/Cards/All");
        }

        public HttpResponse RemoveFromCollection(int cardId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.cardsService.DeleteFromCollection(this.GetUserId(), cardId);
            return this.Redirect("/Cards/Collection");
        }
    }
}
