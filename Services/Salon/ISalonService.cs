using divino_visual_api.Dtos.Salon;
using divino_visual_api.Models;

namespace divino_visual_api.Services.Salon;

public interface ISalonService
{
    Task<ResponseModel<SalonModel>> GetSalonById(int salonId);
    Task<ResponseModel<List<SalonModel>>> GetAllSalons();
    Task<ResponseModel<SalonModel>> CreateSalon(CreateSalonDto createSalonDto);
    Task<ResponseModel<SalonModel>> UpdateSalon(int salonId, UpdateSalonDto updateSalonDto);
    Task<ResponseModel<string>> DeleteSalon(int salonId);
}