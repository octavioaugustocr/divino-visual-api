using divino_visual_api.Dtos.Salon;
using divino_visual_api.Services.Salon;
using Microsoft.AspNetCore.Mvc;

namespace divino_visual_api.Controllers;

[ApiController]
[Route("api/v1/salons")]
public class SalonsController : ControllerBase
{
    private readonly ISalonService _salonService;

    public SalonsController(ISalonService salonService)
    {
        _salonService = salonService;
    }

    [HttpGet("{salonId}")]
    public async Task<IActionResult> GetSalonById(int salonId)
    {
        return Ok(await _salonService.GetSalonById(salonId));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSalons()
    {
        return Ok(await _salonService.GetAllSalons());
    }

    [HttpPost]
    public async Task<IActionResult> CreateSalon(CreateSalonDto createSalonDto)
    {
        return Ok(await _salonService.CreateSalon(createSalonDto));
    }

    [HttpPut("{salonId}")]
    public async Task<IActionResult> UpdateSalon(int salonId, UpdateSalonDto updateSalonDto)
    {
        return Ok(await _salonService.UpdateSalon(salonId, updateSalonDto));
    }

    [HttpDelete("{salonId}")]
    public async Task<IActionResult> DeleteSalon(int salonId)
    {
        return Ok(await _salonService.DeleteSalon(salonId));
    }
}