using divino_visual_api.Models;

namespace divino_visual_api.Repositories.Category;

public interface ICategoryRepository
{
    Task<ResponseModel<CategoryModel>> GetCategoryById(int id);
    Task<ResponseModel<List<CategoryModel>>> GetAllCategories();
    Task<ResponseModel<List<CategoryModel>>> GetAllCategoriesBySalonId(int salonId);
    Task<ResponseModel<CategoryModel>> CreateCategory(CategoryModel category);
    Task<ResponseModel<string>> DeleteCategory(int id);
}