using System.ComponentModel.DataAnnotations;
using divino_visual_api.Enums;

namespace divino_visual_api.Dtos.Professional;

public class CreateProfessionalDto
{
    [Required(ErrorMessage = "Please provide the name of the professional")]
    public string FullName { get; set; }
    
    [Required(ErrorMessage = "Please provide the CPF of the professional")]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "CPF must have exactly 11 digits")]
    public string Cpf { get; set; }
    
    [Required(ErrorMessage = "Please provide the e-mail of the professional")]
    [EmailAddress(ErrorMessage =  "E-mail is not valid")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Please provide the phone number of the professional")]
    public string PhoneNumber { get; set; }
    
    [Required(ErrorMessage = "Please provide the gender of the professional")]
    public GenderEnum Gender { get; set; }
    
    public string? ProfilePhoto  { get; set; }
    
    [Required(ErrorMessage = "Please provide the salon id of the professional")]
    public int SalonId { get; set; }
}