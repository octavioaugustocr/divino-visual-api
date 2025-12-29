using divino_visual_api.Data;
using divino_visual_api.Models;
using Microsoft.EntityFrameworkCore;

namespace divino_visual_api.Repositories.Salon;

public class SalonRepository : ISalonRepository
{
    private readonly AppDbContext _appDbContext;
    
    public SalonRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    
    public async Task<ResponseModel<SalonModel>> GetSalonById(int salonId)
    {
        var response = new ResponseModel<SalonModel>();

        try
        {
            var salon = await _appDbContext.Salons.FindAsync(salonId);
            if (salon == null)
            {
                response.Message = $"Salon with ID {salonId} not found!";
                return response;
            }
            
            response.Data = salon;
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

    public async Task<ResponseModel<List<SalonModel>>> GetAllSalons()
    {
        var response = new ResponseModel<List<SalonModel>>();

        try
        {
            var salons = await _appDbContext.Salons.ToListAsync();
            
            response.Data = salons;
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

    public async Task<ResponseModel<SalonModel>> CreateSalon(SalonModel salon)
    {
        var response = new ResponseModel<SalonModel>();

        try
        {
            await _appDbContext.Salons.AddAsync(salon);
            await _appDbContext.SaveChangesAsync();
            
            response.Data = salon;
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

    public async Task<ResponseModel<SalonModel>> UpdateSalon(SalonModel salon)
    {
        var response = new ResponseModel<SalonModel>();

        try
        {
            var existingSalon = await _appDbContext.Salons.FindAsync(salon.Id);

            if (existingSalon == null)
            {
                response.Message = $"Salon with ID {salon.Id} not found!";
                return response;
            }
            
            existingSalon.FantasyName = salon.FantasyName;
            existingSalon.Cnpj = salon.Cnpj;
            existingSalon.Description = salon.Description;
            existingSalon.PhoneNumber = salon.PhoneNumber;
            existingSalon.Email = salon.Email;
            existingSalon.LogoImage = salon.LogoImage;
            existingSalon.CoverImage = salon.CoverImage;
            existingSalon.OpeningTime = salon.OpeningTime;
            existingSalon.ClosingTime = salon.ClosingTime;
            existingSalon.Address.Cep = salon.Address.Cep;
            existingSalon.Address.Street = salon.Address.Street;
            existingSalon.Address.Number = salon.Address.Number;
            existingSalon.Address.Neighborhood = salon.Address.Neighborhood;
            existingSalon.Address.City = salon.Address.City;
            existingSalon.Address.State = salon.Address.State;
            existingSalon.Address.UF = salon.Address.UF;

            _appDbContext.Salons.Update(existingSalon);
            await _appDbContext.SaveChangesAsync();
            
            response.Data = existingSalon;
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

    public async Task<ResponseModel<string>> DeleteSalon(int salonId)
    {
        var response = new ResponseModel<string>();

        try
        {
            var salon = await _appDbContext.Salons.FindAsync(salonId);
            if (salon == null)
            {
                response.Message = $"Salon with ID {salonId} not found!";
                return response;
            }
            
            _appDbContext.Salons.Remove(salon);
            await _appDbContext.SaveChangesAsync();

            response.Data = $"Salon with ID {salonId} succesfully deleted!";
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