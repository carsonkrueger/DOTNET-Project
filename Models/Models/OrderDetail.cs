﻿using OnlineStore.InputModels;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models;

public class OrderDetail
{
    [Key]
    public int Id { get; set; }
    public int Quantity { get; set; }
    public int ProductId { get; set; }
    public int OrderId { get; set; }

    public Order Order { get; set; } = null!;
    public Product Product { get; set; } = null!;
}
