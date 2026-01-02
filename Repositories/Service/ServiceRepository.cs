using divino_visual_api.Data;
using divino_visual_api.Models;
using Microsoft.EntityFrameworkCore;

namespace divino_visual_api.Repositories.Service;

public class ServiceRepository : IServiceRepository
{
    private readonly AppDbContext _appDbContext;

    public ServiceRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<ResponseModel<ServiceModel>> GetServiceById(int id)
    {
        var response = new ResponseModel<ServiceModel>();

        try
        {
            var service = await _appDbContext.Services.FindAsync(id);
            if (service == null)
            {
                response.Message = $"Service with ID {id} not found!";
                return response;
            }
            
            response.Data = service;
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

    public async Task<ResponseModel<List<ServiceModel>>> GetAllServices()
    {
        var response = new ResponseModel<List<ServiceModel>>();

        try
        {
            var services = await _appDbContext.Services.ToListAsync();
            
            response.Data = services;
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

    public async Task<ResponseModel<List<ServiceModel>>> GetAllServicesBySalonId(int salonId)
    {
        var response = new ResponseModel<List<ServiceModel>>();

        try
        {
            var services = await _appDbContext.Services
                .Where(s => s.SalonId == salonId).ToListAsync();
            
            response.Data = services;
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

    public async Task<ResponseModel<List<ServiceModel>>> GetAllServicesByCategoryId(int categoryId)
    {
        var response = new ResponseModel<List<ServiceModel>>();

        try
        {
            var services = await _appDbContext.Services
                .Where(s => s.CategoryId == categoryId).ToListAsync();
            
            response.Data = services;
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

    public async Task<ResponseModel<ServiceModel>> CreateService(ServiceModel service)
    {
        var response = new ResponseModel<ServiceModel>();

        try
        {
            await _appDbContext.Services.AddAsync(service);
            await _appDbContext.SaveChangesAsync();
            
            response.Data = service;
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

    public async Task<ResponseModel<ServiceModel>> UpdateService(ServiceModel service)
    {
        var response = new ResponseModel<ServiceModel>();

        try
        {
            var existingService = await _appDbContext.Services.FindAsync(service.Id);
            if (existingService == null)
            {
                response.Message = $"Service with ID {service.Id} not found found";
                return response;
            }
            
            existingService.Name = service.Name;
            existingService.Description = service.Description;
            existingService.Price = service.Price;
            existingService.EstimatedDurationMinutes = service.EstimatedDurationMinutes;
            
            _appDbContext.Services.Update(existingService);
            await _appDbContext.SaveChangesAsync();
            
            response.Data = existingService;
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

    public async Task<ResponseModel<string>> DeleteService(int id)
    {
        var response = new ResponseModel<string>();

        try
        {
            var existingService = await _appDbContext.Services.FindAsync(id);
            if (existingService == null)
            {
                response.Message =  $"Service with ID {id} not found found";
                return response;
            }
            
            _appDbContext.Services.Remove(existingService);
            await _appDbContext.SaveChangesAsync();
            
            response.Data = $"Service  with ID {id} successfully deleted!";
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