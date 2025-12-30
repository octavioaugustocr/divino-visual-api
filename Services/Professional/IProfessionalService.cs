using divino_visual_api.Dtos.Professional;
using divino_visual_api.Models;

namespace divino_visual_api.Services.Professional;

public interface IProfessionalService
{
    Task<ResponseModel<ProfessionalModel>> GetProfessionalById(int id);
    Task<ResponseModel<List<ProfessionalModel>>> GetAllProfessionals();
    Task<ResponseModel<ProfessionalModel>> CreateProfessional(CreateProfessionalDto createProfessionalDto);
    Task<ResponseModel<ProfessionalModel>> UpdateProfessional(int id, UpdateProfessionalDto updateProfessionalDto);
    Task<ResponseModel<string>> DeleteProfessional(int id);
}