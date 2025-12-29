using divino_visual_api.Models;

namespace divino_visual_api.Repositories.Salon;

public interface ISalonRepository
{
    Task<ResponseModel<SalonModel>> GetSalonById(int salonId);
    Task<ResponseModel<List<SalonModel>>> GetAllSalons();
    Task<ResponseModel<SalonModel>> CreateSalon(SalonModel salon);
    Task<ResponseModel<SalonModel>> UpdateSalon(SalonModel salon);
    Task<ResponseModel<string>> DeleteSalon(int salonId);
}