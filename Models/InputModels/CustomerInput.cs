using System.ComponentModel.DataAnnotations;

namespace OnlineStore.InputModels;

public class CustomerInput
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
}
