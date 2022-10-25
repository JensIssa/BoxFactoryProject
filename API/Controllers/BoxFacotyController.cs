using Application.DTOs;
using Application.InterfacesServices;
using Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class BoxFactoryController : ControllerBase
{
    private IBoxService service;

    public BoxFactoryController(IBoxService _service)
    {
        service = _service;
    }

    [HttpGet]
    public ActionResult<List<Box>> GetAllBoxes()
    {
        return service.GetAllBoxes();
    }

    [HttpPost]
    [Route("")]
    public ActionResult CreateBox(PostBoxDTO postBoxDto)
    {
        try
        {
            var result = service.CreateBox(postBoxDto);
            return Created("Box" + result.Id, result);
        }
        catch (ValidationException v)
        {
            return BadRequest(v.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}