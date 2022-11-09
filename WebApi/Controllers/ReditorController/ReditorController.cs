using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.ReditorController;

[ApiController]
[Route("[controller]")]
public class ReditorController:ControllerBase
{
    private readonly IReditorInterface reditorLogic;

    public ReditorController(IReditorInterface reditorLogic)
    {
        this.reditorLogic = reditorLogic;
    }

    [HttpPost]
   
    public async Task<ActionResult<Reditor>> CreateAsync(ReditorCreationDto dto)
    {
        try
        {
            Reditor reditor = await reditorLogic.CreateAsync(dto);
            return Created($"/reditors/{reditor.Id}", reditor);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}