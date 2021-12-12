using BattleCards.Data;
using BattleCards.Models;
using BattleCards.ViewModels.Cards;

using System.Collections.Generic;
using System.Linq;

namespace BattleCards.Services
{
    public class CardsService : ICardsService
    {
        private readonly ApplicationDbContext db;

        public CardsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void AddCard(AddCardInputModel input, string userId)
        {
            var card = new Card
            {
                Attack = int.Parse(input.Attack),
                Description = input.Description,
                Health = int.Parse(input.Health),
                ImageUrl = input.Image,
                Keyword = input.Keyword,
                Name = input.Name,
            };

            card.UsersCard.Add(new UserCard
            {
                Card = card,
                UserId = userId,
            });
            this.db.Cards.Add(card);
            this.db.SaveChanges();
        }

        public bool AddCardToCollection(string userId, int cardId)
        {
            var cardInCollection = this.db.UsersCards
                .FirstOrDefault(x => x.CardId == cardId && x.UserId == userId);


            if (cardInCollection!=null)
            {
                return false;
            }

            this.db.UsersCards
                .Add(new UserCard
                {
                    UserId = userId,
                    CardId = cardId,
                });
            this.db.SaveChanges();
            return true;
        }

        public IEnumerable<ViewCardModel> AllCards()
        {
            return this.db.Cards
                .Select(x => new ViewCardModel
                {
                    Id = x.Id,
                    Attack = x.Attack,
                    Description = x.Description,
                    Health = x.Health,
                    ImageUrl = x.ImageUrl,
                    Keyword = x.Keyword,
                    Name = x.Name,
                })
                .ToList();
        }

        public IEnumerable<ViewCardModel> CollectionByUserId(string userId)
        {
             return this.db.UsersCards
                .Where(x=> x.UserId==userId)
                .Select(x => new ViewCardModel
                {
                    Id = x.CardId,
                    Name = x.Card.Name,
                    ImageUrl = x.Card.ImageUrl,
                    Keyword = x.Card.Keyword,
                    Attack = x.Card.Attack,
                    Health = x.Card.Health,
                    Description = x.Card.Description,
                })
                .ToList();
        }

        public void DeleteFromCollection(string userId, int cardId)
        {
            var cardToDeleteFromCollection = this.db.UsersCards
                .FirstOrDefault(x => x.CardId == cardId && x.UserId == userId);
            this.db.UsersCards.Remove(cardToDeleteFromCollection);
            this.db.SaveChanges();
        }
    }
}
