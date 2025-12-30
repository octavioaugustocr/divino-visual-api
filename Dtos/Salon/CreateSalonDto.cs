using System.ComponentModel.DataAnnotations;
using divino_visual_api.Models;

namespace divino_visual_api.Dtos.Salon;

public class CreateSalonDto
{
    [Required(ErrorMessage = "Please provide the fantasy name of the salon")]
    public string FantasyName { get; set; }
    
    [Required(ErrorMessage = "Please provide the CPNJ of the salon")]
    [StringLength(14, MinimumLength = 14, ErrorMessage = "CNPJ must have exactly 14 digits")]
    public string Cnpj { get; set; }
    
    public string? Description { get; set; }
    
    [Required(ErrorMessage = "Please provide the phone number of the salon")]
    public string PhoneNumber { get; set; }
    
    [Required(ErrorMessage = "Please provide the email address of the salon")]
    [EmailAddress(ErrorMessage = "Please provide a valid email address")]
    public string Email { get; set; }
    
    public string? LogoImage { get; set; }
    
    public string? CoverImage { get; set; }
    
    [Required(ErrorMessage = "Please provide the opening time of the salon")]
    public TimeOnly OpeningTime { get; set; }
    
    [Required(ErrorMessage = "Please provide the closing time of the salon")]
    public TimeOnly ClosingTime { get; set; }
    
    [Required(ErrorMessage = "Please provide the address of salon")]
    public AddressDto Address { get; set; }
}