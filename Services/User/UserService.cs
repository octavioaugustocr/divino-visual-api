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
    
    public Task<ResponseModel<UserModel>> GetUserById(int id)
    {
        return _userRepository.GetUserById(id);
    }

    public Task<ResponseModel<List<UserModel>>> GetAllUsers()
    {
        return _userRepository.GetAllUsers();
    }

    public Task<ResponseModel<UserModel>> CreateUser(CreateUserDto createUserDto)
    {
        var userModel = new UserModel()
        {
            FullName = createUserDto.FullName,
            Cpf = createUserDto.Cpf,
            Email = createUserDto.Email,
            Password = createUserDto.Password,
            PhoneNumber = createUserDto.PhoneNumber,
            DateBirth = createUserDto.DateBirth,
            Genrer = createUserDto.Genrer,
            ProfilePhoto = createUserDto.ProfilePhoto,
            TypeUser = TypeUserEnum.Customer,
            CreatedAt = DateTime.Now
        };
        
        return _userRepository.CreateUser(userModel);
    }

    public Task<ResponseModel<UserModel>> UpdateUser(int id, UpdateUserDto updateUserDto)
    {
        var userModel = new UserModel()
        {
            Id = id,
            FullName = updateUserDto.FullName,
            Cpf = updateUserDto.Cpf,
            Email = updateUserDto.Email,
            PhoneNumber = updateUserDto.PhoneNumber,
            DateBirth = updateUserDto.DateBirth,
            Genrer = updateUserDto.Genrer,
            ProfilePhoto = updateUserDto.ProfilePhoto,
        };
        
        return _userRepository.UpdateUser(userModel);
    }

    public Task<ResponseModel<string>> DeleteUser(int id)
    {
        return _userRepository.DeleteUser(id);
    }
}