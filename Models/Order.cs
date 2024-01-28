using System.ComponentModel.DataAnnotations;

namespace ASPNET_BACKEND.Models;

public class Order
{
    [Key]
    public int Id { get; set; }
    public DateTime OrderPlaced { get; set; }
    public DateTime? OrderFulfilled { get; set; }

    [Required]
    public Customer Customer { get; set; }
    [Required]
    public ICollection<OrderDetail> OrderDetails { get; set; }

}
