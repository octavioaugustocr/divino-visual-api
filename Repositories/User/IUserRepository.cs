using divino_visual_api.Models;

namespace divino_visual_api.Repository.User;

public interface IUserRepository
{
    Task<ResponseModel<UserModel>> GetUserById(int id);
    Task<ResponseModel<List<UserModel>>> GetAllUsers();
    Task<ResponseModel<UserModel>> CreateUser(UserModel user);
    Task<ResponseModel<UserModel>> UpdateUser(UserModel user);
    Task<ResponseModel<string>> DeleteUser(int id);
}