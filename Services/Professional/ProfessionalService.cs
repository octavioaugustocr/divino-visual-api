using divino_visual_api.Dtos.Professional;
using divino_visual_api.Models;
using divino_visual_api.Repositories.Professional;

namespace divino_visual_api.Services.Professional;

public class ProfessionalService : IProfessionalService
{
    private readonly IProfessionalRepository _professionalRepository;

    public ProfessionalService(IProfessionalRepository professionalRepository)
    {
        _professionalRepository = professionalRepository;
    }

    public async Task<ResponseModel<ProfessionalModel>> GetProfessionalById(int id)
    {
        return await _professionalRepository.GetProfessionalById(id);
    }

    public async Task<ResponseModel<List<ProfessionalModel>>> GetAllProfessionals()
    {
        return await _professionalRepository.GetAllProfessionals();
    }

    public async Task<ResponseModel<ProfessionalModel>> CreateProfessional(CreateProfessionalDto createProfessionalDto)
    {
        var professionalModel = new ProfessionalModel()
        {
            FullName = createProfessionalDto.FullName,
            Cpf = createProfessionalDto.Cpf,
            Email = createProfessionalDto.Email,
            PhoneNumber = createProfessionalDto.PhoneNumber,
            Gender = createProfessionalDto.Gender,
            ProfilePhoto = createProfessionalDto.ProfilePhoto,
            Active = true,
            SalonId = createProfessionalDto.SalonId
        };
        
        return await _professionalRepository.CreateProfessional(professionalModel);
    }

    public async Task<ResponseModel<ProfessionalModel>> UpdateProfessional(int id, UpdateProfessionalDto updateProfessionalDto)
    {
        var professionalModel = new ProfessionalModel()
        {
            Id = id,
            FullName = updateProfessionalDto.FullName,
            Cpf = updateProfessionalDto.Cpf,
            Email = updateProfessionalDto.Email,
            PhoneNumber = updateProfessionalDto.PhoneNumber,
            Gender = updateProfessionalDto.Gender,
            ProfilePhoto = updateProfessionalDto.ProfilePhoto,
            Active = true,
            SalonId = updateProfessionalDto.SalonId
        };
        
        return await _professionalRepository.UpdateProfessional(professionalModel);
    }

    public async Task<ResponseModel<string>> DeleteProfessional(int id)
    {
        return await _professionalRepository.DeleteProfessional(id);
    }
}