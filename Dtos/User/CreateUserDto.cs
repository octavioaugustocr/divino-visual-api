using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using divino_visual_api.Enums;

namespace divino_visual_api.Dtos.User;

public class CreateUserDto
{
    [Required(ErrorMessage = "Please provide the user's full name")]
    public string FullName { get; set; }
    
    [Required(ErrorMessage = "Please provide the CPF of the user")]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "CPF must have exactly 11 digits")]
    public string Cpf { get; set; }
    
    [Required(ErrorMessage = "Please provide the email of the user")]
    [EmailAddress(ErrorMessage = "Please provide a valid email address")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Please provide the password of the user")]
    public string Password { get; set; }
    
    [Required(ErrorMessage = "Please confirm your password")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match")]
    public string ConfirmPassword { get; set; }
    
    [Required(ErrorMessage = "Please provide the phone number of the user")]
    [Phone(ErrorMessage = "Please provide a valid phone number")]
    public string PhoneNumber { get; set; }
    
    [Required(ErrorMessage = "Please provide the date of birth of the user")]
    public DateOnly DateBirth { get; set; }
    
    [Required(ErrorMessage = "Please provide the genrer of the user")]
    public GenderEnum Gender { get; set; }
    
    public string? ProfilePhoto { get; set; }
}