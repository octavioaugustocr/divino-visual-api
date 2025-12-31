using System.ComponentModel.DataAnnotations;

namespace divino_visual_api.Dtos.Category;

public class CreateCategoryDto
{
    [Required(ErrorMessage = "Please provide the name of the category")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Please provide the salon ID of the category")]
    public int SalonId { get; set; }
}