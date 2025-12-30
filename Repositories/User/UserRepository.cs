using divino_visual_api.Data;
using divino_visual_api.Models;
using Microsoft.EntityFrameworkCore;

namespace divino_visual_api.Repository.User;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _appDbContext;
    
    public UserRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<ResponseModel<UserModel>> GetUserById(int id)
    {
        var response = new ResponseModel<UserModel>();

        try
        {
            var user = await _appDbContext.Users.FindAsync(id);
            if (user == null)
            {
                response.Message = $"User with ID {id} not found!";
                return response;
            }
            
            response.Data = user;
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

    public async Task<ResponseModel<List<UserModel>>> GetAllUsers()
    {
        var response = new ResponseModel<List<UserModel>>();

        try
        {
            var users = await _appDbContext.Users.ToListAsync();

            response.Data = users;
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

    public async Task<ResponseModel<UserModel>> CreateUser(UserModel user)
    {
        var response = new ResponseModel<UserModel>();

        try
        {
            await _appDbContext.Users.AddAsync(user);
            await _appDbContext.SaveChangesAsync();
            
            response.Data = user;
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

    public async Task<ResponseModel<UserModel>> UpdateUser(UserModel user)
    {
        var response = new ResponseModel<UserModel>();

        try
        {
            var existingUser = await _appDbContext.Users.FindAsync(user.Id);
            if (existingUser == null)
            {
                response.Message = $"User with ID {user.Id} not found!";
                return response;
            }
            
            existingUser.FullName = user.FullName;
            existingUser.Cpf = user.Cpf;
            existingUser.Email = user.Email;
            existingUser.PhoneNumber = user.PhoneNumber;
            existingUser.DateBirth = user.DateBirth;
            existingUser.Gender = user.Gender;
            existingUser.ProfilePhoto = user.ProfilePhoto;
            existingUser.TypeUser = user.TypeUser;
            
            _appDbContext.Users.Update(existingUser);
            await _appDbContext.SaveChangesAsync();
            
            response.Data = existingUser;
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

    public async Task<ResponseModel<string>> DeleteUser(int id)
    {
        var response = new ResponseModel<string>();

        try
        {
            var user = await _appDbContext.Users.FindAsync(id);
            if (user == null)
            {
                response.Message =  $"User with ID {id} not found!";
                return response;
            }
            
            _appDbContext.Users.Remove(user);
            await _appDbContext.SaveChangesAsync();
            
            response.Data = $"User with ID {id} successfully deleted!";
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