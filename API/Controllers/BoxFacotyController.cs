using Application.DTOs;
using Application.InterfacesServices;
using Domain.Entities;
using FluentValidation;
using Infrastructure.Repositories;
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
    public ActionResult<Box> CreateBox(PostBoxDTO postBoxDto)
    {
        try
        {
            Box result = service.CreateBox(postBoxDto);
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

    [HttpGet]
    [Route("CreateDB")]
    public void CreateDB()
    {
        service.RebuildDB();
    }

    [HttpGet]
    [Route("id")]
    public ActionResult<Box> GetBoxById(int id)
    {
        try
        {
            return service.GetBoxById(id);
        }
        catch (KeyNotFoundException k)
        {
            return NotFound("No box has been found " + id);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.ToString());
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult<Box> DeleteBox(int id)
    {
        try
        {
            return Ok(service.DeleteBox(id));
        }
        catch (KeyNotFoundException k)
        {
            return NotFound("No box has been found " + id);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.ToString());
        }
    }

    [HttpPut]
    [Route("Edit/{id}")]
    public ActionResult<Box> UpdateBox( [FromRoute]int id, [FromBody]PutBoxDTO box)
    {
        try
        {
            return Ok(service.UpdateBox(id, box));
        }
        catch (KeyNotFoundException k)
        {
            return NotFound("No box has been found " + id);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.ToString());
        }
    }
}