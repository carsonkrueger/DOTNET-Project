using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models;

public class Order
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int CustomerId { get; set; }
    public DateTime OrderPlaced { get; set; }
    public DateTime? OrderFulfilled { get; set; }

    public Customer Customer { get; set; } = null!;
    public ICollection<OrderDetail> OrderDetails { get; set; } = null!;

}
