using System.ComponentModel.DataAnnotations;

namespace BlazorApp_Firestore.Entities;

public class Customer
{
    [Required(ErrorMessage = "Bitte geben gib den Nachnamen ein.")]
    [Length(minimumLength: 3, maximumLength: 30)]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Bitte geben gib den Vornamen ein.")]
    [Length(minimumLength: 3, maximumLength: 30)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [EmailAddress(ErrorMessage = "Bitte gib eine Email Adresse ein.")]
    public string Email { get; set; } = string.Empty;

    [Required]
    [Phone(ErrorMessage = "Bitte gib eine Telefonnummer ein.")]
    public string Phone { get; set; } = string.Empty;

    public Guid Id { get; set; }
}

