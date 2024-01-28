using System.ComponentModel.DataAnnotations;

namespace ASPNET_BACKEND.Models;

public class OrderDetail
{
    [Key]
    public int Id { get; set; }
    public int Quantity { get; set; }
    public int ProductId { get; set; }
    public int OrderId { get; set; }

    [Required]
    public Order Order { get; set; }
    [Required]
    public Product Product { get; set; }
}
