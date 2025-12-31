using divino_visual_api.Dtos.Professional;
using divino_visual_api.Services.Professional;
using Microsoft.AspNetCore.Mvc;

namespace divino_visual_api.Controllers;

[ApiController]
[Route("api/v1/professionals")]
public class ProfessionalsController : ControllerBase
{
    private readonly IProfessionalService _professionalService;

    public ProfessionalsController(IProfessionalService professionalService)
    {
        _professionalService = professionalService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProfessionalById(int id)
    {
        return Ok(await _professionalService.GetProfessionalById(id));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProfessionals()
    {
        return Ok(await _professionalService.GetAllProfessionals());
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateProfessional(CreateProfessionalDto createProfessionalDto)
    {
        return Ok(await _professionalService.CreateProfessional(createProfessionalDto));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProfessional(int id, UpdateProfessionalDto updateProfessionalDto)
    {
        return Ok(await _professionalService.UpdateProfessional(id, updateProfessionalDto));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProfessional(int id)
    {
        return Ok(await _professionalService.DeleteProfessional(id));
    }
}