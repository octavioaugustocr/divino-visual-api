using divino_visual_api.Dtos.User;
using divino_visual_api.Enums;
using divino_visual_api.Models;
using divino_visual_api.Repository.User;

namespace divino_visual_api.Services.User;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<ResponseModel<UserModel>> GetUserById(int id)
    {
        return await _userRepository.GetUserById(id);
    }

    public async Task<ResponseModel<List<UserModel>>> GetAllUsers()
    {
        return await _userRepository.GetAllUsers();
    }

    public async Task<ResponseModel<UserModel>> CreateUser(CreateUserDto createUserDto)
    {
        var userModel = new UserModel()
        {
            FullName = createUserDto.FullName,
            Cpf = createUserDto.Cpf,
            Email = createUserDto.Email,
            Password = createUserDto.Password,
            PhoneNumber = createUserDto.PhoneNumber,
            DateBirth = createUserDto.DateBirth,
            Gender = createUserDto.Gender,
            ProfilePhoto = createUserDto.ProfilePhoto,
            TypeUser = TypeUserEnum.Customer,
            CreatedAt = DateTime.Now
        };
        
        return await _userRepository.CreateUser(userModel);
    }

    public async Task<ResponseModel<UserModel>> UpdateUser(int id, UpdateUserDto updateUserDto)
    {
        var userModel = new UserModel()
        {
            Id = id,
            FullName = updateUserDto.FullName,
            Cpf = updateUserDto.Cpf,
            Email = updateUserDto.Email,
            PhoneNumber = updateUserDto.PhoneNumber,
            DateBirth = updateUserDto.DateBirth,
            Gender = updateUserDto.Gender,
            ProfilePhoto = updateUserDto.ProfilePhoto,
        };
        
        return await _userRepository.UpdateUser(userModel);
    }

    public async Task<ResponseModel<string>> DeleteUser(int id)
    {
        return await _userRepository.DeleteUser(id);
    }
}