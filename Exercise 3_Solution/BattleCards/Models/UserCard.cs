using System.ComponentModel.DataAnnotations.Schema;

namespace BattleCards.Models
{
    public class UserCard
    {
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        [ForeignKey(nameof(Card))]
        public int CardId { get; set; }

        public virtual Card Card { get; set; }
    }
}
