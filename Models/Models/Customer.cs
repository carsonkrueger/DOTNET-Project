﻿using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models;

public class Customer
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }

    public ICollection<Order> Orders { get; set; } = null!;
}
