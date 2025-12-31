using divino_visual_api.Data;
using divino_visual_api.Models;
using Microsoft.EntityFrameworkCore;

namespace divino_visual_api.Repositories.Category;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _appDbContext;
    
    public CategoryRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    
    public async Task<ResponseModel<CategoryModel>> GetCategoryById(int id)
    {
        var response = new ResponseModel<CategoryModel>();

        try
        {
            var category = await _appDbContext.Categories.FindAsync(id);
            if (category == null)
            {
                response.Message = $"Category with Id {id} not found!";
                return response;
            }
            
            response.Data = category;
            response.Message = "Success!";
            
            return response;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            response.Stats = false;
            return response;
        }
    }
    
    public async Task<ResponseModel<List<CategoryModel>>> GetAllCategories()
    {
        var response = new ResponseModel<List<CategoryModel>>();

        try
        {
            var categories = await _appDbContext.Categories.ToListAsync();

            response.Data = categories;
            response.Message = "Success!";

            return response;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            response.Stats = false;
            return response;
        }
    }

    public async Task<ResponseModel<List<CategoryModel>>> GetAllCategoriesBySalonId(int salonId)
    {
        var response = new ResponseModel<List<CategoryModel>>();

        try
        {
            var categories = await _appDbContext.Categories
                .Where(c => c.SalonId == salonId).ToListAsync();
            
            response.Data = categories;
            response.Message = "Success!";
            return response;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            response.Stats = false;
            return response;
        }
    }

    public async Task<ResponseModel<CategoryModel>> CreateCategory(CategoryModel category)
    {
        var response = new ResponseModel<CategoryModel>();

        try
        {
            await _appDbContext.Categories.AddAsync(category);
            await _appDbContext.SaveChangesAsync();
            
            response.Data = category;
            response.Message = "Success!";
            
            return response;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            response.Stats = false;
            return response;
        }
    }

    public async Task<ResponseModel<string>> DeleteCategory(int id)
    {
        var response = new ResponseModel<string>();

        try
        {
            var existingCategory = await _appDbContext.Categories.FindAsync(id);
            if (existingCategory == null)
            {
                response.Message = $"Category with ID {id} not found!";
                return response;
            }
            
            _appDbContext.Categories.Remove(existingCategory);
            await _appDbContext.SaveChangesAsync();

            response.Data = $"Category with ID {id} successfully deleted!";
            response.Message = "Success!";
            
            return response;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            response.Stats = false;
            return response;
        }
    }
}