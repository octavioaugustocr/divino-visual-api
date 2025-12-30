using divino_visual_api.Models;

namespace divino_visual_api.Repositories.Professional;

public interface IProfessionalRepository
{
    Task<ResponseModel<ProfessionalModel>> GetProfessionalById(int id);
    Task<ResponseModel<List<ProfessionalModel>>> GetAllProfessionals();
    Task<ResponseModel<ProfessionalModel>> CreateProfessional(ProfessionalModel professional);
    Task<ResponseModel<ProfessionalModel>> UpdateProfessional(ProfessionalModel professional);
    Task<ResponseModel<string>> DeleteProfessional(int id);
}