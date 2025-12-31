using divino_visual_api.Dtos.User;
using divino_visual_api.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace divino_visual_api.Controllers;

[ApiController]
[Route("api/v1/users")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    
    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        return Ok(await _userService.GetUserById(id));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        return Ok(await _userService.GetAllUsers());
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
    {
        return Ok(await _userService.CreateUser(createUserDto));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, UpdateUserDto updateUserDto)
    {
        return Ok(await _userService.UpdateUser(id, updateUserDto));
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        return Ok(await _userService.DeleteUser(id));
    }
}