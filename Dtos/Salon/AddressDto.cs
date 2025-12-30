using System.ComponentModel.DataAnnotations;

namespace divino_visual_api.Dtos.Salon;

public class AddressDto
{
    [Required(ErrorMessage = "Please provide the CEP of the salon")]
    public string CEP { get; set; }
    
    public string? Street { get; set; }
    public int? Number { get; set; }
    public string? Neighborhood { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? UF { get; set; }
}