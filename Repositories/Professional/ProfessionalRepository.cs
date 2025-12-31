using divino_visual_api.Data;
using divino_visual_api.Models;
using Microsoft.EntityFrameworkCore;

namespace divino_visual_api.Repositories.Professional;

public class ProfessionalRepository : IProfessionalRepository
{
    private readonly AppDbContext _appDbContext;

    public ProfessionalRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<ResponseModel<ProfessionalModel>> GetProfessionalById(int id)
    {
        var response = new ResponseModel<ProfessionalModel>();

        try
        {
            var professional = await _appDbContext.Professionals.FindAsync(id);
            if (professional == null)
            {
                response.Message = $"Professional with ID {id} not found!";
                return response;
            }
            
            response.Data = professional;
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

    public async Task<ResponseModel<List<ProfessionalModel>>> GetAllProfessionals()
    {
        var response = new ResponseModel<List<ProfessionalModel>>();

        try
        {
            var professionals = await _appDbContext.Professionals.ToListAsync();
            
            response.Data = professionals;
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

    public async Task<ResponseModel<ProfessionalModel>> CreateProfessional(ProfessionalModel professional)
    {
        var response = new ResponseModel<ProfessionalModel>();

        try
        {
            await _appDbContext.Professionals.AddAsync(professional);
            await _appDbContext.SaveChangesAsync();
            
            response.Data = professional;
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

    public async Task<ResponseModel<ProfessionalModel>> UpdateProfessional(ProfessionalModel professional)
    {
        var response = new ResponseModel<ProfessionalModel>();

        try
        {
            var existingProfessional = await _appDbContext.Professionals.FindAsync(professional.Id);
            if (existingProfessional == null)
            {
                response.Message = $"Professional with ID {professional.Id} not found!";
                return response;
            }
            
            existingProfessional.FullName = professional.FullName;
            existingProfessional.Cpf = professional.Cpf;
            existingProfessional.Email = professional.Email;
            existingProfessional.PhoneNumber = professional.PhoneNumber;
            existingProfessional.Gender = professional.Gender;
            existingProfessional.ProfilePhoto = professional.ProfilePhoto;
            existingProfessional.SalonId = professional.SalonId;
            
            _appDbContext.Professionals.Update(existingProfessional);
            await _appDbContext.SaveChangesAsync();
            
            response.Data = existingProfessional;
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

    public async Task<ResponseModel<string>> DeleteProfessional(int id)
    {
        var response = new ResponseModel<string>();

        try
        {
            var professional = await _appDbContext.Professionals.FindAsync(id);
            if (professional == null)
            {
                response.Message = $"Professional with ID {id} not found!";
                return response;
            }
            
            _appDbContext.Professionals.Remove(professional);
            await _appDbContext.SaveChangesAsync();

            response.Data = $"Professional with ID {id} successfully deleted!";
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