using divino_visual_api.Dtos.Category;
using divino_visual_api.Models;

namespace divino_visual_api.Services.Category;

public interface ICategoryService
{
    Task<ResponseModel<CategoryModel>> GetCategoryById(int id);
    Task<ResponseModel<List<CategoryModel>>> GetAllCategories();
    Task<ResponseModel<List<CategoryModel>>> GetAllCategoriesBySalonId(int salonId);
    Task<ResponseModel<CategoryModel>> CreateCategory(CreateCategoryDto createCategoryDto);
    Task<ResponseModel<string>> DeleteCategory(int id);
}