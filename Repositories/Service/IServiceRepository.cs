using divino_visual_api.Models;

namespace divino_visual_api.Repositories.Service;

public interface IServiceRepository
{
    Task<ResponseModel<ServiceModel>> GetServiceById(int id);
    Task<ResponseModel<List<ServiceModel>>> GetAllServices();
    Task<ResponseModel<List<ServiceModel>>> GetAllServicesBySalonId(int salonId);
    Task<ResponseModel<List<ServiceModel>>> GetAllServicesByCategoryId(int categoryId);
    Task<ResponseModel<ServiceModel>> CreateService(ServiceModel service);
    Task<ResponseModel<ServiceModel>> UpdateService(ServiceModel service);
    Task<ResponseModel<string>> DeleteService(int id);
}