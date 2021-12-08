using System.ComponentModel.DataAnnotations.Schema;

namespace Andreys.Models
{
    public class UserProduct
    {
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

        public virtual Product Product{ get; set; }
    }
}
