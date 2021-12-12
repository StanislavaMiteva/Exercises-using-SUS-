using BattleCards.ViewModels.Cards;
using System.Collections.Generic;

namespace BattleCards.Services
{
    public interface ICardsService
    {
        void AddCard(AddCardInputModel input, string userId);

        IEnumerable<ViewCardModel> AllCards();

        IEnumerable<ViewCardModel> CollectionByUserId(string userId);

        bool AddCardToCollection(string userId, int cardId);
    }
}
