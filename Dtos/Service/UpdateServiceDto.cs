using System.ComponentModel.DataAnnotations;

namespace divino_visual_api.Dtos.Service;

public class UpdateServiceDto
{
    [Required(ErrorMessage = "Please provide the name of the service")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Please provide the description of the service")]
    public string Description { get; set; }
    
    [Required(ErrorMessage = "Please provide the price of the service")]
    [Range(0, double.MaxValue, ErrorMessage = "The price must be greater than 0")]
    public decimal Price { get; set; }
    
    [Required(ErrorMessage = "Please provide the estimated duration in minutes of the service")]
    public int EstimatedDurationMinutes { get; set; }
    
    [Required(ErrorMessage = "Please provide the salon ID of the service")]
    [Range(0, int.MaxValue, ErrorMessage = "The salon ID must be greater than 0")]
    public int SalonId { get; set; }
    
    [Required(ErrorMessage = "Please provide the category ID of the service")]
    [Range(0, int.MaxValue, ErrorMessage = "The category ID must be greater than 0")]
    public int CategoryId { get; set; }
}