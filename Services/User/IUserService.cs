using divino_visual_api.Dtos.User;
using divino_visual_api.Models;

namespace divino_visual_api.Services.User;

public interface IUserService
{
    Task<ResponseModel<UserModel>> GetUserById(int id);
    Task<ResponseModel<List<UserModel>>> GetAllUsers();
    Task<ResponseModel<UserModel>> CreateUser(CreateUserDto createUserDto);
    Task<ResponseModel<UserModel>> UpdateUser(int id, UpdateUserDto updateUserDto);
    Task<ResponseModel<string>> DeleteUser(int id);
}