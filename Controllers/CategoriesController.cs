using divino_visual_api.Dtos.Category;
using divino_visual_api.Services.Category;
using Microsoft.AspNetCore.Mvc;

namespace divino_visual_api.Controllers;

[ApiController]
[Route("api/v1/categories")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    
    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById(int id)
    {
        return Ok(await _categoryService.GetCategoryById(id));
    }

    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        return Ok(await _categoryService.GetAllCategories());
    }

    [HttpGet("{salonId}")]
    public async Task<IActionResult> GetAllCategoriesBySalonId(int salonId)
    {
        return Ok(await _categoryService.GetAllCategoriesBySalonId(salonId));
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
    {
        return Ok(await _categoryService.CreateCategory(createCategoryDto));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        return Ok(await _categoryService.DeleteCategory(id));
    }
}