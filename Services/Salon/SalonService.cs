using divino_visual_api.Dtos.Salon;
using divino_visual_api.Models;
using divino_visual_api.Repositories.Salon;

namespace divino_visual_api.Services.Salon;

public class SalonService : ISalonService
{
    private readonly ISalonRepository _salonRepository;
    
    public SalonService(ISalonRepository salonRepository)
    {
        _salonRepository = salonRepository;
    }

    public async Task<ResponseModel<SalonModel>> GetSalonById(int salonId)
    {
        return await _salonRepository.GetSalonById(salonId);
    }

    public async Task<ResponseModel<List<SalonModel>>> GetAllSalons()
    {
        return await _salonRepository.GetAllSalons();
    }

    public async Task<ResponseModel<SalonModel>> CreateSalon(CreateSalonDto createSalonDto)
    {
        var addressModel = new AddressSalonModel()
        {
            Cep = createSalonDto.Address.CEP,
            Street = createSalonDto.Address.Street,
            Number = createSalonDto.Address.Number,
            Neighborhood = createSalonDto.Address.Neighborhood,
            City = createSalonDto.Address.City,
            State = createSalonDto.Address.State,
            UF = createSalonDto.Address.UF
        };
        
        var salonModel = new SalonModel()
        {
            FantasyName = createSalonDto.FantasyName,
            Cnpj = createSalonDto.Cnpj,
            Description = createSalonDto.Description,
            Email = createSalonDto.Email,
            PhoneNumber = createSalonDto.PhoneNumber,
            LogoImage = createSalonDto.LogoImage,
            CoverImage = createSalonDto.CoverImage,
            OpeningTime = createSalonDto.OpeningTime,
            ClosingTime = createSalonDto.ClosingTime,
            Address = addressModel,
            Active = true,
            CreatedAt = DateTime.Now
        };
        
        return await _salonRepository.CreateSalon(salonModel);
    }

    public async Task<ResponseModel<SalonModel>> UpdateSalon(int salonId, UpdateSalonDto updateSalonDto)
    {
        var addressModel = new AddressSalonModel()
        {
            Cep = updateSalonDto.Address.CEP,
            Street = updateSalonDto.Address.Street,
            Number = updateSalonDto.Address.Number,
            Neighborhood = updateSalonDto.Address.Neighborhood,
            City = updateSalonDto.Address.City,
            State = updateSalonDto.Address.State,
            UF = updateSalonDto.Address.UF
        };

        var salonModel = new SalonModel()
        {
            Id = salonId,
            FantasyName = updateSalonDto.FantasyName,
            Cnpj = updateSalonDto.Cnpj,
            Description = updateSalonDto.Description,
            Email = updateSalonDto.Email,
            PhoneNumber = updateSalonDto.PhoneNumber,
            LogoImage = updateSalonDto.LogoImage,
            CoverImage = updateSalonDto.CoverImage,
            OpeningTime = updateSalonDto.OpeningTime,
            ClosingTime = updateSalonDto.ClosingTime,
            Address = addressModel
        };
        
        return await _salonRepository.UpdateSalon(salonModel);
    }

    public async Task<ResponseModel<string>> DeleteSalon(int salonId)
    {
        return await _salonRepository.DeleteSalon(salonId);
    }
}