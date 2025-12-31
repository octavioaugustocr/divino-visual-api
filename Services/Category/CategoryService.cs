using divino_visual_api.Dtos.Category;
using divino_visual_api.Models;
using divino_visual_api.Repositories.Category;

namespace divino_visual_api.Services.Category;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<ResponseModel<CategoryModel>> GetCategoryById(int id)
    {
        return await _categoryRepository.GetCategoryById(id);
    }

    public async Task<ResponseModel<List<CategoryModel>>> GetAllCategories()
    {
        return await _categoryRepository.GetAllCategories();
    }

    public async Task<ResponseModel<List<CategoryModel>>> GetAllCategoriesBySalonId(int salonId)
    {
        return await _categoryRepository.GetAllCategoriesBySalonId(salonId);
    }

    public async Task<ResponseModel<CategoryModel>> CreateCategory(CreateCategoryDto createCategoryDto)
    {
        var categoryModel = new CategoryModel()
        {
            Name = createCategoryDto.Name,
            SalonId = createCategoryDto.SalonId
        };
        
        return await _categoryRepository.CreateCategory(categoryModel);
    }

    public async Task<ResponseModel<string>> DeleteCategory(int id)
    {
        return await _categoryRepository.DeleteCategory(id);
    }
}